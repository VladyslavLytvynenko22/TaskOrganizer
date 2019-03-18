using ClientTaskOrganizer.RefServiceTaskOrganizer;
using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Windows.Forms;

namespace ClientTaskOrganizer
{
    public partial class Form_ClientTaskOrganizer : Form
    {
        private TaskOrganizerClient client;
        private string nameDataBases;
        private string nameTable;

        public Form_ClientTaskOrganizer()
        {
            InitializeComponent();
        }
        
        public void AddRowFromDataGridViewToDb()
        {
            AddRowForm addRowForm = new AddRowForm();
            
            addRowForm.butOk.Click += (senderAddRow, eAddRow) =>
            {
                DataGridView dataGridView = addRowForm.dataGridView1;
                DataGridViewRow dataGridViewRow = dataGridView.Rows[0];
                if (WorkWithDataGridView.CheckDataGridViewRow(dataGridView))//якщо заповнено правильно
                {
                    string description = dataGridViewRow.Cells["Description"].Value.ToString();
                    string priority = dataGridViewRow.Cells["Priority"].Value.ToString();
                    int year = Convert.ToInt32(dataGridViewRow.Cells["Year"].Value);
                    int month = Convert.ToInt32(dataGridViewRow.Cells["Month"].Value);
                    int day = Convert.ToInt32(dataGridViewRow.Cells["Day"].Value);

                    string command = $"\'{description}\', \'{priority}\', 0, {year}, {month}, {day}";
                    client.AddRowsToDb(command, nameDataBases, nameTable);//віддали команду сервісу
                    RefreshdataGridView();
                    addRowForm.Close();//форма для додавання рядка вже не потрібна
                }
                else
                {
                    MessageBox.Show("Fill all empty fields and fields Year, Month and Day should be only numbers");
                }
            };
            addRowForm.ShowDialog();

        }

        public void OpenFormConnect()
        {
            ConnectToServerForm connectToServerForm = new ConnectToServerForm();

            //якщо на connectToServerForm нажали підключитися
            connectToServerForm.butConnect.Click += (senderConnectToServer, eConnectToServer) =>
            {
                try
                {
                    if (connectToServerForm.txtBxIP.Text != null &&
                        connectToServerForm.txtBxPort.Text != null &&
                        connectToServerForm.txtBoxNameDataBases != null &&
                        connectToServerForm.txtBoxNameTableDataBases != null)
                    {
                        {
                            client = new TaskOrganizerClient("BasicHttpBinding_ITaskOrganizer");
                            EndpointAddress endpointAddress = new EndpointAddress($"http://{connectToServerForm.txtBxIP.Text}:{connectToServerForm.txtBxPort.Text}//WCF_TaskOrganizer");
                            client.Endpoint.Address = endpointAddress;
                        }
                        {
                            nameDataBases = connectToServerForm.txtBoxNameDataBases.Text;
                            nameTable = connectToServerForm.txtBoxNameTableDataBases.Text;
                        }
                        client.SelectAllFromDb(nameDataBases, nameTable);//перевіримо чи можна вибрати дані
                        WorkWithDatabase.SelectAllToDataGridView(DataGridView1, client, nameDataBases, nameTable);//вибираємо всі дані
                        connectToServerForm.Close();//закриваємо форму для підключення
                    }
                    else { MessageBox.Show("Fill all empty fields"); }
                }
                catch (Exception ex) { MessageBox.Show("Error connecting.\nTry again"); }
            };

            //якщо невдалося підключитися і хочемо вийти нажимаємо butExit
            connectToServerForm.butExit.Click += (senderConnectToServer, eConnectToServer) =>
            {
                connectToServerForm.Close();
                Application.Exit();

            };
            connectToServerForm.ShowDialog();//показуємо форму для підключення
        }

        public void SaveChangesFromDataGridViewToDb()
        {
            client.SaveChangesToDb(WorkWithDataGridView.GetAllFromDataGridView(DataGridView1).ToArray(), nameDataBases, nameTable);
            RefreshdataGridView();
        }

        public void RefreshdataGridView()//оновити табличку з бази даних
        {
            try
            {
                DataGridView1.Rows.Clear();
                WorkWithDatabase.SelectAllToDataGridView(DataGridView1, client, nameDataBases, nameTable);
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }

        private void Form_ClientTaskOrganizer_Load(object sender, EventArgs e)
        {
            OpenFormConnect();
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            WorkWithDatabase.DeleteRowInDb(e, DataGridView1, client, nameDataBases, nameTable);
            RefreshdataGridView();
        }

        private void AddRowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddRowFromDataGridViewToDb();
        }

        private void SaveChangesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveChangesFromDataGridViewToDb();
        }
        
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            client.Close();
            Application.Exit();
        }

        private void RefreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RefreshdataGridView();
        }
    }
}
