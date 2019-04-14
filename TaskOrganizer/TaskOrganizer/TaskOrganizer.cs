using System.Collections.Generic;
using TaskOrganizer;

namespace WCF_TaskOrganizer
{
    public class WCF_TaskOrganizer : ITaskOrganizer
    {
        void ITaskOrganizer.AddRowsToDb(Task task)
        {
            Database.AddRowsToDb(task);
        }

        bool ITaskOrganizer.ConnectToDb()
        {
            return DatabaseConnection.ConnectToDb();
        }

        void ITaskOrganizer.DeleteRowInDb(int id)
        {
            Database.DeleteRowInDb(id);
        }

        void ITaskOrganizer.DisconnectFromDb()
        {
            DatabaseConnection.DisconnectFromDb();
        }
        
        void ITaskOrganizer.SaveChangesToDb(List<Task> task)
        {
            Database.SaveChangesToDb(task);
        }

        List<Task> ITaskOrganizer.SelectAllFromDb()
        {
            return Database.SelectAllFromDb();
        }
    }
}
