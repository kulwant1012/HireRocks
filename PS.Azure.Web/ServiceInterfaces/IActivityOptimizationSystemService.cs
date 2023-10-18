using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Linq.Expressions;

using PS.Data.Entities.AOS;
using PS.Data.Entities.AOS.Common;

namespace PS.Azure.Web.Services
{
    [ServiceContract]
    public interface IActivityOptimizationSystemService
    {
        [OperationContract]
        OperationResult<ActivityComposition> AddOrUpdateActivityComposition(ActivityComposition activityComposition);

        [OperationContract]
        OperationResult<User> AddOrUpdateUser(User user);

        [OperationContract]
        OperationResult<AOSQSpace> AddOrUpdateQSpace(AOSQSpace aosQSpace);

        [OperationContract]
        OperationResult<Activity> AddOrUpdateActivity(Activity activity);

        [OperationContract]
        OperationResult<ActivityStatus> AddOrUpdateActivityStatus(ActivityStatus activityStatus);

        [OperationContract]
        OperationResult<ActivityUser> AddOrUpdateActivityUser(ActivityUser activityUser, bool isAssignedToChanged);

        [OperationContract]
        OperationResult<ICollection<User>> GetUser();

        [OperationContract]
        OperationResult SetUserOffline(string id);

        [OperationContract]
        OperationResult<ICollection<AOSQSpace>> GetQSpaces();

        [OperationContract]
        OperationResult<ICollection<Activity>> GetActivitiesByQSpaceIdAndActivityId(string qSpaceId, string[] activityIds);

        [OperationContract]
        OperationResult<ICollection<ActivityComposition>> GetActivityCompositionsByActivityIds(string[] activityIds);

        [OperationContract]
        OperationResult<ICollection<ActivityStatus>> GetActivityStatus();

        [OperationContract]
        OperationResult<User> AOSSignIn(string login, string password);

        [OperationContract]
        OperationResult<ActivityCommon> AddOrUpdateCommonActivity(ActivityCommon activityCommon);

        [OperationContract]
        OperationResult<QSpaceCommon> AddOrUpdateCommonQSpace(QSpaceCommon qSpaceCommon);

        [OperationContract]
        OperationResult<UserCommon> AddOrUpdateCommonUser(UserCommon userCommon);

        [OperationContract]
        OperationResult<ICollection<ActivityCommon>> GetCommonActivities();

        [OperationContract]
        OperationResult<ICollection<QSpaceCommon>> GetCommonQSpaces();

        [OperationContract]
        OperationResult<ICollection<UserCommon>> GetCommonUsers();

        [OperationContract]
        OperationResult<ICollection<ActivityUser>> GetUserActivitiesByUserId(string userId);

        [OperationContract]
        OperationResult<ICollection<Activity>> GetActivitiesById(string[] activityIds);

        [OperationContract]
        OperationResult<ICollection<Activity>> GetActivitiesByOTNActivityIds(int[] otnActivityIds);

        [OperationContract]
        OperationResult<ActivityTool> AddOrUpdateActivityTool(ActivityTool activityTool);

        [OperationContract]
        OperationResult<ICollection<ActivityTool>> GetActivityToolsById(string[] toolIds);

        [OperationContract]
        OperationResult<ICollection<ActivityTool>> GetAllActivityTools();

        [OperationContract]
        OperationResult<AllCaptureTime> AddOrUpdateAllCaptureTime(AllCaptureTime allCaptureTime);

        [OperationContract]
        OperationResult<AllowedTime> AddOrUpdateAllowedTime(AllowedTime allowedTime);

        [OperationContract]
        OperationResult<KeywordDictionary> AddOrUpdateKeywordDictionary(KeywordDictionary keywordDictionary);

        [OperationContract]
        OperationResult<AllCaptureTime> GetAllTimeCollectionById(string collectionId);

        [OperationContract]
        OperationResult<AllowedTime> GetAllowedTimeCollectionById(string collectionId);

        [OperationContract]
        OperationResult<ICollection<AllCaptureTime>> GetAllTimeCollection();

        [OperationContract]
        OperationResult<ICollection<AllowedTime>> GetAllowedTimeCollection();

        [OperationContract]
        OperationResult<ICollection<KeywordDictionary>> GetKeywordDictionariesByIds(string[] dictionaryIds);

        [OperationContract]
        OperationResult<ICollection<KeywordDictionary>> GetKeywordDictionaries();

        [OperationContract]
        OperationResult<ActivityUser> GetActivityUserByActivityId(string activityId);

        [OperationContract]
        OperationResult<ICollection<ActivityTool>> GetActivityTools();

        [OperationContract]
        OperationResult<ICollection<Activity>> GetActiveActivitiesByQSpaceIdAndActivityId(string qSpaceId, string[] activityIds);

        [OperationContract]
        OperationResult<ICollection<ActivityUser>> GetActivityUsers();

        [OperationContract]
        OperationResult<ActivityPriority> AddOrUpdatePriority(ActivityPriority activityPriority);

        [OperationContract]
        OperationResult<ICollection<ActivityPriority>> GetActivityPriorities();

        [OperationContract]
        OperationResult<ICollection<Activity>> GetActivities();

        [OperationContract]
        OperationResult<Activity> GetActivityByActivityId(string activityId);

        [OperationContract]
        OperationResult<ActivityComposition> GetActivityCompositionByActivityId(string activityId);

        [OperationContract]
        OperationResult UpdateActivityViewStatus(string[] activityIds);

        [OperationContract]
        OperationResult DeleteActivityByActivityId(string activityId);

        [OperationContract]
        OperationResult<ICollection<Reports>> GetReportData(string qSpaceId, string userId, string activityId, DateTime? fromDate, DateTime? toDate);

        [OperationContract]
        OperationResult<ICollection<User>> GetUsersByQSpaceId(string qSpaceId);

        [OperationContract]
        OperationResult<ICollection<Activity>> GetActivitiesByQSpaceAndUserId(string qSpaceId,string userId);

        [OperationContract]
        void InsertDefaultData();

        [OperationContract]
        OperationResult<EmailTemplate> GetEmailTemplateById(string templateId);
    }
}
