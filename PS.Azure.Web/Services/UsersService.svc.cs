//using System.Configuration;
//using PS.Azure.Web.Services;
//using PS.Azure.Web.Utils;
//using PS.Data.Entities;
//using PS.Data.Repositories;
//using Microsoft.WindowsAzure;
//using Microsoft.WindowsAzure.Storage;
//using Microsoft.WindowsAzure.Storage.Blob;
//using System;
//using System.Collections.Generic;
//using System.Diagnostics;
//using System.Drawing;
//using System.Linq;
//using System.Runtime.Serialization;
//using System.ServiceModel;
//using System.Text;
//using System.IO;
//using PS.Data.Entities.Money;
//using System.Globalization;
//using System.Net.Mail;

//namespace PS.Azure.Web
//{
//    public partial class PSService : IUsersService
//    {
//        private readonly Dictionary<string, List<string>> _userPhotoDictionary = new Dictionary<string, List<string>>();
//        private static string CreateUserPhotoBlobKey(string userId, out string photoId)
//        {
//            photoId = Guid.NewGuid().ToString();
//            return string.Format("{0}/{1}", userId, photoId);
//        }

//        private static string GetUserPhotoBlobKey(string userId, string photoId)
//        {
//            return string.Format("{0}/{1}", userId, photoId);
//        }

//        private static CloudBlobContainer GetBlobContainer()
//        {
//            //use this, when contection string will be provided with role
//            //CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
//            //       CloudConfigurationManager.GetSetting("blob"));

//            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
//                ConfigurationManager.ConnectionStrings["blob"].ConnectionString);

//            // Create the blob client.
//            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

//            // Retrieve a reference to a container. 
//            CloudBlobContainer container = blobClient.GetContainerReference("images");

//            // Create the container if it doesn't already exist.
//            container.CreateIfNotExists();

//            return container;
//        }

//        public OperationResult SignUp(User user)
//        {
//            return TryInvoke(() =>
//            {
//                var userExists = _usersRepository.GetUser(user.Email) != null;

//                if (userExists)
//                    return OperationResult.Error("User with same Email already exists");

//                user.Wallet = new Wallet();
//                user.Created = DateTime.UtcNow;
//                user.Sector = SectorType.Creation;
//                user.CanProduceTasks = true;

//                _usersRepository.InsertOrUpdate(user);

//                return OperationResult.Success();
//            });
//        }

//        public OperationResult<User> SignIn(string email, string password)
//        {
//            return TryInvoke<User>(() =>
//                {
//                    OperationResult<User> result;
//                    var user = _usersRepository.GetUser(email, password);
//                    if (user != null)
//                    {
//                        //add user photo ids
//                        if (_userPhotoDictionary.ContainsKey(user.Id))
//                            _userPhotoDictionary[user.Id] = user.PhotoIds;
//                        else
//                            _userPhotoDictionary.Add(user.Id, user.PhotoIds);

//                        result = OperationResult<User>.Success(user);
//                    }
//                    else
//                        result = OperationResult<User>.Error("Email or password is not valid");

//                    return result;
//                });
//        }

//        public OperationResult PasswordRecovery(string email)
//        {
//            return TryInvoke(() =>
//            {
//                var user = _usersRepository.GetAll().FirstOrDefault(x => x.Email.Equals(email));
//                if (user == null)
//                    return OperationResult.Error("User not exists");

//                user.Password = RandomPasswordGenerator.Generate();

//                var errorMessage = EmailSender.SendEmail(email, "New PS password: " + user.Password);
//                if (!string.IsNullOrWhiteSpace(errorMessage))
//                    return OperationResult.Error(errorMessage);

//                _usersRepository.InsertOrUpdate(user);

//                return OperationResult.Success();
//            });
//        }

//        public OperationResult SignOut()
//        {
//            return OperationResult.Success();
//        }

//        public OperationResult UpdateUser(User user)
//        {
//            return TryInvoke(() => _usersRepository.UpdateUser(user));
//        }

//        public OperationResult ChangePassword(string userId, string newPassword)
//        {
//            return TryInvoke(() => _usersRepository.ChangePassword(userId, newPassword));
//        }

//        public OperationResult<int> GetUserPhotoCount(string userId)
//        {
//            return TryInvoke(() =>
//                {
//                    var container = GetBlobContainer();

//                    // Loop over items within the container and output the length and URI.
//                    return container.ListBlobs(null, false).Count();
//                });
//        }

//        public OperationResult RemoveUserPhoto(string userId, string photoId)
//        {
//            throw new NotImplementedException();
//        }

//        public OperationResult<string> UploadPhoto(string userId, string photoBase64, string photoId = null)
//        {
//            return TryInvoke(() => StorePhoto(userId, photoBase64, photoId));
//        }

//        private string StorePhoto(string userId, string photoBase64, string photoId = null)
//        {
//            string userPhotoBlobKey;
//            if (string.IsNullOrEmpty(photoId))
//            {
//                userPhotoBlobKey = CreateUserPhotoBlobKey(userId, out photoId);

//                if (!_userPhotoDictionary.ContainsKey(userId))
//                    _userPhotoDictionary.Add(userId, new List<string>());

//                if (_userPhotoDictionary[userId] == null)
//                    _userPhotoDictionary[userId] = new List<string>();

//                _userPhotoDictionary[userId].Add(userPhotoBlobKey);
//                _usersRepository.UpdateUserPhotoId(userId,
//                    _userPhotoDictionary[userId]);
//            }
//            else
//            {
//                if (!_userPhotoDictionary[userId].Contains(photoId))
//                    throw new InvalidOperationException("InsertOrUpdateUserPhoto");

//                userPhotoBlobKey = GetUserPhotoBlobKey(userId, photoId);
//            }

//            var blockBlob = GetBlobContainer().GetBlockBlobReference(userPhotoBlobKey);
//            var buffer = Convert.FromBase64String(photoBase64);
//            using (var stream = new MemoryStream(buffer))
//            {
//                blockBlob.UploadFromStream(stream);
//            }
//            return photoId;
//        }

//        public OperationResult<string> GetUserPhoto(string userId, string photoId)
//        {
//            return TryInvoke(() => GetPhoto(userId, photoId));
//        }

//        private string GetPhoto(string userId, string photoId)
//        {
//            var container = GetBlobContainer();
//            var blockBlob = container.GetBlockBlobReference(GetUserPhotoBlobKey(userId, photoId));
//            using (var stream = blockBlob.OpenRead())
//            {
//                var buffer = new byte[stream.Length];
//                stream.Read(buffer, 0, (int)stream.Length);
//                return Convert.ToBase64String(buffer);
//            }
//        }

//        public OperationResult<List<string>> GetPhotos(string userId, List<string> photoIds)
//        {
//            return TryInvoke(() => (from photoId in photoIds select GetPhoto(userId, photoId)).ToList());
//        }

//        public OperationResult<List<string>> UploadUserPhotos(string userId, List<string> photosBytes)
//        {
//            return TryInvoke(() => (from photosByte in photosBytes select StorePhoto(userId, photosByte)).ToList());
//        }

//        public OperationResult<bool> CreateUser(User user)
//        {
//            return TryInvoke(() => _usersRepository.Register(user));
//        }

//        public OperationResult<List<User>> GetFriends(string userId)
//        {
//            return TryInvoke<List<User>>(() => _usersRepository.GetAll().Where(x => x.Id != userId).ToList());
//        }


//        #region EmailVerification
//        public bool VerifyEmail(string email)
//        {
//            var user = _usersRepository.GetUser(email);
//            if (user != null)
//            {
//                return false;
//            }
//            else
//            {
//                return true;
//            }
//        }

//        public OperationResult SendEmailVerification(string oldEmail, string newEmail)
//        {
//            try
//            {
//                var usersRepository = new Repository<User>();
//                var emailReopsitory = new Repository<EmailVerification>();
//                EmailVerification emailVerification = new EmailVerification();

//                var user = _usersRepository.GetUser(oldEmail);
//                if (user == null)
//                    return OperationResult.Error("User not exists");
//                var verificationCode = RandomNumber(10000, 999999);
//                var errorMessage = ConfirmationCodeEmailSender.VerificationCode(newEmail, "verification Code: " + verificationCode);
//                if (!string.IsNullOrWhiteSpace(errorMessage))
//                    return OperationResult.Error(errorMessage);

//                emailVerification.Email = oldEmail;
//                emailVerification.NewEmail = newEmail;
//                emailVerification.VerificationCode = verificationCode;
//                emailVerification.Verified = false;
//                emailVerification.NumberOfAttempts = 0;

//                _usersRepository.InsertEmailVerificationCode(emailVerification);
//            }
//            catch (Exception ex)
//            {
//                return OperationResult.Error(ex.Message);
//            }

//            return OperationResult.Success();
//        }

//        public bool VerifyEmailVerificationCode(string email, string verificationCode)
//        {
//            var emailReopsitory = new Repository<EmailVerification>();

//            var existingUser = _usersRepository.GetAllVerificationCodes(email, verificationCode);
//            if (existingUser != null)
//            {
//                return true;
//            }
//            else
//            {
//                return false;
//            }

//        }

//        public bool UpdateEmailByVerificationCode(string email, string verificationCode)
//        {
//            var emailReopsitory = new Repository<EmailVerification>();

//            var existingUser = _usersRepository.GetAllVerificationCodes(email, verificationCode);
//            if (existingUser != null)
//            {
//                var user = _usersRepository.GetUser(email);
//                user.Email = existingUser.NewEmail;
//                _usersRepository.InsertOrUpdate(user);
//                return true;
//            }
//            else
//            {
//                return false;
//            }

//        }

//        private string RandomNumber(int min, int max)
//        {
//            var random = new Random();
//            return random.Next(min, max).ToString(CultureInfo.InvariantCulture);
//        }

//        public virtual System.Net.Mail.MailMessage ConfirmEmail(User user, string confirmCode)
//        {
//            var mailMessage = new MailMessage { Subject = "Confirmation Code" };
//            mailMessage.To.Add(user.Email);
//            return mailMessage;
//        }
//        #endregion


//        public OperationResult<List<User>> GetAllUsers()
//        {
//            return TryInvoke<List<User>>(() => _usersRepository.GetAll().ToList());
//        }
//    }
//}
