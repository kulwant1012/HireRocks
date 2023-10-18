using PS.Data.Entities;
using Raven.Client.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;

namespace PS.Azure.Web.Services
{
    [ServiceContract]
    public interface ITasksService
    {
        [OperationContract]
        OperationResult<Task> GetTasksById(string id);

        [OperationContract]
        OperationResult<ICollection<Task>> GetAllTasks();

        [OperationContract]
        OperationResult InsertOrUpdateTask(Task task);        

        [OperationContract]
        OperationResult DeleteTask(string id);

    }
}