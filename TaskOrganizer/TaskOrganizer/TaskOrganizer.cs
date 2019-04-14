using System.Collections.Generic;
using TaskOrganizer;

namespace WCF_TaskOrganizer
{
    public class WCF_TaskOrganizer : ITaskOrganizer
    {
        public bool AddUser(User user)
        {
            return ClassUser.RegistrationUser(user);
        }

        void ITaskOrganizer.AddRowsToDb(Task task)
        {
            Database.AddRowsToDb(task);
        }

        bool ITaskOrganizer.ConfirmUser(User user)
        {
            return ClassUser.ConfirmUser(user);
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

        List<Task> ITaskOrganizer.SelectAllFromDb(string userLogin)
        {
            return Database.SelectAllFromDb(userLogin);
        }
    }
}
