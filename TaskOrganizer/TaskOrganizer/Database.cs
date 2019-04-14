using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WCF_TaskOrganizer
{
    static class Database
    {
        static public List<Task> SelectAllFromDb()//показати все що є в базі данних
        {
            List<Task> taskL = new List<Task>();
            SqlDataReader reader = null;
            DatabaseConnection.ConnectToDb();
            try
            {
                DatabaseConnection.comm.CommandText = $"SELECT * FROM dbo.{DatabaseConnection.configConnectDatabase.nameTableDatabase} ORDER BY 'Year', 'Month', 'Day';";
                DatabaseConnection.comm.CommandType = CommandType.Text;
                reader = DatabaseConnection.comm.ExecuteReader();
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
                DatabaseConnection.comm.CommandText = $"INSERT INTO dbo.{DatabaseConnection.configConnectDatabase.nameTableDatabase} VALUES (\'{task.Description}\', \'{task.Priority}\', 0, {task.Year}, {task.Month}, {task.Day});";
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
    }
}
