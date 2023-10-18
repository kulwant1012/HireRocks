using PS.Data.Entities;
using PS.Data.Entities.Money;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;

namespace PS.Azure.Web.Services
{
    [ServiceContract]
    public interface IBackupService
    {
        [OperationContract]
        OperationResult StartBackupTask(string backupTaskId);

        [OperationContract]
        OperationResult<BackupTask> GetBackupTaskById(string backupTaskId);

        [OperationContract]
        OperationResult<List<BackupTask>> GetAllBackupTasks();

        [OperationContract]
        OperationResult InsertOrUpdateBackupTask(BackupTask backupTask);

        [OperationContract]
        OperationResult DeleteBackupTask(string id);

        [OperationContract]
        OperationResult<BackupAction> GetBackupActionById(string backupActionId);

        [OperationContract]
        OperationResult<List<BackupAction>> GetAllBackupActions();

        [OperationContract]
        OperationResult InsertOrUpdateBackupAction(BackupAction backupAction);

        [OperationContract]
        OperationResult DeleteBackupAction(string backupActionId);

        [OperationContract]
        OperationResult DeleteAllBackupActions();
    }
}