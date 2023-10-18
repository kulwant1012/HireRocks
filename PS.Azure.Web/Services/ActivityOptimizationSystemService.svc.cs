using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Linq.Expressions;

using PS.Azure.Web.Services;
using PS.Data.Entities.AOS;
using PS.Data.Entities.AOS.Common;
using Raven.Client.Linq;

namespace PS.Azure.Web
{
    public partial class PSService : IActivityOptimizationSystemService
    {
        public OperationResult<ActivityComposition> AddOrUpdateActivityComposition(ActivityComposition activityComposition)
        {
            return TryInvoke<ActivityComposition>(() =>
            {
                if (string.IsNullOrEmpty(activityComposition.Id))
                    activityComposition.Id = Guid.NewGuid().ToString();
                _activityCompositionRepository.InsertOrUpdate(activityComposition);
                return activityComposition;
            });
        }

        public OperationResult<User> AddOrUpdateUser(User user)
        {
            return TryInvoke(() =>
            {
                OperationResult<User> result;
                var isUserAlreadyExists = _aosUserRepository.Search(x => x.Email == user.Email || x.Login == user.Login).FirstOrDefault();
                if (isUserAlreadyExists == null && string.IsNullOrEmpty(user.Id) || isUserAlreadyExists != null && !string.IsNullOrEmpty(user.Id))
                {
                    if (string.IsNullOrEmpty(user.Id))
                        user.Id = Guid.NewGuid().ToString();
                    _aosUserRepository.InsertOrUpdate(user);
                    result = OperationResult<User>.Success(user);
                }
                else
                    result = OperationResult<User>.Error("User already exists");

                return result;
            });
        }

        public OperationResult SetUserOffline(string id)
        {
            return TryInvoke(() =>
            {
                var user = _aosUserRepository.GetById(id);
                user.IsOnline = false;
                _aosUserRepository.InsertOrUpdate(user);
            });
        }

        public OperationResult<AOSQSpace> AddOrUpdateQSpace(AOSQSpace qSpace)
        {
            return TryInvoke(() =>
            {
                if (string.IsNullOrEmpty(qSpace.Id))
                    qSpace.Id = Guid.NewGuid().ToString();
                _aosQSpaceRepository.InsertOrUpdate(qSpace);
                return qSpace;
            });
        }

        public OperationResult<Activity> AddOrUpdateActivity(Activity activity)
        {
            return TryInvoke(() =>
            {
                if (string.IsNullOrEmpty(activity.Id))
                    activity.Id = Guid.NewGuid().ToString();
                _activityRepository.InsertOrUpdate(activity);
                return activity;
            });
        }

        public OperationResult<ActivityStatus> AddOrUpdateActivityStatus(ActivityStatus activityStatus)
        {
            return TryInvoke(() =>
            {
                if (string.IsNullOrEmpty(activityStatus.Id))
                    activityStatus.Id = Guid.NewGuid().ToString();
                _activityStatusRepository.InsertOrUpdate(activityStatus);
                return activityStatus;
            });
        }

        public OperationResult<ICollection<User>> GetUser()
        {
            return TryInvoke(() =>
            {
                return _aosUserRepository.GetAll();
            });
        }

        public OperationResult<ICollection<AOSQSpace>> GetQSpaces()
        {
            return TryInvoke(() =>
            {
                return _aosQSpaceRepository.GetAll();
            });
        }

        public OperationResult<ICollection<Activity>> GetActivitiesByQSpaceIdAndActivityId(string qSpaceId, string[] activityIds)
        {
            return TryInvoke(() =>
            {
                return _activityRepository.Search(x => x.QSpaceID == qSpaceId && x.Id.In<string>(activityIds));
            });
        }

        public OperationResult<ICollection<ActivityStatus>> GetActivityStatus()
        {
            return TryInvoke(() =>
            {
                return _activityStatusRepository.GetAll();
            });
        }

        public OperationResult<User> AOSSignIn(string login, string password)
        {
            return TryInvoke<User>(() =>
            {
                OperationResult<User> result;
                var user = _aosUserRepository.Search(x => x.Login == login && x.Password == password && x.IsActive == true && x.IsLocked == false).FirstOrDefault();
                if (user != null)
                {
                    user.IsOnline = true;
                    _aosUserRepository.InsertOrUpdate(user);
                    result = OperationResult<User>.Success(user);
                }
                else
                    result = OperationResult<User>.Error("Email or password is not valid");

                return result;
            });
        }

        public OperationResult<ActivityCommon> AddOrUpdateCommonActivity(ActivityCommon activityCommon)
        {
            return TryInvoke(() =>
            {
                if (string.IsNullOrEmpty(activityCommon.Id))
                    activityCommon.Id = Guid.NewGuid().ToString();
                _commonActivityRepository.InsertOrUpdate(activityCommon);
                return activityCommon;
            });
        }

        public OperationResult<QSpaceCommon> AddOrUpdateCommonQSpace(QSpaceCommon qSpaceCommon)
        {
            return TryInvoke(() =>
            {
                if (string.IsNullOrEmpty(qSpaceCommon.Id))
                    qSpaceCommon.Id = Guid.NewGuid().ToString();
                _commonQSpaceRepository.InsertOrUpdate(qSpaceCommon);
                return qSpaceCommon;
            });
        }

        public OperationResult<UserCommon> AddOrUpdateCommonUser(UserCommon userCommon)
        {
            return TryInvoke(() =>
            {
                if (string.IsNullOrEmpty(userCommon.Id))
                    userCommon.Id = Guid.NewGuid().ToString();
                _commonUserRepository.InsertOrUpdate(userCommon);
                return userCommon;
            });
        }

        public OperationResult<ICollection<ActivityCommon>> GetCommonActivities()
        {
            return TryInvoke(() =>
            {
                return _commonActivityRepository.GetAll();
            });
        }

        public OperationResult<ICollection<QSpaceCommon>> GetCommonQSpaces()
        {
            return TryInvoke(() =>
            {
                return _commonQSpaceRepository.GetAll();
            });
        }

        public OperationResult<ICollection<UserCommon>> GetCommonUsers()
        {
            return TryInvoke(() =>
            {
                return _commonUserRepository.GetAll();
            });
        }

        public OperationResult<ActivityUser> AddOrUpdateActivityUser(ActivityUser activityUser, bool isAssignedToChanged)
        {
            return TryInvoke(() => _activityUserRepository.AddOrUpdateActivityUser(activityUser, isAssignedToChanged));
        }

        public OperationResult<ICollection<ActivityComposition>> GetActivityCompositionsByActivityIds(string[] activityIds)
        {
            return TryInvoke(() =>
            {
                return _activityCompositionRepository.Search(x => x.ActivityID.In<string>(activityIds));
            });
        }

        public OperationResult<ICollection<ActivityUser>> GetUserActivitiesByUserId(string userId)
        {
            return TryInvoke(() =>
            {
                return _activityUserRepository.Search(x => x.UserId == userId);
            });
        }

        public OperationResult<ICollection<Activity>> GetActivitiesById(string[] activityIds)
        {
            return TryInvoke(() =>
            {
                return _activityRepository.Search(x => x.Id.In<string>(activityIds));
            });
        }

        public OperationResult<ActivityTool> AddOrUpdateActivityTool(ActivityTool activityTool)
        {
            return TryInvoke(() =>
            {
                if (string.IsNullOrEmpty(activityTool.Id))
                    activityTool.Id = Guid.NewGuid().ToString();
                _activityToolRepository.InsertOrUpdate(activityTool);
                return activityTool;
            });
        }

        public OperationResult<ICollection<ActivityTool>> GetActivityToolsById(string[] toolIds)
        {
            return TryInvoke(() =>
            {
                return _activityToolRepository.Search(x => x.Id.In<string>(toolIds));
            });
        }

        public OperationResult<AllCaptureTime> AddOrUpdateAllCaptureTime(AllCaptureTime allCaptureTime)
        {
            return TryInvoke(() =>
            {
                _allCaptureTimeRepository.AddOrUpdateAllCaptureTimeCollection(allCaptureTime);
                return allCaptureTime;
            });
        }

        public OperationResult<AllowedTime> AddOrUpdateAllowedTime(AllowedTime allowedTime)
        {
            return TryInvoke(() =>
            {
                _allowedTimeRepository.AddOrUpdateAllowedTimeCollection(allowedTime);
                return allowedTime;
            });
        }

        public OperationResult<KeywordDictionary> AddOrUpdateKeywordDictionary(KeywordDictionary keywordDictionary)
        {
            return TryInvoke(() =>
            {
                _keywordDictionaryRepository.AddOrUpdateKeywordDictionary(keywordDictionary);
                return keywordDictionary;
            });
        }

        public OperationResult<AllCaptureTime> GetAllTimeCollectionById(string collectionId)
        {
            return TryInvoke<AllCaptureTime>(() => _allCaptureTimeRepository.GetAllTimeCollectionById(collectionId));
        }

        public OperationResult<AllowedTime> GetAllowedTimeCollectionById(string collectionId)
        {
            return TryInvoke<AllowedTime>(() => _allowedTimeRepository.GetAllowedTimeCollectionById(collectionId));
        }

        public OperationResult<ICollection<KeywordDictionary>> GetKeywordDictionariesByIds(string[] dictionaryIds)
        {
            return TryInvoke(() =>
            {
                return _keywordDictionaryRepository.GetKeywordDictionariesByIds(dictionaryIds);
            });
        }

        public OperationResult<ICollection<KeywordDictionary>> GetKeywordDictionaries()
        {
            return TryInvoke(() =>
            {
                return _keywordDictionaryRepository.GetKeywordDictionaries();
            });
        }

        public OperationResult<ICollection<ActivityTool>> GetAllActivityTools()
        {
            return TryInvoke(() => _activityToolRepository.GetAll());
        }

        public OperationResult<ICollection<AllCaptureTime>> GetAllTimeCollection()
        {
            return TryInvoke(() => _allCaptureTimeRepository.GetAll());
        }

        public OperationResult<ICollection<AllowedTime>> GetAllowedTimeCollection()
        {
            return TryInvoke(() => _allowedTimeRepository.GetAll());
        }

        public OperationResult<ICollection<Activity>> GetActivitiesByOTNActivityIds(int[] otnActivityIds)
        {
            return TryInvoke(() => _activityRepository.GetActivitiesByOTNActivityIds(otnActivityIds));
        }

        public OperationResult<ActivityUser> GetActivityUserByActivityId(string activityId)
        {
            return TryInvoke(() => _activityUserRepository.GetEntity<ActivityUser>(x => x.ActivityId == activityId && x.IsActive == true));
        }

        public OperationResult<ICollection<ActivityTool>> GetActivityTools()
        {
            return TryInvoke(() => _activityToolRepository.GetAll());
        }

        public OperationResult<ICollection<Activity>> GetActiveActivitiesByQSpaceIdAndActivityId(string qSpaceId, string[] activityIds)
        {
            return TryInvoke(() => _activityRepository.GetActiveActivitiesByQSpaceIdAndActivityId(qSpaceId, activityIds));
        }

        public void InsertDefaultData()
        {
            TryInvoke(() => _aosUserRepository.InsertDefaultUserAndData());
        }

        public OperationResult<ICollection<Activity>> GetActivities()
        {
            return TryInvoke(() => _activityRepository.GetAll());
        }

        public OperationResult<ICollection<ActivityUser>> GetActivityUsers()
        {
            return TryInvoke(() => _activityUserRepository.GetAll());
        }


        public OperationResult<ActivityPriority> AddOrUpdatePriority(ActivityPriority activityPriority)
        {
            return TryInvoke(() =>
            {
                if (string.IsNullOrEmpty(activityPriority.Id))
                    activityPriority.Id = Guid.NewGuid().ToString();
                _activityPriorityRepository.InsertOrUpdate(activityPriority);
                return activityPriority;
            });
        }

        public OperationResult<ICollection<ActivityPriority>> GetActivityPriorities()
        {
            return TryInvoke(() => _activityPriorityRepository.GetAll());
        }

        OperationResult<Activity> IActivityOptimizationSystemService.GetActivityByActivityId(string activityId)
        {
            return TryInvoke(() => _activityRepository.GetById(activityId));
        }

        public OperationResult<ActivityComposition> GetActivityCompositionByActivityId(string activityId)
        {
            return TryInvoke(() => _activityCompositionRepository.Search(x => x.ActivityID == activityId).FirstOrDefault());
        }

        public OperationResult UpdateActivityViewStatus(string[] activityIds)
        {
            return TryInvoke(() => _activityUserRepository.UpdateActivityViewStatus(activityIds));
        }

        public OperationResult DeleteActivityByActivityId(string activityId)
        {
            return TryInvoke(() => _activityRepository.DeleteActivityByActivityId(activityId));
        }
        
        public OperationResult<ICollection<Reports>> GetReportData(string qSpaceId, string userId, string activityId, DateTime? fromDate, DateTime? toDate)
        {
            return TryInvoke(() => _AMSReportsRepository.GetReportData(qSpaceId, userId, activityId, fromDate, toDate));
        }

        public OperationResult<ICollection<User>> GetUsersByQSpaceId(string qSpaceId)
        {
            return TryInvoke(() => _aosUserRepository.GetUsersByQSpaceId(qSpaceId));
        }

        public OperationResult<ICollection<Activity>> GetActivitiesByQSpaceAndUserId(string qSpaceId, string userId)
        {
            return TryInvoke(() => _activityRepository.GetActivitiesByQSpaceAndUserId(qSpaceId, userId));
        }

        public OperationResult<EmailTemplate> GetEmailTemplateById(string templateId)
        {
            return TryInvoke(() => _emailTemplateRepository.GetById(templateId));
        }
    }
}
