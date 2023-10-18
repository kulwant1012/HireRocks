using PS.Data.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Web;

namespace PS.Azure.Web.Services
{
    [ServiceContract]
    public interface IUsersService
    {
        //[OperationContract]
        //OperationResult SignUp(User user);

        //[OperationContract]
        //OperationResult<User> SignIn(string email, string password);

        //[OperationContract]
        //OperationResult PasswordRecovery(string email);

        //[OperationContract]
        //OperationResult SignOut();

        //[OperationContract]
        //OperationResult UpdateUser(User user);

        //[OperationContract]
        //OperationResult<string> UploadPhoto(string userId, string photoBase64, string photoId = null);


        //[OperationContract]
        //OperationResult<string> GetUserPhoto(string userId, string photoId);

        //OperationResult<int> GetUserPhotoCount(string userId);

        //[OperationContract]
        //OperationResult ChangePassword(string userId, string newPassword);

        //[OperationContract]
        //OperationResult RemoveUserPhoto(string userId, string photoId);

        //[OperationContract]
        //OperationResult<List<string>> GetPhotos(string userId, List<string> photoIds);

        //[OperationContract]
        //OperationResult<List<string>> UploadUserPhotos(string userId, List<string> photosBytes);

        //[OperationContract]
        //OperationResult<bool> CreateUser(User user);

        //[OperationContract]
        //OperationResult<List<User>> GetFriends(string userId);

        //[OperationContract]
        //bool VerifyEmail(string email);

        //[OperationContract]
        //OperationResult SendEmailVerification(string oldemail, string Newemail);

        //[OperationContract]
        //bool VerifyEmailVerificationCode(string email, string verificationCode);

        //[OperationContract]
        //bool UpdateEmailByVerificationCode(string email, string verificationCode);

        //[OperationContract]
        //OperationResult<List<User>> GetAllUsers();
    }
}