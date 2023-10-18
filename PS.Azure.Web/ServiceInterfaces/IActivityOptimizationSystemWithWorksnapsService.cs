using PS.Data.Entities.AOS.OTN_WorksnapsCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace PS.Azure.Web.Services
{
    [ServiceContract]
    public interface IActivityOptimizationSystemWithWorksnapsService
    {
        [OperationContract]
        OperationResult AddOrUpdateOTNWorksnapsCommonUser(OTNWorksnapsCommonUser otnWorksnapsCommonUser);

        [OperationContract]
        OperationResult AddOrUpdateOTNWorksnapsActivity(OTNWorksnapsActivity otnWorksnapsActivity);

        [OperationContract]
        OperationResult AddOrUpdateOTNWorksnapsWorkLog(OTNWorksnapsWorklog otnWorksnapsWorklog);

        [OperationContract]
        OperationResult AddOrUpdateOTNWorksnapsQSpace(OTNWorksnapsQSpace qSpace);

        [OperationContract]
        OperationResult AddOrUpdateOTNWorksnapsLastSyncDate(LastSyncDate lastSyncDate);
    }
}
