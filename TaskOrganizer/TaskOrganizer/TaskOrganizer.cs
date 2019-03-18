using System.Collections.Generic;

namespace WCF_TaskOrganizer
{
    public class WCF_TaskOrganizer : ITaskOrganizer
    {
        void ITaskOrganizer.AddRowsToDb(string command, string nameDataBases, string nameTable)
        {
            Database.AddRowsToDb(command, nameDataBases, nameTable);
        }

        bool ITaskOrganizer.ConnectToDb(string nameDataBases, string nameTable)
        {
            return DatabaseConnection.ConnectToDb(nameDataBases, nameTable);
        }

        void ITaskOrganizer.DeleteRowInDb(int id, string nameDataBases, string nameTable)
        {
            Database.DeleteRowInDb(id, nameDataBases, nameTable);
        }

        void ITaskOrganizer.DisconnectFromDb()
        {
            DatabaseConnection.DisconnectFromDb();
        }

        void ITaskOrganizer.SaveChangesToDb(List<Task> task, string nameDataBases, string nameTable)
        {
            Database.SaveChangesToDb(task, nameDataBases, nameTable);
        }

        List<Task> ITaskOrganizer.SelectAllFromDb(string nameDataBases, string nameTable)
        {
            return Database.SelectAllFromDb(nameDataBases, nameTable);
        }
    }
}
