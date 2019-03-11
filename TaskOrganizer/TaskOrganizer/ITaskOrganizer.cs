using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCF_TaskOrganizer
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени интерфейса "ITaskOrganizer" в коде и файле конфигурации.
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
        void SaveChangesToDb(string command, string nameDataBases, string nameTable);
    }
}
