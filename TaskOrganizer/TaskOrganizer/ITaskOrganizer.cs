using System.Collections.Generic;
using System.ServiceModel;
using TaskOrganizer;

namespace WCF_TaskOrganizer
{
    [ServiceContract]
    public interface ITaskOrganizer
    {
        [OperationContract]
        List<Task> SelectAllFromDb(string userLogin);

        [OperationContract]
        bool ConnectToDb();
        
        [OperationContract]
        void DisconnectFromDb();
        
        [OperationContract]
        void DeleteRowInDb(int Id);

        [OperationContract]
        void AddRowsToDb(Task task);

        [OperationContract]
        void SaveChangesToDb(List<Task> task);

        [OperationContract]
        bool ConfirmUser(User user);

        [OperationContract]
        bool AddUser(User user);
    }
}
