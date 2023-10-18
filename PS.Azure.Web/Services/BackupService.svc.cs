using PS.Azure.Web.Services;
using PS.Azure.Web.Utils;
using PS.Data.Entities;
using PS.Data.Repositories;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Task = System.Threading.Tasks.Task;

namespace PS.Azure.Web
{
    public partial class PSService : IBackupService
    {
        public PSService()
        {
            //InitializeRavenDb("AOSDataBase");
        }

        public OperationResult StartBackupTask(string backupTaskId)
        {
            

            return TryInvoke(() =>
                {
                    var backupTask = _backupTasksRepository.GetById(backupTaskId);
                    var backupAction = new BackupAction(backupTask.Id);
                    backupAction.StartTime = DateTime.UtcNow;
                    
                    // do backup by task settings
                    try
                    {
                        var connectionString = "DefaultEndpointsProtocol=https;AccountName={0};AccountKey={1}";
                        
                        var sourceConnectionString = string.Format(connectionString, 
                            backupTask.SourceStorageAccountName,
                            backupTask.SourceStorageAccountKey);                        
                        
                        var targetConnectionString = string.Format(connectionString,
                            backupTask.DestinationStorageAccountName,
                            backupTask.DestinationStorageAccountKey);

                        var sourceStorageAccount = CloudStorageAccount.Parse(sourceConnectionString);
                        var targetAccount = CloudStorageAccount.Parse(targetConnectionString);
                        
                        var sourceBlobClient = sourceStorageAccount.CreateCloudBlobClient();
                        var targetBlobClient = targetAccount.CreateCloudBlobClient();

                        var sourceContainer = sourceBlobClient.GetContainerReference(backupTask.SourceStorageContainer);
                        var targetContainer = targetBlobClient.GetContainerReference(backupTask.DestinationStorageContainer);

                        targetContainer.CreateIfNotExists();

                        foreach (IListBlobItem sourceBlobItem in sourceContainer.ListBlobs())
                        {
                            var sourceBlob = sourceContainer.GetBlockBlobReference(sourceBlobItem.Uri.Segments.Last());

                            var targetName = sourceBlob.Name + "_" + DateTime.UtcNow.ToString();
                            var targetBlob = targetContainer.GetBlockBlobReference(targetName);

                            var task = Task.Factory.FromAsync<string>(targetBlob.BeginStartCopyFromBlob(sourceBlob, null, null), targetBlob.EndStartCopyFromBlob);
                            task.ContinueWith((t) =>
                            {
                                if (!t.IsFaulted)
                                {
                                    while (targetBlob.CopyState.Status == CopyStatus.Pending)
                                    {                                        
                                        Thread.Sleep(500);
                                    }

                                    if (targetBlob.CopyState.Status == CopyStatus.Success)
                                    {
                                        backupAction.BlobsList.Add(targetBlob.Uri.ToString());
                                    }
                                    else
                                    {
                                        throw new Exception(targetBlob.Uri.ToString() + " " + targetBlob.CopyState.Status);
                                    }
                                }
                                else
                                {
                                    throw new Exception("Error: " + t.Exception);
                                }
                            }).Wait();

                            //targetBlob.BeginStartCopyFromBlob(sourceBlob);
                          
                        }
                    }
                    catch (Exception ex)
                    {
                        backupAction.Result.IsSuccess = false;
                        backupAction.Result.ErrorMessage = ex.Message;
                    }

                    backupAction.EndTime = DateTime.UtcNow;
                    backupAction.BackupTime = backupTask.BackupTime;
                    InsertOrUpdateBackupAction(backupAction);                    
                });
        }      

        public OperationResult<BackupTask> GetBackupTaskById(string backupTaskId)
        {
            return TryInvoke(() => _backupTasksRepository.GetById(backupTaskId));
        }

        public OperationResult<List<BackupTask>> GetAllBackupTasks()
        {            
            return TryInvoke(() => _backupTasksRepository.GetAll().OrderBy(x => x.Name).ThenBy(x => x.ModifyDate).ToList());
        }

        public OperationResult InsertOrUpdateBackupTask(BackupTask backupTask)
        {
            return TryInvoke(() =>
            {
                if (backupTask.Id == null)
                {
                    backupTask.Id = Guid.NewGuid().ToString();
                    backupTask.CreatedDate = DateTime.UtcNow;
                    backupTask.ModifyDate = backupTask.CreatedDate;
                }
                else
                {
                    backupTask.ModifyDate = DateTime.UtcNow;
                }

                backupTask.ModifyDate = DateTime.Now;
                _backupTasksRepository.InsertOrUpdate(backupTask);
            });
        }

        public OperationResult DeleteBackupTask(string backupTaskId)
        {
            return TryInvoke(() =>
            {               
                _backupTasksRepository.Delete(backupTaskId);
            });
        }



        public OperationResult<BackupAction> GetBackupActionById(string backupActionId)
        {
            return TryInvoke<BackupAction>(() =>
                {
                    var backupAction = _backupActionsRepository.GetById(backupActionId);
                    return backupAction;
                });
        }

        public OperationResult<List<BackupAction>> GetAllBackupActions()
        {
            return TryInvoke<List<BackupAction>>(() =>
                {
                    var backupActions =  _backupActionsRepository.GetAll().OrderByDescending(x => x.StartTime).ToList();
                    return backupActions;
                });
        }

        public OperationResult InsertOrUpdateBackupAction(BackupAction backupAction)
        {
            return TryInvoke(() => 
                {
                    if (backupAction.Id == null)
                        backupAction.Id = Guid.NewGuid().ToString();

                    _backupActionsRepository.InsertOrUpdate(backupAction);
                });
        }

        public OperationResult DeleteBackupAction(string backupActionId)
        {
            return TryInvoke(() => _backupActionsRepository.Delete(backupActionId));
        }

        public OperationResult DeleteAllBackupActions()
        {
            return TryInvoke(() => _backupActionsRepository.DeleteAll<BackupAction>());
        }

       

    }
}
