﻿
namespace TaskOrganizer
{
    public class ConfigConnectDatabase
    {
        public string nameServer { get; set; }
        public string nameDatabase { get; set; }
        public string nameTableDatabase { get; set; }
        public string nameTableUserDatabase { get; set; }

        public ConfigConnectDatabase() { }

        public ConfigConnectDatabase(string nameServer , string nameDatabase, string nameTableDatabase, string nameTableUserDatabase)
        {
            this.nameServer = nameServer;
            this.nameDatabase = nameDatabase;
            this.nameTableDatabase = nameTableDatabase;
            this.nameTableUserDatabase = nameTableUserDatabase;
        }

    }
}
