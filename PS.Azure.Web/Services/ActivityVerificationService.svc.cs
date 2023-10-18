using PS.Data.Entities.AVS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using PS.Azure.Web.Services;

namespace PS.Azure.Web
{
    public partial class PSService : IActivityVerificationService
    {
        public OperationResult<ActivityCapture> AddCapturedInformation(ActivityCapture activityCapture)
        {
            return TryInvoke(() =>
            {
                if (string.IsNullOrEmpty(activityCapture.Id))
                    activityCapture.Id = Guid.NewGuid().ToString();
                _activityCaptureRepository.InsertOrUpdate(activityCapture);
                return activityCapture;
            });
        }

        public OperationResult DeleteCapturedInformation(string id)
        {
            return TryInvoke(() => _activityCaptureRepository.Delete(id));
        }

        public OperationResult<ICollection<Data.Entities.AVS.ActivityCapture>> GetActivityCaptures(DateTime? startDate, DateTime? endDate, string activityUserId)
        {
            return TryInvoke(() =>
            {
                if (!startDate.HasValue && !endDate.HasValue)
                    return _activityCaptureRepository.Search(x => x.ActivityUserID == activityUserId);

                if (!startDate.HasValue && endDate.HasValue)
                    return _activityCaptureRepository.Search(x => x.ActivityUserID == activityUserId && x.CaptureDateTime <= endDate);

                if (startDate.HasValue && !endDate.HasValue)
                    return _activityCaptureRepository.Search(x => x.ActivityUserID == activityUserId && x.CaptureDateTime >= startDate);

                if (startDate.HasValue && endDate.HasValue)
                    return _activityCaptureRepository.Search(x => x.ActivityUserID == activityUserId && x.CaptureDateTime >= startDate && x.CaptureDateTime <= endDate);

                return null;
            });
        }

        public OperationResult<MatchedKeyword> AddOrUpdateMatchedKeyword(MatchedKeyword matchedKeyword)
        {
            return TryInvoke<MatchedKeyword>(() => _matchedKeywordRepository.AddOrUpdateMatchedKeyword(matchedKeyword));
        }

        public OperationResult<ICollection<MatchedKeyword>> GetMatchedKeywordByIds(string[] matchedKeywordIds)
        {
            return TryInvoke(() =>
            {
                return _matchedKeywordRepository.GetMatchedKeywordIds(matchedKeywordIds);
            });
        }

        public OperationResult UpdateVerificationStatus(string entityId, VerificationStatus verificationStatus, bool isCaptureAcceptanceChanged)
        {
            return TryInvoke(() => _activityCaptureRepository.UpdateVerificationStatus(entityId, verificationStatus, isCaptureAcceptanceChanged));
        }
        
        public OperationResult<ICollection<ActivityCapture>> GetActivityCapturesByActivityId(string activityId)
        {
            return TryInvoke(()=>_activityCaptureRepository.GetActivityCapturesByActivityId(activityId));
        }
    }
}
