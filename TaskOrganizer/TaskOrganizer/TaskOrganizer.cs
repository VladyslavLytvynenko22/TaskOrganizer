using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
//using System.Linq;
//using System.Runtime.Serialization;
//using System.ServiceModel;
//using System.Text;
using System.Windows.Forms;

namespace WCF_TaskOrganizer
{
    public class WCF_TaskOrganizer : ITaskOrganizer
    {
        SqlConnection conn;
        SqlCommand comm;
        

        public bool ConnectToDb()
        {
            try
            {
                //connStringBuilder.DataSource = $"G0LDING\\SQLEXPRESS";
                //connStringBuilder.InitialCatalog = "DbOrganizer";
                SqlConnectionStringBuilder connStringBuilder;
                connStringBuilder = new SqlConnectionStringBuilder();//в задумах зробити налаштування до підключення БД в інтерфейсі
                connStringBuilder.DataSource = "G0LDING\\SQLEXPRESS";//тут міняємо назву компа і назву сервера SQL
                connStringBuilder.InitialCatalog = "DbOrganizer";//тут назва таблички в БД
                connStringBuilder.Encrypt = true;
                connStringBuilder.TrustServerCertificate = true;
                connStringBuilder.ConnectTimeout = 30;
                connStringBuilder.AsynchronousProcessing = true;
                connStringBuilder.MultipleActiveResultSets = true;
                connStringBuilder.IntegratedSecurity = true;

                conn = new SqlConnection(connStringBuilder.ToString());
                comm = conn.CreateCommand();
                conn.Open();
                return true;
            }
            catch (Exception ex){MessageBox.Show(ex.ToString());}
            return false;
        }//підключення до бази данних

        public void DisconnectFromDb()
        {
            conn.Close();
        }//відключення від бази данних
        
        public List<Task> SelectAllFromDb()
        {
            List<Task> taskL = new List<Task>();
            SqlDataReader reader = null;
            ConnectToDb();
            try
            {
                comm.CommandText = "SELECT * FROM dbo.TableOrganizer ORDER BY 'Year', 'Month', 'Day';";
                comm.CommandType = CommandType.Text;
                reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    Task task = new Task(Convert.ToInt32(reader[0]), reader[1].ToString(), reader[2].ToString(), Convert.ToBoolean(reader[3]), Convert.ToInt32(reader[4]), Convert.ToInt32(reader[5]), Convert.ToInt32(reader[6]));
                    taskL.Add(task);
                }
                reader.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
            return taskL;
        }//показати все що є в базі данних

        public void DeleteRowInDb(int Id)
        {
            ConnectToDb();
            try
            {
                comm.CommandText = $"DELETE FROM dbo.TableOrganizer WHERE Id = {Id};";
                comm.CommandType = CommandType.Text;
                comm.ExecuteNonQuery();
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }

        public void AddRowsToDb(string command)
        {
            ConnectToDb();
            try
            {
                comm.CommandText = $"INSERT INTO dbo.TableOrganizer VALUES ({command});";
                comm.CommandType = CommandType.Text;
                comm.ExecuteNonQuery();
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }

        public void SaveChangesToDb(string command)
        {
            ConnectToDb();
            try
            {
                comm.CommandText = command;
                comm.CommandType = CommandType.Text;
                comm.ExecuteNonQuery();
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }
    }
    public class Task
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Priority { get; set; }
        public bool Status { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }

        public Task() { }
        public Task(int Id, string Description, string Priority, bool Status, int Year, int Month, int Day)
        {
            this.Id = Id;
            this.Description = Description;
            this.Priority = Priority;
            this.Status = Status;
            this.Year = Year;
            this.Month = Month;
            this.Day = Day;
        }
    }
}
