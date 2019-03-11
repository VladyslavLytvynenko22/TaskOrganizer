using ClientTaskOrganizer.RefServiceTaskOrganizer;
using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Linq;
using System.ServiceModel;
//using System.Text;
//using System.Threading.Tasks;
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

        public void RefreshdataGridView()//оновити табличку з бази даних
        {
            try
            {
                DataGridView1.Rows.Clear();
                SelectAllToDataGridView();
            }
            catch (Exception ex){ MessageBox.Show(ex.ToString());}
        }

        public void SelectAllToDataGridView()//вибрати всі значення з бази даних
        {
            try
            {
                RefServiceTaskOrganizer.Task[] task = client.SelectAllFromDb(nameDataBases, nameTable);//отримуэмо дані з бази даних
                for (int i = 0; i < task.Length; i++)
                {
                    //ID вставляємо в схований стовбец
                    DataGridView1.Rows.Add(task[i].Id, task[i].Status, task[i].Description, task[i].Priority, task[i].Year, task[i].Month, task[i].Day);
                }
            }
            catch (Exception ex){MessageBox.Show(ex.ToString());}
        }

        public void DeleteRowInDb(DataGridViewCellEventArgs e)//видалити рядок за індексом
        {
            try
            {
                if (DataGridView1.Columns[e.ColumnIndex] is DataGridViewImageColumn)//якщо клацнули на колонку delete
                {
                    //надсилаємо ID який треба видалити
                    //ID беремо з прихованого стовбця
                    client.DeleteRowInDb(Convert.ToInt32(DataGridView1.Rows[DataGridView1.CurrentCell.RowIndex].Cells["Id"].Value), nameDataBases, nameTable);
                    RefreshdataGridView();
                }
            }
            catch (Exception ex){MessageBox.Show(ex.ToString());}
        }
        
        private void Form_ClientTaskOrganizer_Load(object sender, EventArgs e)
        {
            ConnectToServerForm connectToServerForm = new ConnectToServerForm();
            
            bool isConnect = false;
            while (!isConnect)//показуємо форму connectToServerForm доки не буде успішне підключення
            {
                try
                {
                    //якщо на connectToServerForm нажали підключитися
                    connectToServerForm.butConnect.Click += (senderConnectToServer, eConnectToServer) =>
                    {
                        if (connectToServerForm.txtBxIP.Text != null && connectToServerForm.txtBxPort.Text != null && connectToServerForm.txtBoxNameDataBases != null && connectToServerForm.txtBoxNameTableDataBases != null)
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
                            SelectAllToDataGridView();//вибираємо всі дані
                            connectToServerForm.Close();//закриваємо форму для підключення
                            isConnect = true;//виходимо з циклу
                        }
                        else{ MessageBox.Show("Fill all empty fields");}
                    };
                    //якщо невдалося підключитися і хочемо вийти нажимаємо butExit
                    connectToServerForm.butExit.Click += (senderConnectToServer, eConnectToServer) =>
                    {
                        isConnect = true;//щоб вийшов з цилка
                        connectToServerForm.Close();
                        Application.Exit();
                        
                    };
                    connectToServerForm.ShowDialog();//показуємо форму для підключення
                }
                catch (Exception ex){ MessageBox.Show("Error connecting");}
            }
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DeleteRowInDb(e);
        }

        private void AddRowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                AddRowForm addRowForm = new AddRowForm();
                //якщо нажали ОК то перевіримо чи все ОК
                addRowForm.butOk.Click += (senderAddRow, eAddRow) =>
                 {
                     //щоб не пусто було
                     if (addRowForm.dataGridView1.Rows[0].Cells["Description"].Value != null &&
                        addRowForm.dataGridView1.Rows[0].Cells["Priority"].Value != null &&
                        addRowForm.dataGridView1.Rows[0].Cells["Year"].Value != null &&
                        addRowForm.dataGridView1.Rows[0].Cells["Month"].Value != null &&
                        addRowForm.dataGridView1.Rows[0].Cells["Day"].Value != null)
                     {
                         //зробимо змінні щоб зручніше записати в command
                         string description = addRowForm.dataGridView1.Rows[0].Cells["Description"].Value.ToString();
                         string priority = addRowForm.dataGridView1.Rows[0].Cells["Priority"].Value.ToString();
                         //перевіримо щоб були числа там де треба
                         if (int.TryParse(addRowForm.dataGridView1.Rows[0].Cells["Year"].Value.ToString(), out int year) &&
                             int.TryParse(addRowForm.dataGridView1.Rows[0].Cells["Month"].Value.ToString(), out int month) &&
                             int.TryParse(addRowForm.dataGridView1.Rows[0].Cells["Day"].Value.ToString(), out int day))
                         {
                             //створимо команду для запису до таблиці
                             string command = $"\'{description}\', \'{priority}\', 0, {year}, {month}, {day}";
                             client.AddRowsToDb(command, nameDataBases, nameTable);//віддали команду сервісу
                             addRowForm.Close();//форма для додавання рядка вже не потрібна
                             RefreshdataGridView();
                         }
                         else{ MessageBox.Show("Fields Year, Month, Day should be only numbers");}
                     }
                     else{ MessageBox.Show("Fill all empty fields");}
                 };
                addRowForm.ShowDialog();
            }
            catch (Exception ex){ MessageBox.Show(ex.ToString());}
        }

        private void SaveChangesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                RefServiceTaskOrganizer.Task task = new RefServiceTaskOrganizer.Task();
                for (int i = 0; i < DataGridView1.RowCount; i++)
                {
                    task.Id = Convert.ToInt32(DataGridView1.Rows[i].Cells["Id"].Value);
                    task.Description = DataGridView1.Rows[i].Cells["Description"].Value.ToString();
                    task.Priority = DataGridView1.Rows[i].Cells["Priority"].Value.ToString();
                    task.Status = Convert.ToBoolean(DataGridView1.Rows[i].Cells["Status"].Value);
                    task.Year = Convert.ToInt32(DataGridView1.Rows[i].Cells["Year"].Value);
                    task.Month = Convert.ToInt32(DataGridView1.Rows[i].Cells["Month"].Value);
                    task.Day = Convert.ToInt32(DataGridView1.Rows[i].Cells["Day"].Value);
                    //беремо всі рядки попорядку і оновлюємо таблицю в БД
                    client.SaveChangesToDb($"UPDATE dbo.TableOrganizer SET Description = \'{task.Description}\', Priority = \'{task.Priority}\', Status = \'{task.Status}\', Year = {task.Year}, Month = {task.Month}, Day = {task.Day} WHERE ID = {task.Id};", nameDataBases, nameTable);
                }
                RefreshdataGridView();
            }
            catch (Exception ex){ MessageBox.Show(ex.ToString()); }
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
