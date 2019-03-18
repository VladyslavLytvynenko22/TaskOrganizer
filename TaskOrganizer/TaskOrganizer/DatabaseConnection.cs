using System;
using System.Data.SqlClient;
using System.Net;
using System.Windows.Forms;

namespace WCF_TaskOrganizer
{
    static class DatabaseConnection
    {
        static internal SqlConnection conn;
        static internal SqlCommand comm;
        static internal bool ConnectToDb(string nameDataBases, string nameTable)//підключення до бази данних
        {
            String hostName = Dns.GetHostName();
            SqlConnectionStringBuilder connStringBuilder;
            connStringBuilder = new SqlConnectionStringBuilder();
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
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error connect to databases");
                return false;
            }
            return true;
        }

        static public void DisconnectFromDb()//відключення від бази данних
        {
            try
            {
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error disconnect from databases");
            }
        }
    }
}
