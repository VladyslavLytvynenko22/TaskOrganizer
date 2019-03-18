using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ClientTaskOrganizer.RefServiceTaskOrganizer;

namespace ClientTaskOrganizer
{
    static class WorkWithDataGridView
    {
        static public List<Task> GetAllFromDataGridView(DataGridView DataGridView1)
        {
            List<Task> taskL = new List<Task>();
            Task task = new Task();
            for (int i = 0; i < DataGridView1.RowCount; i++)
            {
                task.Id = Convert.ToInt32(DataGridView1.Rows[i].Cells["Id"].Value);
                task.Description = DataGridView1.Rows[i].Cells["Description"].Value.ToString();
                task.Priority = DataGridView1.Rows[i].Cells["Priority"].Value.ToString();
                task.Status = Convert.ToBoolean(DataGridView1.Rows[i].Cells["Status"].Value);
                task.Year = Convert.ToInt32(DataGridView1.Rows[i].Cells["Year"].Value);
                task.Month = Convert.ToInt32(DataGridView1.Rows[i].Cells["Month"].Value);
                task.Day = Convert.ToInt32(DataGridView1.Rows[i].Cells["Day"].Value);
                taskL.Add(task);
            }

            return taskL;
        }

        static public bool CheckDataGridViewRow(DataGridView dataGridView)
        {
            foreach (DataGridViewRow dataGridViewRow in dataGridView.Rows)
            {
                if (dataGridViewRow.Cells["Description"].Value == null ||
                   dataGridViewRow.Cells["Priority"].Value == null ||
                   dataGridViewRow.Cells["Year"].Value == null ||
                   dataGridViewRow.Cells["Month"].Value == null ||
                   dataGridViewRow.Cells["Day"].Value == null ||
                   !int.TryParse(dataGridViewRow.Cells["Year"].Value.ToString(), out int year) ||
                   !int.TryParse(dataGridViewRow.Cells["Month"].Value.ToString(), out int month) ||
                   !int.TryParse(dataGridViewRow.Cells["Day"].Value.ToString(), out int day))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
