using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace ProjectGroep13
{
    public class SQL //singleton
    {
        SqlConnection connection;
        SqlCommand command;

        private static SQL instance;

        private SQL()
        {
            connection = new SqlConnection("Server=172.21.1.84;Database=CSGroep13;Uid=CSGroep13;Pwd=Celsius_20;");
            command = new SqlCommand("", connection);
        }

        public static SQL Instance
        {
            get
            {
                if (instance == null) {
                    instance = new SQL();
                }
                return instance;
            }
        }

        public bool UserExists(string username)
        {
            string sql = "SELECT Count(*) FROM Users WHERE Username = @Username";
            command.CommandText = sql;
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@Username", username);
            return (RunScalarQuery() > 0); 
        }

        public int RetrieveUserID(string username)
        {
            string sql = "SELECT UserID FROM Users WHERE Username = @Username";
            command.CommandText = sql;
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@Username", username);
            return RunScalarQuery();
        }

        public int RetrieveParticipantCount(string eventid)
        {
            string sql = string.Format("SELECT Count(*) FROM Participants WHERE EventID = @EventID");
            command.CommandText = sql;
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@EventID", eventid);
            return RunScalarQuery();
        }

        public bool IsGoodLogin(string username, string password)
        {
            string sql = "SELECT Count(*) FROM Users WHERE UserName = @Username AND Password = @Password";
            command.CommandText = sql;
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@Username", username);
            command.Parameters.AddWithValue("@Password", password);
            return (RunScalarQuery() > 0);
        }

        private int RunScalarQuery()
        {
            int result = -1;
            try {
                if (command.Connection.State != ConnectionState.Open) command.Connection.Open();
                result = (int)command.ExecuteScalar();
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            } finally{
                command.Connection.Close();
            }
            return result;
        }

        public List<Evenement> RetrieveAllEvents()
        {
            List<Evenement> l = new List<Evenement>();
            try {
                string sql = "SELECT e.*, u.Username FROM Events e INNER JOIN Users u ON e.CreatorID = u.UserID ORDER BY StartDate ASC";
                command.CommandText = sql;
                command.Parameters.Clear();
                command.Connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read()) {
                    Evenement ev = new Evenement();
                    ev.CreatorID = Convert.ToInt32(reader["CreatorID"]);
                    ev.CreatorName = reader["Username"].ToString();
                    ev.ID = Convert.ToInt32(reader["EventID"]);
                    ev.Title = reader["Title"].ToString();
                    ev.Location = reader["Location"].ToString();
                    ev.Description = reader["Description"].ToString();
                    ev.Capacity = Convert.ToInt32(reader["Capacity"]);
                    ev.Minimum = Convert.ToInt32(reader["MinimumOccupancy"]);
                    ev.StartDate = Convert.ToDateTime(reader["StartDate"]);
                    l.Add(ev);
                }
                reader.Close();

                foreach (Evenement ev in l)
                    ev.Participants = RetrieveParticipants(ev.ID);

            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            } finally {
                command.Connection.Close();
            }
            return l;
        }

        public List<Evenement> RetrieveEvents(SqlCommand cmd)
        {
            List<Evenement> l = new List<Evenement>();
            try {
                command = cmd;
                command.Connection = connection;
                command.Connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read()) {
                    Evenement ev = new Evenement();
                    ev.CreatorID = Convert.ToInt32(reader["CreatorID"]);
                    ev.CreatorName = reader["Username"].ToString();
                    ev.ID = Convert.ToInt32(reader["EventID"]);
                    ev.Title = reader["Title"].ToString();
                    ev.Location = reader["Location"].ToString();
                    ev.Description = reader["Description"].ToString();
                    ev.Capacity = Convert.ToInt32(reader["Capacity"]);
                    ev.Minimum = Convert.ToInt32(reader["MinimumOccupancy"]);
                    ev.StartDate = Convert.ToDateTime(reader["StartDate"]);
                    l.Add(ev);
                }
                reader.Close();

                foreach (Evenement ev in l) ev.Participants = RetrieveParticipants(ev.ID);

            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            } finally {
                command.Connection.Close();
            }
            return l;
        }

        public Evenement RetrieveSpecificEvent(int id)
        {
            command.CommandText = "SELECT e.*, u.Username FROM Events e INNER JOIN Users u ON e.CreatorID = u.UserID WHERE EventID = @EventID";
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@EventID", id);
            return RetrieveEvents(command).First();
        }

        private HashSet<int> RetrieveParticipants(int eventID)
        {
            //WARNING: method is designed to work while connection is open for faster results

            string sql = "SELECT * FROM Participants WHERE EventID = @EventID";
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@EventID", eventID);
            command.CommandText = sql;

            SqlDataReader reader = command.ExecuteReader();
            HashSet<int> l = new HashSet<int>();
            while (reader.Read()) l.Add(Convert.ToInt32(reader["UserID"]));
            reader.Close();

            return l;
        }

        public void AddUser(string username, string password)
        {
            try {
                string sql = "INSERT INTO Users (Username, Password) VALUES (@Username, @Password)";
                command.CommandText = sql;
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@Password", password);
                command.Connection.Open();
                command.ExecuteNonQuery();
                MessageBox.Show(string.Format("Account creation successful. Welcome, {0}!", username));
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            } finally {
                command.Connection.Close();
            }
        }

        public void AddEvent(Evenement ev)
        {
            try {
                string sql = "INSERT INTO Events (StartDate,Title,CreatorID,Location,Description,MinimumOccupancy,Capacity) VALUES (@StartDate,@Title,@CreatorID,@Location,@Description,@Minimum,@Capacity)";
                command.CommandText = sql;
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@CreatorID", ev.CreatorID);
                command.Parameters.AddWithValue("@Title", ev.Title);
                command.Parameters.AddWithValue("@Location", ev.Location);
                command.Parameters.AddWithValue("@Description", ev.Description);
                command.Parameters.AddWithValue("@Capacity", ev.Capacity);
                command.Parameters.AddWithValue("@Minimum", ev.Minimum);
                command.Parameters.AddWithValue("@StartDate", ev.StartDate);
                command.Connection.Open();
                command.ExecuteNonQuery();
                MessageBox.Show("Event was uploaded successfully.");
            } catch (Exception ex) {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            } finally {
                command.Connection.Close();
            }
        }

        public void RemoveEvent(int eventid)
        {
            try {
                string sql = "DELETE FROM Events WHERE EventID = @EventID";
                command.CommandText = sql;
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@EventID", eventid);
                command.Connection.Open();
                command.ExecuteNonQuery();
            } catch (Exception ex) {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            } finally {
                command.Connection.Close();
            }
        }

        public void EditEvent(Evenement ev)
        {
            try {
                string sql = "UPDATE Events SET CreatorID = @CreatorID, Title = @Title, "
                    + "Description = @Description, Capacity = @Capacity, "
                    + "MinimumOccupancy = @Minimum, StartDate = @StartDate, "
                    + "Location = @Location "
                    + "WHERE EventID = @EventID";
                command.CommandText = sql;
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@EventID", ev.ID);

                command.Parameters.AddWithValue("@CreatorID", ev.CreatorID);
                command.Parameters.AddWithValue("@Title", ev.Title);
                command.Parameters.AddWithValue("@Location", ev.Location);
                command.Parameters.AddWithValue("@Description", ev.Description);
                command.Parameters.AddWithValue("@Capacity", ev.Capacity);
                command.Parameters.AddWithValue("@Minimum", ev.Minimum);
                command.Parameters.AddWithValue("@StartDate", ev.StartDate);
                command.Connection.Open();
                command.ExecuteNonQuery();
                MessageBox.Show("Event was successfully modified.");
            } catch (Exception ex) {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            } finally {
                command.Connection.Close();
            }
        }

        public void JoinEvent(int userid, int eventid)
        {
            try {
                string sql = "INSERT INTO Participants (EventID,UserID) VALUES (@EventID,@UserID)";
                command.CommandText = sql;
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@EventID", eventid);
                command.Parameters.AddWithValue("@UserID", userid);
                command.Connection.Open();
                command.ExecuteNonQuery();
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            } finally {
                command.Connection.Close();
            }
        }

        public void LeaveEvent(int userid, int eventid)
        {
            try {
                string sql = "DELETE FROM Participants WHERE UserID = @UserID AND EventID = @EventID";
                command.CommandText = sql;
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@EventID", eventid);
                command.Parameters.AddWithValue("@UserID", userid);
                command.Connection.Open();
                command.ExecuteNonQuery();
            } catch (Exception ex) {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            } finally {
                command.Connection.Close();
            }
        }

    }
}
