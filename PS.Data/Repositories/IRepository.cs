using PS.Data.Entities;
using PS.Data.Entities.AOS;
using PS.Data.Entities.AVS;
using PS.Data.Interfaces;
using Raven.Client.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace PS.Data.Repositories
{
    public interface IRepository<T>
    {
        T GetById(string id);
        ICollection<T> GetAll();
        ICollection<T> Search(Expression<Func<T, bool>> predicate);
        void InsertOrUpdate(T entity);
        void Delete(string id);
        void Initialize(string connectionString);
        void InsertEmailVerificationCode(EmailVerification entity);
        EmailVerification GetAllVerificationCodes(string email, string verificationCode);
    }

    //public interface IUserRepository : IRepository<User>
    //{
    //    User GetUser(string email);
    //    User GetUser(string email, string password);
    //    void UpdateUser(User user);
    //    void ChangePassword(string userId, string newPassword);
    //    void UpdateUserPhotoId(string userId, List<string> photoIds);
    //    bool Register(User user);
    //    List<User> GetFriends(string email);
    //    List<User> SearchUsers(string query);
    //    void AddFriend(string userId, string friendEmail);
    //}

    public interface IAllCaptureTimeRepository
    {
        AllCaptureTime AddOrUpdateAllCaptureTimeCollection(AllCaptureTime allCaptureTime);
        AllCaptureTime GetAllTimeCollectionById(string collectionId);
    }

    public interface IAllowedTimeRepository
    {
        AllowedTime AddOrUpdateAllowedTimeCollection(AllowedTime allowedTime);
        AllowedTime GetAllowedTimeCollectionById(string collectionId);
    }

    public interface IKeywordDictionaryRepository
    {
        KeywordDictionary AddOrUpdateKeywordDictionary(KeywordDictionary keywordDictionary);
        ICollection<KeywordDictionary> GetKeywordDictionariesByIds(string[] dictionaryIds);
    }

    public interface IMatchedKeywordRepository
    {
        MatchedKeyword AddOrUpdateMatchedKeyword(MatchedKeyword matchedKeyword);
        ICollection<MatchedKeyword> GetMatchedKeywordIds(string[] matchedKeywordIds);
    }

    public interface IActivityRepository
    {
        ICollection<Activity> GetActivitiesByOTNActivityIds(int[] otnActivityIds);
    }

    public interface IActivityCaptureRepository
    {
        void UpdateVerificationStatus(string entityId, VerificationStatus verificationStatus, bool isCaptureAcceptanceChanged);
    }

    public interface IAOSUserRepository
    {
        void InsertDefaultUserAndData();
    }

    public interface ISearchRepository
    {
        IEnumerable<string> GetSearchSuggestions(string nameStartWith, int suggestionsCount);
    }
}