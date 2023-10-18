using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PS.HireRocks.Model;
using PS.HireRocks.Data.Database;
using System.Web.Mvc;

namespace PS.HireRocks.Data.Repositories
{
    public class UserRepository
    {
        public bool VerifyEmailAddress(string verificationCode)
        {
            using (var entities = new Entities())
            {
                var result = entities.VerifyEmailAddress(verificationCode).FirstOrDefault();
                return result == 1 ? true : false;
            }
        }

        public bool IsEmailAddressAlreadyExists(string email)
        {
            using (var entities = new Entities())
            {
                var result = entities.IsEmailAddressAlreadyExists(email).FirstOrDefault();
                return result > 0 ? false : true;
            }
        }

        public bool IsUserNameAlreadyExists(string userName)
        {
            using (var entities = new Entities())
            {
                var result = entities.IsUserNameAlreadyExists(userName).FirstOrDefault();
                return result > 0 ? false : true;
            }
        }

        public SetForgotPasswordToken_Result SetForgotPasswordToken(string forgotPasswordToken, string emailAddress)
        {
            using (var entities = new Entities())
            {
                return entities.SetForgotPasswordToken(forgotPasswordToken, emailAddress).FirstOrDefault();
            }
        }

        public bool ResetPassword(string forgotPasswordToken, string newPassword)
        {
            using (var entities = new Entities())
            {
                var result = entities.ResetPassword(forgotPasswordToken, newPassword).FirstOrDefault();
                return result > 0 ? true : false;
            }
        }

        public UserProfileViewModel GetCompleteProfileScreenData(string userId)
        {
            UserProfileViewModel userProfileViewModel = new UserProfileViewModel();
            using (var entities = new Entities())
            {
                userProfileViewModel.LanguageList = entities.GetAllLanguages().Select(x => new LanguageViewModel { LanguageId = x.LanguageId, LanguageName = x.LanguageName }).ToList();
                userProfileViewModel.SkillList = entities.GetAllSkills().Select(x => new SkillViewModel { SkillId = x.SkillId, SkillName = x.SkillName }).ToList();
                var jobSubCategories = entities.GetAllJobSubCategories().ToList();
                userProfileViewModel.JobCategoryList = entities.GetAllJobCategories().Select(x => new JobCategoryViewModel
                {
                    CategoryName = x.CategoryName,
                    JobCategoryId = x.JobCategoryId,
                    JobSubCategoryList = jobSubCategories.Where(y => y.JobCategoryId == x.JobCategoryId).Select(z => new JobSubCategoryViewModel { JobSubCategoryId = z.JobSubCategoryId, SubCategoryName = z.SubCategoryName, }).ToList()
                }).ToList();
                userProfileViewModel.EducationList = entities.GetEducationDetailsByUserId(userId).Select(x => new EducationViewModel
                {
                    DegreeEndDate = x.DegreeEndDate,
                    DegreeName = x.DegreeName,
                    DegreeTypeName = x.DegreeTypeName,
                    DegreeStartDate = x.DegreeStartDate,
                    DegreeTypeId = x.DegreeTypeId,
                    EducationId = x.EducationId,
                    Percentage = x.Percentage
                }).ToList();
                userProfileViewModel.CertificationsList = entities.GetCertificationsByUserId(userId).Select(x => new CertificationViewModel { CertificationId = x.CertificationId, CertificationName = x.CertificationName, CertificationNumber = x.CertificationNumber, CertificationYear = x.CertificationDate }).ToList();

                var userProfile = entities.GetUserProfileByUserId(userId).FirstOrDefault();
                if (userProfile != null)
                {
                    userProfileViewModel.ProfileTitle = userProfile.ProfileTitle;
                    userProfileViewModel.Addresss1 = userProfile.Address1;
                    userProfileViewModel.Addresss2 = userProfile.Address2;
                    userProfileViewModel.CellPhone = userProfile.CellPhone;
                    userProfileViewModel.City1 = userProfile.City1;
                    userProfileViewModel.City2 = userProfile.City2;
                    userProfileViewModel.Country1 = userProfile.Country1;
                    userProfileViewModel.Country2 = userProfile.Country2;
                    userProfileViewModel.DateOfBirth = userProfile.DateOfBirth;
                    userProfileViewModel.Email = userProfile.Email;
                    userProfileViewModel.Gender = userProfile.Gender;
                    userProfileViewModel.HomePhone = userProfile.HomePhone;
                    userProfileViewModel.ProfileImage = userProfile.ProfilePic;
                    userProfileViewModel.TimeZone = userProfile.TimeZone;
                    userProfileViewModel.HourlyRate = userProfile.UserHourlyRate;
                    userProfileViewModel.UserId = userProfile.UserId;
                    userProfileViewModel.UserProfileId = userProfile.UserProfileId;
                    userProfileViewModel.SkillIds = userProfile.UserSkillIds;
                    userProfileViewModel.WorkPhone = userProfile.WorkPhone;
                    userProfileViewModel.VideoIntroduction = userProfile.IntroductionVideo;

                    string userSkillNames = string.Empty;
                    string jobSubCategoryNames = string.Empty;
                    string userLanguageNames = string.Empty;
                    if (!string.IsNullOrEmpty(userProfile.UserSkillIds))
                        userProfileViewModel.SkillList.ForEach(x => { if (userProfile.UserSkillIds.Split(',').Contains(x.SkillId.ToString())) { x.IsSelected = true; userSkillNames += x.SkillName + ", "; } });
                    if (!string.IsNullOrEmpty(userProfile.UserLanguageIds))
                        userProfileViewModel.LanguageList.ForEach(x => { if (userProfile.UserLanguageIds.Contains(x.LanguageId.ToString())) { x.IsSelected = true; userLanguageNames += x.LanguageName + ", "; } });
                    if (!string.IsNullOrEmpty(userProfile.UserSubCategoryIds))
                    {
                        userProfileViewModel.JobCategoryList.ForEach(x =>
                        {
                            userProfileViewModel.JobSubCategoriesIds += string.Join(", ", x.JobSubCategoryList.Select(y => y.SubCategoryName));
                            x.JobSubCategoryList.ForEach(y =>
                                {
                                    if (userProfile.UserSubCategoryIds.Split(',').Contains(y.JobSubCategoryId.ToString()))
                                    {
                                        y.IsSelected = true;
                                        jobSubCategoryNames += y.SubCategoryName + ", ";
                                    }
                                });
                        });

                    }
                    userProfileViewModel.SkillIds = userSkillNames.TrimEnd(',', ' ');
                    userProfileViewModel.LanguageIds = userLanguageNames.TrimEnd(',', ' ');
                    userProfileViewModel.JobSubCategoriesIds = jobSubCategoryNames.TrimEnd(',', ' ');
                }
            }
            return userProfileViewModel;
        }

        public void InsertUpdateUserProfile(UserProfileViewModel model)
        {
            using (var entities = new HireRocks.Data.Database.Entities())
            {
                entities.InsertUpdateUserProfile(
                    model.UserProfileId,
                    model.ProfileTitle,
                    model.SkillIds,
                    model.LanguageIds,
                    model.HourlyRate,
                    model.EducationDetailXML,
                    model.JobSubCategoriesIds,
                    model.UserId,
                    model.Addresss1,
                    model.Addresss2,
                    model.City1,
                    model.City2,
                    model.Country1,
                    model.Country2,
                    model.HomePhone,
                    model.WorkPhone,
                    model.CellPhone,
                    model.ProfileImage,
                    model.TimeZone,
                    model.Gender,
                    model.DateOfBirth,
                    model.CertificationDetailXML,
                    model.VideoIntroduction);
            }
        }

        public GetUserByIdViewModel GetUserById(string userId)
        {
            using (var entities = new Entities())
            {
                return entities.GetUserById(userId).Select(x => new GetUserByIdViewModel
                {
                    UserName = x.UserName,
                    Email = x.Email,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    UserHourlyRate = x.UserHourlyRate
                }).FirstOrDefault();
            }
        }

        public void InsertUserAccountType(string UserAccountTypeId, string UserId)
        {
            long id= Convert.ToInt64(UserAccountTypeId);
            using (var entities = new HireRocks.Data.Database.Entities())
            {
                entities.InsertAccountType(Convert.ToInt32(id), UserId);
            }
        }
    }
}
