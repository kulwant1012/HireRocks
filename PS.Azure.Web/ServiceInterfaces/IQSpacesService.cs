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
    public interface IQSpacesService
    {
        //[OperationContract]
        //OperationResult<ICollection<QSpace>> GetQSpacesBySectorType(SectorType sectorType);

        //[OperationContract]
        //OperationResult<ICollection<QSpace>> GetGroupsByEnergyLevel(EnergyLevel energyLevel);

        //[OperationContract, WebInvoke(BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        //OperationResult<ICollection<Group>> GetGroupsBySectorTypeAndEnergyLevel(SectorType sectorType, EnergyLevel energyLevel);

        [OperationContract]
        OperationResult<QSpace> GetQSpaceById(string id);

        [OperationContract]
        OperationResult<ICollection<QSpace>> GetAllQSpaces();

        [OperationContract]
        OperationResult InsertOrUpdate(QSpace qSpace);        

        [OperationContract]
        OperationResult DeleteQSpace(string id);
    }
}