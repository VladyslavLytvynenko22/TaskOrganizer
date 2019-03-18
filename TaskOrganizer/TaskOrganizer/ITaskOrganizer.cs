using System.Collections.Generic;
using System.ServiceModel;

namespace WCF_TaskOrganizer
{
    [ServiceContract]
    public interface ITaskOrganizer
    {
        [OperationContract]
        List<Task> SelectAllFromDb(string nameDataBases, string nameTable);

        [OperationContract]
        bool ConnectToDb(string nameDataBases, string nameTable);

        [OperationContract]
        void DisconnectFromDb();

        [OperationContract]
        void DeleteRowInDb(int Id, string nameDataBases, string nameTable);

        [OperationContract]
        void AddRowsToDb(string command, string nameDataBases, string nameTable);

        [OperationContract]
        void SaveChangesToDb(List<Task> task, string nameDataBases, string nameTable);
    }
}
