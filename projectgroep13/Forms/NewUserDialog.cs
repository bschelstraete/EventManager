using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using GUI_Bits;

namespace ProjectGroep13
{
    public partial class NewUserDialog : Form
    {
        private TextBoxContainer txtUser = new TextBoxContainer("Username");
        private TextBoxContainer txtPwd1 = new TextBoxContainer("Password", true);
        private TextBoxContainer txtPwd2 = new TextBoxContainer("Retype pw", true);
        private ButtonContainer reg = new ButtonContainer("REGISTER");

        public NewUserDialog()
        {
            InitializeComponent();

            iclNewUser.Add(txtUser);
            iclNewUser.Add(txtPwd1);
            iclNewUser.Add(txtPwd2);
            iclNewUser.Add(reg);

            reg.Click += reg_Click;
            this.DialogResult = DialogResult.Cancel;
        }

        void reg_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        public string Username
        {
            get { return txtUser.Value; }
        }

        public string Password
        {
            get {
                if (txtPwd1.Value != txtPwd2.Value) throw new Exception("Passwords do not match.");
                return txtPwd1.Value;
            }
        }

    }
}
