using System;
using System.Windows.Forms;

namespace ClientTaskOrganizer
{
    public partial class Form_ClientTaskOrganizer : Form
    {
        public Form_ClientTaskOrganizer()
        {
            InitializeComponent();
        }
        
        public void AddRowFromDataGridViewToDb()
        {
            AddRowForm addRowForm = new AddRowForm();
            
            addRowForm.ShowDialog();
            if (AddRowForm.AddRowOK)
            {
                DataGridView1.Rows.Clear();
                WorkWithDatabase.SelectAllToDataGridView(ref DataGridView1);
            }

        }

        public void OpenFormConnect()
        {
            ConnectToServerForm connectToServerForm = new ConnectToServerForm();
            
            connectToServerForm.ShowDialog();//показуємо форму для підключення
            if (ConnectToServerForm.ConnectOK)
            {
                connectToServerForm.Close();
                WorkWithDatabase.SelectAllToDataGridView(ref DataGridView1);//вибираємо всі дані
            }
            else
            {
                connectToServerForm.Close();
                Application.Exit();
            }
        }

        public void SaveChangesFromDataGridViewToDb()
        {
            WorkWithDatabase.client.SaveChangesToDb(WorkWithDataGridView.GetAllFromDataGridView(DataGridView1).ToArray());
            RefreshdataGridView();
        }

        public void RefreshdataGridView()//оновити табличку з бази даних
        {
            try
            {
                DataGridView1.Rows.Clear();
                WorkWithDatabase.SelectAllToDataGridView(ref DataGridView1);
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }

        private void Form_ClientTaskOrganizer_Load(object sender, EventArgs e)
        {
            OpenFormConnect();
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            WorkWithDatabase.DeleteRowInDb(e, DataGridView1);
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
            WorkWithDatabase.client.Close();
            Application.Exit();
        }

        private void RefreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RefreshdataGridView();
        }
    }
}
