using ClientTaskOrganizer.ServiceReference1;
using System;
using System.Windows.Forms;

namespace ClientTaskOrganizer
{
    static class WorkWithDatabase
    {
        static internal TaskOrganizerClient client;
        static public void SelectAllToDataGridView(ref DataGridView DataGridView1)//вибрати всі значення з бази даних
        {
            try
            {
                Task[] task = client.SelectAllFromDb();//отримуэмо дані з бази даних
                for (int i = 0; i < task.Length; i++)
                {
                    //ID вставляємо в схований стовбец
                    DataGridView1.Rows.Add(task[i].Id, task[i].Status, task[i].Description, task[i].Priority, task[i].Year, task[i].Month, task[i].Day);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }

        static public void DeleteRowInDb(DataGridViewCellEventArgs e, DataGridView DataGridView1)//видалити рядок за індексом
        {
            try
            {
                if (DataGridView1.Columns[e.ColumnIndex] is DataGridViewImageColumn)//якщо клацнули на колонку delete
                {
                    //надсилаємо ID який треба видалити
                    //ID беремо з прихованого стовбця
                    client.DeleteRowInDb(Convert.ToInt32(DataGridView1.Rows[DataGridView1.CurrentCell.RowIndex].Cells["Id"].Value));
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }

    }
}
