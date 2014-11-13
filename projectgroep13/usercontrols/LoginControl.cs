using System;

using GUI_Bits;

namespace ProjectGroep13
{
    public partial class LoginControl : InfoContainerList
    {
        private TextBoxContainer user = new TextBoxContainer("Username");
        private TextBoxContainer pwd = new TextBoxContainer("Password", true);
        private ButtonContainer login = new ButtonContainer("Log in");
        private ButtonContainer newacc = new ButtonContainer("Create new account");

        public LoginControl()
        {
            InitializeComponent();

            this.Add(user);
            this.Add(pwd);
            this.Add(login);
            this.Add(newacc);
        }

        public ButtonContainer LoginButton
        {
            get { return login; }
        }

        public ButtonContainer CreateButton
        {
            get { return newacc; }
        }

        public String Username
        {
            get { return user.Value; }
        }

        public String Password
        {
            get { 
                //make retrievable only once
                string p = pwd.Value;
                pwd.Value = "";
                return p;
            }
        }

    }
}
