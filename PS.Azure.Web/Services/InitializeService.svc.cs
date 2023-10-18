//------------------------------------------------------------------------------
// <copyright file="WebDataService.svc.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Data.Services;
using System.Data.Services.Common;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.ServiceModel.Web;
using System.Web;
using PS.Azure.Web.Services;
using PS.Data.Entities;
using PS.Data.Entities.AOS;
using PS.Data.Entities.Money;
using PS.Data.Repositories;
using PS.Data.Repositories.AVS;
using PS.Data.Repositories.AOS;
using PS.Data.Repositories.AOSWithWorksnaps;
using System.Configuration;

namespace PS.Azure.Web
{
    public partial class PSService : IInitializationService
    {
        private readonly Repository<QSpace> _qSpaceRepository = new Repository<QSpace>();
        private readonly Repository<Task> _taskRepository = new Repository<Task>();
        private readonly Repository<Structure> _structureRepository = new Repository<Structure>();
        private readonly Repository<BackupTask> _backupTasksRepository = new Repository<BackupTask>();
        private readonly Repository<BackupAction> _backupActionsRepository = new Repository<BackupAction>();
        private readonly ResourcesRepository _resourcesRepository = new ResourcesRepository();
        private readonly CompanyRepository _companyRepository = new CompanyRepository();
        private readonly ResourceTypeRepository _resourceTypeRepository = new ResourceTypeRepository();
        private readonly IRepository<MoneyTransaction> _moneyTransactionsRepository = new Repository<MoneyTransaction>();
        private readonly UsersRepository _usersRepository = new UsersRepository();
        private readonly ResourceCategoryRepository _resourceCategoryRepository = new ResourceCategoryRepository();
        private readonly ResourcesRepository _resourceRepository = new ResourcesRepository();
        private readonly BrandRepository _brandRepository = new BrandRepository();
        private readonly ActivityCaptureRepository _activityCaptureRepository = new ActivityCaptureRepository();
        private readonly ActivityCompositionRepository _activityCompositionRepository = new ActivityCompositionRepository();
        private readonly AOSUserRepository _aosUserRepository = new AOSUserRepository();
        private readonly AOSQSpaceRepository _aosQSpaceRepository = new AOSQSpaceRepository();
        private readonly ActivityRepository _activityRepository = new ActivityRepository();
        private readonly ActivityStatusRepository _activityStatusRepository = new ActivityStatusRepository();
        private readonly CommonActivityRepository _commonActivityRepository = new CommonActivityRepository();
        private readonly CommonQSpaceRepository _commonQSpaceRepository = new CommonQSpaceRepository();
        private readonly CommonUserRepository _commonUserRepository = new CommonUserRepository();
        private readonly ActivityUserRepository _activityUserRepository = new ActivityUserRepository();
        private readonly ActivityToolRepository _activityToolRepository = new ActivityToolRepository();

        private readonly OTNWorksnapsActivityRepository _otnWorksnapsActivityRepository = new OTNWorksnapsActivityRepository();
        private readonly OTNWorksnapsUserRepository _otnWorksnapsUserRepository = new OTNWorksnapsUserRepository();
        private readonly OTNWorksnapsWorkLogRepository _otnWorksnapsWorkLogRepository = new OTNWorksnapsWorkLogRepository();
        private readonly OTNWorksnapsQSpaceRepository _otnWorksnapsQSpaceRepository = new OTNWorksnapsQSpaceRepository();
        private readonly OTNWorksnapsLastSyncDateRepository _otnWorksnapsLastSyncDateRepository = new OTNWorksnapsLastSyncDateRepository();

        private readonly AllCaptureTimeRepository _allCaptureTimeRepository = new AllCaptureTimeRepository();
        private readonly AllowedTimeRepository _allowedTimeRepository = new AllowedTimeRepository();
        private readonly KeywordDictionaryRepository _keywordDictionaryRepository = new KeywordDictionaryRepository();
        private readonly MatchedKeywordRepository _matchedKeywordRepository = new MatchedKeywordRepository();
        private readonly ActivityPriorityRepository _activityPriorityRepository = new ActivityPriorityRepository();
        private readonly AMSReportsRepository _AMSReportsRepository = new AMSReportsRepository();
        private readonly EmailTemplateRepository _emailTemplateRepository = new EmailTemplateRepository();
        
        public OperationResult InitializeRavenDb(string connectionString)
        {
            return TryInvoke(() =>
            {
                _qSpaceRepository.Initialize(connectionString);
            });
        }

        public OperationResult SendEmails(DateTime cutTime)
        {
            var timeRiched = false;
            while (!timeRiched)
            {
                if (DateTime.UtcNow >= cutTime)
                {
                    timeRiched = true;
                }
            }

            var activities = GetActivities();
            var statuses = GetActivityStatus();
            var activityUsers = GetActivityUsers();
            var users = GetUser();
            var managers = users.Value.Where(i => i.Roles.Contains(UserRole.Manager)).ToList();
            var completedStatusId = statuses.Value.Single(i => i.StatusName == "Completed").Id;
            foreach (var activity in activities.Value.Where(i => i.ActivityStatusId == completedStatusId))
            {
                var activityUser = activityUsers.Value.FirstOrDefault(i => i.ActivityId == activity.Id);
                if (activityUser != null)
                {
                    var user = users.Value.FirstOrDefault(i => i.Id == activityUser.UserId);
                    if (user != null)
                    {
                        foreach (var manager in managers)
                        {
                            try
                            {
                                SendEmailNotification(user.Email, "Activity " + activity.ActivityName + "Completed",
                                    "Activity Completed", manager.Email);
                            }
                            finally
                            {

                            }
                        }
                    }
                }
            }
            return OperationResult.Success();
        }

        void SendEmailNotification(string to, string message, string subject, string cc)
        {
            using (SmtpClient smtpClient = new SmtpClient())
            {
                //smtpClient.Credentials = new NetworkCredential("vinnikovoleg@gmail.com", "Pusher0668901747");
                //smtpClient.EnableSsl = true;
                MailMessage mailMessage = new MailMessage();
                mailMessage.Body = message;

                mailMessage.IsBodyHtml = true;
                mailMessage.Subject = subject;
                mailMessage.To.Add(to);
                mailMessage.CC.Add(cc);
                smtpClient.Send(mailMessage);
            }
        }

    }
}
