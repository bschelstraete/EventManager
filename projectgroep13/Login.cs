using System;

namespace ProjectGroep13
{
    public class Login //singleton
    {
        private static Login instance;

        private Login()
        {
            UserID = -1;
        }

        public static Login Instance
        {
            get
            {
                if (instance == null) instance = new Login();
                return instance;
            }
        }

        public string Username { get; private set; }
        public int UserID { get; private set; }

        public bool IsLoggedIn
        {
            get { return (UserID > -1); }
        }

        public void DoLogin(string username, string password)
        {
            //check if user exists
            if (!SQL.Instance.UserExists(username)) throw new Exception("Unknown user.");

            //check password
            if (!SQL.Instance.IsGoodLogin(username,password)) throw new Exception("Invalid password.");

            Username = username;
            UserID = SQL.Instance.RetrieveUserID(username);
        }

        public void DoLogout()
        {
            Username = "";
            UserID = -1;
        }

        public void CreateNewUser(string username, string password)
        {
            ValidateUsername(username);
            ValidatePassword(password);

            SQL.Instance.AddUser(username, password);

            DoLogin(username, password);
        }

        private void ValidateUsername(string name)
        {
            if (name.Length < 2) throw new Exception("Username is too short.");
            if (ContainsIllegalCharacters(name)) throw new Exception("Username contains illegal characters.");
            if (SQL.Instance.UserExists(name)) throw new Exception("A user with that name already exists.");

        }

        private void ValidatePassword(string pwd)
        {
            if (pwd.Length < 5) throw new Exception("Password is too short.");

        }

        private bool ContainsIllegalCharacters(string s)
        {
            if (s.Contains("'")) return true;
            if (s.Contains("%")) return true;
            if (s.Contains("@")) return true;
            if (s.Contains("!")) return true;
            if (s.Contains("#")) return true;
            if (s.Contains(":")) return true;
            if (s.Contains(";")) return true;
            //...
            return false;
        }
    }
}
