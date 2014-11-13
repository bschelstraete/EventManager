using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace ProjectGroep13
{
    class Filters //singleton
    {
        private static Filters instance;

        private DateTime startdate, enddate;
        private List<DateTime> dates = new List<DateTime>();
        private string creator = "";
        private bool start, end, mine;
        private int people;
        

        private Filters()
        {
            Reset();
        }

        public static Filters Instance
        {
            get
            {
                if (instance == null) instance = new Filters();
                return instance;
            }
        }

        public DateTime StartDate
        {
            get { return startdate; }
            set { startdate = value.Date; start = true; }
        }
        public DateTime EndDate
        {
            get { return enddate; }
            set { enddate = value.Date; end = true; }
        }
        public string Creator
        {
            get { return creator; }
            set { creator = value; if (creator == Login.Instance.Username) mine = true; }
        }
        public string Text { get; set; }
        public string Location { get; set; }
        public int ParticipantCount
        {
            get { return people; }
            set { if (people < value) people = value; }
        }
        public bool Joined { get; set; }
        public bool NotFull { get; set; }
        public bool Full { get; set; }

        public void AddSpecificDate(DateTime dt)
        {
            if (!dates.Contains(dt)) dates.Add(dt.Date);
        }

        public string FilterText()
        {
            string ft = "Currently showing all";
            if (mine) ft += " my";
            if (start && !end && SameDay(startdate)) ft += " upcoming";
            else if (end && enddate.Date < DateTime.Today.Date) ft += " expired";

            ft += " events";

            if (Location.Length > 0)
                ft += string.Format(" occuring in {0},", Location);

            if (creator.Length > 0 && Login.Instance.Username != creator)
                ft += string.Format(" belonging to {0},", creator);

            if (Joined) ft += " that I have joined,";

            if (start && end)
                ft += string.Format(" that {0} between {1} and {2},",
                    StartStarted(enddate), GetPeriodical(startdate), GetPeriodical(enddate));
            else if (start && !SameDay(startdate))
                ft += string.Format(" that start on {0:d} or later,", startdate);
            else if (end)
                ft += string.Format(" that {0} on {1:d} or earlier,", StartStarted(enddate), enddate);

            if (people == 1) ft += " where at least one person has joined,";
            else if (people > 1) ft += string.Format(" where at least {0} people have joined,", people);

            if (NotFull) ft += " that aren't completely full,";
            else if (Full) ft += " that are completely full,";

            if (dates.Count > 0) {
                ft += " on the following date(s):";
                foreach (DateTime d in dates)
                    ft += string.Format(" {0:d},",d);
            }

            ft += ".";
            ft = ft.Replace(",.", ".");
            return ft;
        }

        public List<Evenement> GetFilteredResults()
        {
            string s = "SELECT e.*, u.Username FROM Events e INNER JOIN Users u ON e.CreatorID = u.UserID";
            List<String> l = new List<string>();

            if (start && end) l.Add("StartDate BETWEEN @StartDate AND @EndDate");
            else if (start) l.Add("StartDate >= @StartDate");
            else if (end) l.Add("StartDate <= @EndDate");

            if (Location.Length > 0) l.Add("Location = @Location");
            if (Creator.Length > 0) l.Add("Username = @Creator");
            if (Text.Length > 0) l.Add("Title LIKE @Text OR Description LIKE @Text");

            if (l.Count > 0) {
                s += " WHERE " + l.First();
                if (l.Count > 1)
                    for (int i = 1; i < l.Count; i++)
                        s += " AND " + l[i];
            }
            s += " ORDER BY StartDate ASC";

            SqlCommand command = new SqlCommand(s);
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@StartDate", string.Format("{0:yyyy-MM-dd}", startdate));
            command.Parameters.AddWithValue("@EndDate", string.Format("{0:yyyy-MM-dd}", enddate));
            command.Parameters.AddWithValue("@Location", Location);
            command.Parameters.AddWithValue("@Creator", Creator);
            command.Parameters.AddWithValue("@Text", "%" + Text + "%");

            List<Evenement> events = SQL.Instance.RetrieveEvents(command);

            if (ParticipantCount > 0) events = events.Where(ev => ev.Participants.Count >= ParticipantCount).ToList();
            if (NotFull) events = events.Where(ev => ev.Capacity < 0 || ev.Participants.Count < ev.Capacity).ToList();
            else if (Full) events = events.Where(ev => ev.Capacity > 0 && ev.Participants.Count == ev.Capacity).ToList();
            if (Joined) events = events.Where(ev => ev.Participants.Contains(Login.Instance.UserID)).ToList();
            if (dates.Count>0) events = events.Where(ev => dates.Contains(ev.StartDate.Date)).ToList();

            return events;
        }

        public void Reset()
        {
            startdate = DateTime.Today.Date;
            enddate = DateTime.Today.Date;
            dates.Clear();
            Text = "";
            Creator = "";
            Location = "";
            start = false;
            end = false;
            NotFull = false;
            Full = false;
            Joined = false;
            mine = false;
            people = 0;
        }

        private bool SameDay(DateTime d)
        {
            return d.Date == DateTime.Today.Date;
        }

        private string GetPeriodical(DateTime d)
        {
            int span = (int)(d.Date - DateTime.Today.Date).TotalDays;
            switch (span) {
                case -1: return "yesterday";
                case 0: return "today";
                case 1: return "tomorrow";
            }
            return string.Format("{0:d}", d);
        }

        private string StartStarted(DateTime d)
        {
            if (d > DateTime.Now) return "start";
            else return "started";
        }

    }
}
