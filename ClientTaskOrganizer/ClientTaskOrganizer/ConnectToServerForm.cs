using ClientTaskOrganizer.ServiceReference1;
using System;
using System.ServiceModel;
using System.Windows.Forms;

namespace ClientTaskOrganizer
{
    public partial class ConnectToServerForm : Form
    {
        static public bool ConnectOK = false;
        public ConnectToServerForm()
        {
            InitializeComponent();
        }

        private void butConnect_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtBxIP.Text != null && txtBxPort.Text != null)
                {
                    WorkWithDatabase.client = new TaskOrganizerClient("BasicHttpBinding_ITaskOrganizer");
                    EndpointAddress endpointAddress = new EndpointAddress($"http://{txtBxIP.Text}:{txtBxPort.Text}//WCF_TaskOrganizer");
                    WorkWithDatabase.client.Endpoint.Address = endpointAddress;
                    WorkWithDatabase.client.SelectAllFromDb(User.userLogin);//перевіримо чи можна вибрати дані
                    FormLoginUser formLoginUser = new FormLoginUser();
                    formLoginUser.ShowDialog();
                    this.Close();//закриваємо форму для підключення
                    ConnectOK = true;
                }
                else { MessageBox.Show("Fill all empty fields"); }
            }
            catch (Exception ex) { MessageBox.Show("Error connecting.\nTry again"); }
        }

        private void butExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
