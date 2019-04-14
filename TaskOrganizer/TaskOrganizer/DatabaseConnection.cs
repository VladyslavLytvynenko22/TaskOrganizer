using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Windows.Forms;
using TaskOrganizer;

namespace WCF_TaskOrganizer
{
    static class DatabaseConnection
    {
        static internal SqlConnection conn;
        static internal SqlCommand comm;
        static internal ConfigConnectDatabase configConnectDatabase = new ConfigConnectDatabase();
        static public bool GetNameDatabaseAndTable()//отримати дані з файла для підключення до БД
        {
            using (StreamReader sw = new StreamReader("ConfigConnectDatabase.txt"))
            {
                configConnectDatabase.nameServer = sw.ReadLine();
                configConnectDatabase.nameDatabase = sw.ReadLine();
                configConnectDatabase.nameTableDatabase = sw.ReadLine();
            }

            return true;
        }

        static internal bool ConnectToDb()//підключення до бази данних
        {
            GetNameDatabaseAndTable();
            String hostName = Dns.GetHostName();
            SqlConnectionStringBuilder connStringBuilder;
            connStringBuilder = new SqlConnectionStringBuilder
            {
                DataSource = $"{hostName}\\{configConnectDatabase.nameServer}",//тут задаємо назву компа і назву сервера SQL
                InitialCatalog = configConnectDatabase.nameDatabase,//тут назва БД
                Encrypt = true,
                TrustServerCertificate = true,
                ConnectTimeout = 30,
                AsynchronousProcessing = true,
                MultipleActiveResultSets = true,
                IntegratedSecurity = true
            };

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
                MessageBox.Show("Error disconnect from databases!");
            }
        }
    }
}
