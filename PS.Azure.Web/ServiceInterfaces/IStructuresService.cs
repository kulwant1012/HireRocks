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
    public interface IStructuresService
    {
        [OperationContract]
        OperationResult<Structure> GetStructureById(string id);

        [OperationContract]
        OperationResult<ICollection<Structure>> GetAllStructures();

        [OperationContract]
        OperationResult InsertOrUpdateStructure(Structure structure);

        [OperationContract]
        OperationResult DeleteStructure(string id);
    }
}