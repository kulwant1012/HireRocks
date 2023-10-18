using PS.Azure.Web.ServiceInterfaces;
using PS.Azure.Web.Services;
using PS.Azure.Web.Utils;
using PS.Data.Entities;
using PS.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Text;

namespace PS.Azure.Web
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public partial class PSService : IQSpacesService, ITasksService, IResourcesService, IDataEntryService, IInitializationService,
        IMediaElementService, IActivityVerificationService, IActivityOptimizationSystemService, IActivityOptimizationSystemWithWorksnapsService
    {

        #region Base service methods

        protected static OperationResult<T> TryInvoke<T>(Func<T> func)
        {
            OperationResult<T> operationResult;
            try
            {
                var result = func();
                operationResult = OperationResult<T>.Success(result);
            }
            catch (Exception exception)
            {
                operationResult = OperationResult<T>.Error(exception.Message);
            }

            return operationResult;
        }

        protected static OperationResult<T> TryInvoke<T>(Func<OperationResult<T>> func)
        {
            OperationResult<T> operationResult;
            try
            {
                return func();
            }
            catch (Exception exception)
            {
                operationResult = OperationResult<T>.Error(exception.Message);
            }

            return operationResult;
        }

        protected static OperationResult TryInvoke(Func<OperationResult> func)
        {
            try
            {
                return func();
            }
            catch (Exception exception)
            {
                return OperationResult.Error(exception.Message);
            }
        }

        protected static OperationResult TryInvoke(Action action)
        {
            OperationResult operationResult;
            try
            {
                action();
                operationResult = OperationResult.Success();
            }
            catch (Exception exception)
            {
                operationResult = OperationResult.Error(exception.Message);
            }

            return operationResult;
        }

        #endregion

        #region IQSpacesService implementation

        public OperationResult<QSpace> GetQSpaceById(string id)
        {
            QSpace group = null;

            try
            {
                group = _qSpaceRepository.GetById(id);
            }
            catch (Exception ex)
            {
                return OperationResult<QSpace>.Error(ex.Message);
            }

            return OperationResult<QSpace>.Success(group);
        }

        public OperationResult<ICollection<QSpace>> GetAllQSpaces()
        {
            ICollection<QSpace> qSpaces = null;

            try
            {
                qSpaces = _qSpaceRepository.GetAll();
            }
            catch (Exception ex)
            {
                return OperationResult<ICollection<QSpace>>.Error(ex.Message);
            }

            return OperationResult<ICollection<QSpace>>.Success(qSpaces);
        }

        public OperationResult InsertOrUpdate(QSpace qSpace)
        {
            try
            {
                _qSpaceRepository.InsertOrUpdate(qSpace);
            }
            catch (Exception ex)
            {
                return OperationResult.Error(ex.Message);
            }

            return OperationResult.Success();
        }

        public OperationResult DeleteQSpace(string id)
        {
            try
            {
                _qSpaceRepository.Delete(id);
            }
            catch (Exception ex)
            {
                return OperationResult.Error(ex.Message);
            }

            return OperationResult.Success();
        }
        #endregion

        #region ITasksService implementation
        public OperationResult<Task> GetTasksById(string id)
        {
            Task task = null;

            try
            {
                task = _taskRepository.GetById(id);
            }
            catch (Exception ex)
            {
                return OperationResult<Task>.Error(ex.Message);
            }

            return OperationResult<Task>.Success(task);
        }

        public OperationResult<ICollection<Task>> GetAllTasks()
        {
            ICollection<Task> tasks = null;

            try
            {
                tasks = _taskRepository.GetAll();
            }
            catch (Exception ex)
            {
                return OperationResult<ICollection<Task>>.Error(ex.Message);
            }

            return OperationResult<ICollection<Task>>.Success(tasks);
        }

        public OperationResult InsertOrUpdateTask(Task task)
        {
            try
            {
                _taskRepository.InsertOrUpdate(task);
            }
            catch (Exception ex)
            {
                return OperationResult.Error(ex.Message);
            }

            return OperationResult.Success();
        }

        public OperationResult DeleteTask(string id)
        {
            try
            {
                _taskRepository.Delete(id);
            }
            catch (Exception ex)
            {
                return OperationResult.Error(ex.Message);
            }

            return OperationResult.Success();
        }
        #endregion

        public OperationResult<Structure> GetStructureById(string id)
        {
            Structure structure = null;

            try
            {
                structure = _structureRepository.GetById(id);
            }
            catch (Exception ex)
            {
                return OperationResult<Structure>.Error(ex.Message);
            }

            return OperationResult<Structure>.Success(structure);
        }

        public OperationResult<ICollection<Structure>> GetAllStructures()
        {
            ICollection<Structure> structures = null;

            try
            {
                structures = _structureRepository.GetAll();
            }
            catch (Exception ex)
            {
                return OperationResult<ICollection<Structure>>.Error(ex.Message);
            }

            return OperationResult<ICollection<Structure>>.Success(structures);
        }

        public OperationResult InsertOrUpdateStructure(Structure structure)
        {
            try
            {
                if (structure.Id == null)
                {
                    structure.Sector = SectorType.Structure;
                    structure.Created = DateTime.UtcNow;
                    structure.CanProduceTasks = false;
                }
                _structureRepository.InsertOrUpdate(structure);
            }
            catch (Exception ex)
            {
                return OperationResult.Error(ex.Message);
            }

            return OperationResult.Success();
        }

        public OperationResult DeleteStructure(string id)
        {
            try
            {
                _structureRepository.Delete(id);
            }
            catch (Exception ex)
            {
                return OperationResult.Error(ex.Message);
            }

            return OperationResult.Success();
        }


    }
}
