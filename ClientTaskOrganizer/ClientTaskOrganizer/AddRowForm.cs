using System;
using System.Windows.Forms;
using ClientTaskOrganizer.ServiceReference1;

namespace ClientTaskOrganizer
{
    public partial class AddRowForm : Form
    {
        static public bool AddRowOK = false;
        public AddRowForm()
        {
            InitializeComponent();
        }

        private void AddRowForm_Load(object sender, EventArgs e)
        {
            dataGridView1.Rows.Add();
        }

        public void butOk_Click(object sender, EventArgs e)
        {
            //DataGridView dataGridView = dataGridView1;
            //DataGridViewRow dataGridViewRow = dataGridView1.Rows[0];
            if (WorkWithDataGridView.CheckDataGridViewRow(dataGridView1))//якщо заповнено правильно
            {

                Task task = new Task();//(description, priority, false, year, month, day);
                task.Description = dataGridView1.Rows[0].Cells["Description"].Value.ToString();
                task.Priority = dataGridView1.Rows[0].Cells["Priority"].Value.ToString();
                task.Status = false;
                task.Year = Convert.ToInt32(dataGridView1.Rows[0].Cells["Year"].Value);
                task.Month = Convert.ToInt32(dataGridView1.Rows[0].Cells["Month"].Value);
                task.Day = Convert.ToInt32(dataGridView1.Rows[0].Cells["Day"].Value);
                WorkWithDatabase.client.AddRowsToDb(task);//віддали данні сервісу
                //WorkWithDatabase.RefreshdataGridView();
                this.Close();//форма для додавання рядка вже не потрібна
                AddRowOK = true;
            }
            else
            {
                MessageBox.Show("Fill all empty fields and fields Year, Month and Day should be only numbers");
            }
        }
    }
}
