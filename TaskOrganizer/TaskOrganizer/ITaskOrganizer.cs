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
        List<Task> SelectAllFromDb();

        [OperationContract]
        bool ConnectToDb();

        [OperationContract]
        void DisconnectFromDb();

        [OperationContract]
        void DeleteRowInDb(int Id);

        [OperationContract]
        void AddRowsToDb(string command);

        [OperationContract]
        void SaveChangesToDb(string command);
    }
}
