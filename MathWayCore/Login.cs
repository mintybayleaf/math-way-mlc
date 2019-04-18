using System;
using System.Windows.Forms;

namespace MathLogCenter
{
    public partial class Login : Form
    {
        private readonly string master = "bayleaf";
        private readonly string secret = "KNWXfty666sbbtty";

        private readonly string mentor = "jstone";
        private readonly string phrase = "paris4life";

        private string userName = "";
        private string password = "";

        private bool isAdmin = false;
        private bool isSuperAdmin = false;

        public bool IsAdmin
        {
            set => isAdmin = value;
            get => isAdmin;
        }

        public bool IsSuperAdmin
        {
            set => isSuperAdmin = value;
            get => isSuperAdmin;
        }

        public string User
        {
            get => userName;
        }

        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string user = txtUserName.Text.Trim();
            string pass = txtPassword.Text;
            bool isValidUser = false;
            bool isValidPass = false;

            // Bayleafs profile
            if(user.Equals(master) && pass.Equals(secret))
            {

                isValidPass = true;
                isValidUser = true;
                isAdmin = false;
                isSuperAdmin = true;
                userName = master;
                password = secret;
            }

            // Jasons profile
            if (user.Equals(mentor) && pass.Equals(phrase))
            {
                isValidPass = true;
                isValidUser = true;
                isAdmin = true;
                isSuperAdmin = false;
                userName = mentor;
                password = phrase;
            }

            // Look through all the data rows
            // Check for the username then match the password
            if(!isAdmin && !isSuperAdmin)
            {
                if (MathLib.DConnect.Connection.CheckUserPass(user, pass))
                {
                    isValidPass = true;
                    isValidUser = true;
                    isAdmin = false;
                    isSuperAdmin = false;
                    userName = user;
                    password = pass;
                }
            }
           
            if (isValidUser && isValidPass)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Error With UserName or Password", "Try Again...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MathLib.Logger.Instance.WriteLog("DEBUG", "Error With Login Attempt");
                this.txtPassword.Text = string.Empty;
                this.txtUserName.Text = string.Empty;
                this.txtUserName.Focus();
            }

        }

       
        
    }
}
