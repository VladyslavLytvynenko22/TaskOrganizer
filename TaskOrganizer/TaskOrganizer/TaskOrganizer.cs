using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Net;
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
        
        public bool ConnectToDb(string nameDataBases, string nameTable)//підключення до бази данних
        {
            try
            {
                String hostName = Dns.GetHostName();
                SqlConnectionStringBuilder connStringBuilder;
                connStringBuilder = new SqlConnectionStringBuilder();//в задумах зробити налаштування до підключення БД в інтерфейсі
                connStringBuilder.DataSource = $"{hostName}\\{nameDataBases}";//тут міняємо назву компа і назву сервера SQL
                connStringBuilder.InitialCatalog = nameTable;//тут назва таблички в БД
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
        }

        public void DisconnectFromDb()//відключення від бази данних
        {
            conn.Close();
        }
        
        public List<Task> SelectAllFromDb(string nameDataBases, string nameTable)//показати все що є в базі данних
        {
            List<Task> taskL = new List<Task>();
            SqlDataReader reader = null;
            ConnectToDb(nameDataBases, nameTable);
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
        }

        public void DeleteRowInDb(int Id, string nameDataBases, string nameTable)
        {
            ConnectToDb(nameDataBases, nameTable);
            try
            {
                comm.CommandText = $"DELETE FROM dbo.TableOrganizer WHERE Id = {Id};";
                comm.CommandType = CommandType.Text;
                comm.ExecuteNonQuery();
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }

        public void AddRowsToDb(string command, string nameDataBases, string nameTable)
        {
            ConnectToDb(nameDataBases, nameTable);
            try
            {
                comm.CommandText = $"INSERT INTO dbo.TableOrganizer VALUES ({command});";
                comm.CommandType = CommandType.Text;
                comm.ExecuteNonQuery();
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }

        public void SaveChangesToDb(string command, string nameDataBases, string nameTable)
        {
            ConnectToDb(nameDataBases, nameTable);
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
