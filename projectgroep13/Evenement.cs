using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGroep13
{
    public class Evenement
    {
        public int ID { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }

        public DateTime StartDate { get; set; }

        public int CreatorID { get; set; }
        public string CreatorName { get; set; }

        public int Minimum { get; set; }
        public int Capacity { get; set; }

        public HashSet<int> Participants { get; set; }

        public Evenement(){}
        public Evenement(int eventID)
        {
            ID = eventID;
        }

    }
}
