using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using TaskOrganizer;

namespace WCF_TaskOrganizer
{
    static class Database
    {
        static public List<Task> SelectAllFromDb(string userLogin)//показати все що є в базі данних
        {
            List<Task> taskL = new List<Task>();
            SqlDataReader reader = null;
            DatabaseConnection.ConnectToDb();
            try
            {
                DatabaseConnection.comm.CommandText = $"SELECT * FROM dbo.{DatabaseConnection.configConnectDatabase.nameTableDatabase} WHERE ID_User = \'{userLogin}\' ORDER BY 'Year', 'Month', 'Day';";
                DatabaseConnection.comm.CommandType = CommandType.Text;
                reader = DatabaseConnection.comm.ExecuteReader();
                while (reader.Read())
                {
                    Task task = new Task(Convert.ToInt32(reader[0]), reader[2].ToString(), reader[3].ToString(), Convert.ToBoolean(reader[4]), Convert.ToInt32(reader[5]), Convert.ToInt32(reader[6]), Convert.ToInt32(reader[7]));
                    taskL.Add(task);
                }
                reader.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
            return taskL;
        }

        static public void DeleteRowInDb(int Id)//видалити рядок за ID
        {
            DatabaseConnection.ConnectToDb();
            try
            {
                DatabaseConnection.comm.CommandText = $"DELETE FROM dbo.{DatabaseConnection.configConnectDatabase.nameTableDatabase} WHERE Id = {Id};";
                DatabaseConnection.comm.CommandType = CommandType.Text;
                DatabaseConnection.comm.ExecuteNonQuery();
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }

        static public void AddRowsToDb(Task task)//додати рядок
        {
            DatabaseConnection.ConnectToDb();
            try
            {
                DatabaseConnection.comm.CommandText = $"INSERT INTO dbo.{DatabaseConnection.configConnectDatabase.nameTableDatabase} VALUES (\'{task.User}\', \'{task.Description}\', \'{task.Priority}\', 0, {task.Year}, {task.Month}, {task.Day});";
                DatabaseConnection.comm.CommandType = CommandType.Text;
                DatabaseConnection.comm.ExecuteNonQuery();
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }

        static public void SaveChangesToDb(List<Task> taskL)//зберегти все до БД/////доробити строку SET///////////////////////////////////////////////////////////////////
        {
            DatabaseConnection.ConnectToDb();
            try
            {
                foreach (Task task in taskL)
                {
                    DatabaseConnection.comm.CommandText = $"UPDATE dbo.{DatabaseConnection.configConnectDatabase.nameTableDatabase} SET Description = \'{task.Description}\', Priority = \'{task.Priority}\', Status = \'{task.Status}\', Year = {task.Year}, Month = {task.Month}, Day = {task.Day} WHERE ID = {task.Id};";
                    //DatabaseConnection.comm.CommandText = $"UPDATE dbo.{DatabaseConnection.configConnectDatabase.nameTableDatabase} SET \'{task.Description}\', \'{task.Priority}\', \'{task.Status}\', {task.Year}, {task.Month}, {task.Day} WHERE ID = {task.Id};";
                    DatabaseConnection.comm.CommandType = CommandType.Text;
                    DatabaseConnection.comm.ExecuteNonQuery();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }

        static public bool ConfirmUser(User user)//підтверджує зареєстрованого юзера
        {
            bool OK = false;
            SqlDataReader reader = null;
            DatabaseConnection.ConnectToDb();
            try
            {
                DatabaseConnection.comm.CommandText = $"SELECT * FROM dbo.{DatabaseConnection.configConnectDatabase.nameTableUserDatabase} WHERE Login = \'{user.UserLogin}\' AND Password = \'{user.UserPassword}\';";
                DatabaseConnection.comm.CommandType = CommandType.Text;
                reader = DatabaseConnection.comm.ExecuteReader();
                if (reader.Read())
                {
                    reader.Close();
                    return true;
                }
                else
                {
                    reader.Close();
                    return false;
                }
                
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); return false; }
        }

        static public bool AddUser(User user)
        {
            DatabaseConnection.ConnectToDb();
            try
            {
                DatabaseConnection.comm.CommandText = $"INSERT INTO dbo.{DatabaseConnection.configConnectDatabase.nameTableUserDatabase} VALUES (\'{user.UserLogin}\', \'{user.UserPassword}\');";
                DatabaseConnection.comm.CommandType = CommandType.Text;
                DatabaseConnection.comm.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); return false; }
            
        }
    }
}
