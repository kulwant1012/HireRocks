using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using PS.Data.Entities.AVS;

namespace PS.Azure.Web.Services
{
    [ServiceContract]
    public interface IActivityVerificationService
    {
         [OperationContract]
        OperationResult DeleteCapturedInformation(string id);

        [OperationContract]
        OperationResult<ActivityCapture> AddCapturedInformation(ActivityCapture activityCapture);

        [OperationContract]
        OperationResult<ICollection<ActivityCapture>> GetActivityCaptures(DateTime? startDate, DateTime? endDate, string activityUserId);

        [OperationContract]
        OperationResult<MatchedKeyword> AddOrUpdateMatchedKeyword(MatchedKeyword matchedKeyword);

        [OperationContract]
        OperationResult<ICollection<MatchedKeyword>> GetMatchedKeywordByIds(string[] matchedKeywordIds);

        [OperationContract]
        OperationResult UpdateVerificationStatus(string entityId, VerificationStatus verificationStatus, bool isCaptureAcceptanceChanged);

        [OperationContract]
        OperationResult<ICollection<ActivityCapture>> GetActivityCapturesByActivityId(string activityId);
    }
}
