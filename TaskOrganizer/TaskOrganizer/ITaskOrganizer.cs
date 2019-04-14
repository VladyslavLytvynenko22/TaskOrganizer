using System.Collections.Generic;
using System.ServiceModel;

namespace WCF_TaskOrganizer
{
    [ServiceContract]
    public interface ITaskOrganizer
    {
        [OperationContract]
        List<Task> SelectAllFromDb();

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
    }
}
