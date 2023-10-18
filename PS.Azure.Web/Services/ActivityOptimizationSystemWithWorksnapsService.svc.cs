using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using PS.Azure.Web.Services;
using PS.Data.Entities.AOS.OTN_WorksnapsCommon;

namespace PS.Azure.Web
{
    public partial class PSService : IActivityOptimizationSystemWithWorksnapsService
    {

        public OperationResult AddOrUpdateOTNWorksnapsCommonUser(OTNWorksnapsCommonUser otnWorksnapsCommonUser)
        {
            return TryInvoke(() =>
            {
                if (string.IsNullOrEmpty(otnWorksnapsCommonUser.Id))
                    otnWorksnapsCommonUser.Id = Guid.NewGuid().ToString();
                _otnWorksnapsUserRepository.InsertOrUpdate(otnWorksnapsCommonUser);
            });
        }

        public OperationResult AddOrUpdateOTNWorksnapsActivity(OTNWorksnapsActivity otnWorksnapsActivity)
        {
            return TryInvoke(() =>
            {
                if (string.IsNullOrEmpty(otnWorksnapsActivity.Id))
                    otnWorksnapsActivity.Id = Guid.NewGuid().ToString();
                _otnWorksnapsActivityRepository.InsertOrUpdate(otnWorksnapsActivity);
            });
        }

        public OperationResult AddOrUpdateOTNWorksnapsWorkLog(OTNWorksnapsWorklog otnWorksnapsWorklog)
        {
            return TryInvoke(() =>
            {
                if (string.IsNullOrEmpty(otnWorksnapsWorklog.Id))
                    otnWorksnapsWorklog.Id = Guid.NewGuid().ToString();
                _otnWorksnapsWorkLogRepository.InsertOrUpdate(otnWorksnapsWorklog);
            });
        }

        public OperationResult AddOrUpdateOTNWorksnapsQSpace(OTNWorksnapsQSpace qSpace)
        {
            return TryInvoke(() =>
            {
                if (string.IsNullOrEmpty(qSpace.Id))
                    qSpace.Id = Guid.NewGuid().ToString();
                _otnWorksnapsQSpaceRepository.InsertOrUpdate(qSpace);
            });
        }

        public OperationResult AddOrUpdateOTNWorksnapsLastSyncDate(LastSyncDate lastSyncDate)
        {
            return TryInvoke(() =>
            {
                if (string.IsNullOrEmpty(lastSyncDate.Id))
                    lastSyncDate.Id = Guid.NewGuid().ToString();
                _otnWorksnapsLastSyncDateRepository.InsertOrUpdate(lastSyncDate);
            });
        }
    }
}
