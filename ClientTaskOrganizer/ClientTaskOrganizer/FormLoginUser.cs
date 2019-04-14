using System;
using System.Windows.Forms;
using ClientTaskOrganizer.ServiceReference1;

namespace ClientTaskOrganizer
{
    public partial class FormLoginUser : Form
    {
        public FormLoginUser()
        {
            InitializeComponent();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            ServiceReference1.User user = new ServiceReference1.User();
            user.UserLogin = textBoxUserLogin.Text;
            user.UserPassword = textBoxUserPassword.Text;
            if (WorkWithDatabase.client.ConfirmUser(user))
            {
                User.userLogin = user.UserLogin;
                User.userPassword = user.UserPassword;
                this.Close();
            }
            else
            {
                MessageBox.Show("Error user name or user password!");
            }
        }

        private void buttonRegistration_Click(object sender, EventArgs e)
        {
            ServiceReference1.User user = new ServiceReference1.User();
            user.UserLogin = textBoxUserLogin.Text;
            user.UserPassword = textBoxUserPassword.Text;
            if (WorkWithDatabase.client.ConfirmUser(user))
            {
                MessageBox.Show("Error user name!\nThis user already exists!");
            }
            else
            {
                if (WorkWithDatabase.client.AddUser(user))
                {
                    User.userLogin = user.UserLogin;
                    User.userPassword = user.UserPassword;
                    this.Close();
                }
            }
        }
    }
}
