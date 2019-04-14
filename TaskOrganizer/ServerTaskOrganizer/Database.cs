using System.IO;
using System.ServiceModel;
using System.Windows.Forms;
using TaskOrganizer;

namespace ServerTaskOrganizer
{
    static class Database
    {
        public static bool SaveConfigConnectDatabase(ConfigConnectDatabase configConnectDatabase)
        {
            using (StreamWriter sw = new StreamWriter("ConfigConnectDatabase.txt", false, System.Text.Encoding.Default))
            {
                sw.WriteLine(configConnectDatabase.nameServer);
                sw.WriteLine(configConnectDatabase.nameDatabase);
                sw.WriteLine(configConnectDatabase.nameTableDatabase);
                sw.WriteLine(configConnectDatabase.nameTableUserDatabase);
            }
            return true;
        }
    }
}
