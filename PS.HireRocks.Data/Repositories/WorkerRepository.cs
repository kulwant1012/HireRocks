using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

using PS.HireRocks.Model;
using PS.HireRocks.Data.Database;
using PS.HireRocks.Data.Helpers;
using System.Web.Mvc;

namespace PS.HireRocks.Data.Repositories
{
    public class WorkerRepository : BaseRepository
    {
        public FindWorkerViewModel GetFindWorkerScreenData()
        {
            using (var entities = new Entities())
            {
                FindWorkerViewModel findWorkerViewModel = new FindWorkerViewModel();
                findWorkerViewModel.SkillsList = entities.GetAllSkills().Select(x => new SkillViewModel { SkillId = x.SkillId, SkillName = x.SkillName }).ToList();
                findWorkerViewModel.CountriesList = GetCountriesAndTimeZone.GetCountriesList();
                findWorkerViewModel.TimeZoneList = GetCountriesAndTimeZone.GetTimeZoneList();
                return findWorkerViewModel;
            }
        }

        public List<GetWorkerViewModel> FindWorkersByFilter(FindWorkerFilter model)
        {
            using (var entities = new Entities())
            {
                List<GetWorkerViewModel> workersList = new List<GetWorkerViewModel>();
                var workers = entities.FindWorkersByFilter(model.WorkerName, model.HourlyRate, model.Rating, model.TimeZone, model.CountryNames, model.SkillIds).ToList();
                workersList = workers.Select(x => new GetWorkerViewModel
                {
                    WorkerId = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    ProfileTitle = x.ProfileTitle ?? string.Empty,
                    Country = x.Country1 ?? string.Empty,
                    HourlyRate = x.UserHourlyRate,
                    ProfileImage = x.ProfilePic,
                    Rating = x.UserRating
                }).ToList();
                return workersList;
            }
        }

        public ContractViewModel GetHireWorkerScreenData(string clientId, string workerId, long? contractId, long? jobBidId = null)
        {
            ContractViewModel contractViewModel = new ContractViewModel();
            using (var entities = new Entities())
            {
                contractViewModel.TimeUnitsList = entities.GetAllTimeUnits().ToList().Select(x => new SelectListItem { Text = x.UnitName, Value = x.TimeUnitId.ToString() });
                if (!string.IsNullOrEmpty(workerId))
                {
                    //contractViewModel.JobsList = entities.GetJobListForHireWorkerScreen(clientId, workerId).ToList().Select(x => new SelectListItem { Text = x.JobTitle, Value = x.JobId.ToString() });
                    contractViewModel.WorkerId = workerId;
                }
                if (contractId.HasValue)
                {
                    //contractViewModel.ContractStatusList = entities.GetAllContractStatus().ToList().Select(x => new SelectListItem { Text = x.ContractStatusName, Value = x.ContractStatusId.ToString() });
                    var result = entities.GetContractByContractId(contractId, clientId).FirstOrDefault();
                    if (result != null)
                    {
                        TimeSpan actualDuration = TimeSpan.FromMinutes((double)(result.ActualDuration.HasValue ? result.ActualDuration.Value / 60000 : 0));
                        contractViewModel.ActualDuration = string.Format("{0} days, {1} hours, {2} minutes", actualDuration.Days, actualDuration.Hours, actualDuration.Minutes);
                        contractViewModel.ContractId = result.ContractId;
                        contractViewModel.ContractEndDate = result.EndDate;
                        contractViewModel.COntractStatusId = result.ContractStatusId;
                        contractViewModel.EndReason = result.EndReason;
                        contractViewModel.ContractEndDate = result.EndDate;
                        contractViewModel.EstimatedDuration = result.EstimateDuration;
                        contractViewModel.FixedRate = result.FixedRate;
                        contractViewModel.HourlyRate = result.HourlyRate;
                        contractViewModel.JobId = result.JobId;
                        contractViewModel.JobStartDate = result.StartDate;
                        contractViewModel.TimeUnitId = result.TimeUnitId;
                        contractViewModel.WeeklyHourLimit = result.HoursLimit;
                        contractViewModel.WorkerId = result.WorkerId;
                        contractViewModel.JobTitle = result.JobTitle;
                        contractViewModel.JobTypeId = result.JobTypeId;

                        contractViewModel.UserRatingsViewModel.UserRatingId = result.UserRatingId;
                        contractViewModel.UserRatingsViewModel.SkillRating = result.Skill;
                        contractViewModel.UserRatingsViewModel.QualityRating = result.Quality;
                        contractViewModel.UserRatingsViewModel.AvailabilityRating = result.Availability;
                        contractViewModel.UserRatingsViewModel.DeadlineRating = result.Deadline;
                        contractViewModel.UserRatingsViewModel.CommunicationRating = result.Communication;
                        contractViewModel.UserRatingsViewModel.CooperationRating = result.Cooperation;
                        contractViewModel.UserRatingsViewModel.Comment = result.Comment;
                        contractViewModel.UserRatingsViewModel.UserId = result.UserId;
                    }
                }
                var workerInformation = entities.GetUserById(workerId).FirstOrDefault();
                if (workerInformation != null)
                {
                    contractViewModel.FirstName = workerInformation.FirstName;
                    contractViewModel.LastName = workerInformation.LastName;
                    contractViewModel.UserName = workerInformation.UserName;
                    contractViewModel.WorkerHourlyRate = workerInformation.UserHourlyRate;
                    contractViewModel.Email = workerInformation.Email;
                }
                if (jobBidId.HasValue)
                {
                    var jobBid = entities.GetJobBidById(jobBidId).FirstOrDefault();
                    if (jobBid != null)
                    {
                        contractViewModel.JobTitle = jobBid.JobTitle;
                        contractViewModel.JobTypeId = jobBid.JobTypeId;
                        if (jobBid.JobTypeId == (long)JobTypeEnum.Fixed)
                            contractViewModel.FixedRate = jobBid.Rate;
                        if (jobBid.JobTypeId == (long)JobTypeEnum.Hourly)
                            contractViewModel.HourlyRate = jobBid.Rate;
                        contractViewModel.JobBidId = jobBidId;
                        contractViewModel.JobId = jobBid.JobId;
                    }
                }
                return contractViewModel;
            }
        }

        public long? InsertNotification(long? Contractid,ContractViewModel model,ApplicationUser applicationUser)
        {
            using(var entities = new Entities())
            {
                var jobBid = entities.GetJobByJobId(model.JobId).FirstOrDefault();
                return entities.InsertNotification(
                          Contractid,
                          model.WorkerId,
                          model.JobId ,
                          "New contract for job "+ jobBid.JobTitle + " is assigned to you by client " + applicationUser.FirstName+" "+applicationUser.LastName
                    );
            }

        }

        public long? InsertUpdateContract(ContractViewModel model)
        {
            using (var entities = new Entities())
            {
                return entities.InsertUpdateContract(
                          model.ContractId,
                          model.WorkerId,
                          model.JobId,
                          model.HourlyRate,
                          model.FixedRate,
                          model.EstimatedDuration,
                          model.WeeklyHourLimit,
                          model.TimeUnitId,
                          model.COntractStatusId,
                          model.ContractEndDate,
                          model.EndReason,
                          model.CreatedModifiedByUserId,
                          model.IsEndingContract,
                          model.UserRatingsViewModel.UserRatingId,
                          model.UserRatingsViewModel.SkillRating,
                          model.UserRatingsViewModel.QualityRating,
                          model.UserRatingsViewModel.AvailabilityRating,
                          model.UserRatingsViewModel.DeadlineRating,
                          model.UserRatingsViewModel.CommunicationRating,
                          model.UserRatingsViewModel.CooperationRating,
                          model.UserRatingsViewModel.Comment,
                          model.UserRatingsViewModel.UserId,
                          model.HourlyRateFromOrToDate
                      ).FirstOrDefault().ContractId;
            }
        }

        public IEnumerable<ContractsGridViewModel> GetContractsGridData(string workerId, string clientId)
        {
            using (var entities = new Entities())
            {
                return entities.GetAllContractsByWorkerIdAndClientId(workerId, clientId).ToList().Select(x => new ContractsGridViewModel
                {
                    ContractId = x.ContractId,
                    JobTitle = x.JobTitle,
                    StartDate = x.StartDate,
                    JobRate = x.HourlyRate.HasValue?x.HourlyRate:x.FixedRate,
                    JobType=x.JobTypeName,
                    ContractStatusName = x.ContractStatusName
                });
            }
        }

        public ContractViewModel GetContractByContractIdOrWorkerAndJobId(long? contractId = null, string workerId = null, long? jobId = null)
        {
            using (var entities = new Entities())
            {
                ContractViewModel contractViewModel = null;
                var contract = entities.GetContractByContractIdOrWorkerAndJobId(contractId, workerId, jobId).FirstOrDefault();
                if (contract != null)
                {
                    contractViewModel = new ContractViewModel();
                    contractViewModel.ActualDuration = TimeSpan.FromMilliseconds((double)(contract.ActualDuration.HasValue ? contract.ActualDuration.Value : 0)).ToString("hh\\:mm");
                    contractViewModel.ContractEndDate = contract.EndDate;
                    contractViewModel.ContractId = contract.ContractId;
                    contractViewModel.COntractStatusId = contract.ContractStatusId;
                    contractViewModel.EndReason = contract.EndReason;
                    contractViewModel.EstimatedDuration = contract.EstimateDuration;
                    contractViewModel.HourlyRate = contract.HourlyRate;
                    contractViewModel.JobId = contract.JobId;
                    //contractViewModel.JobRatings = contract.JobRating;
                    contractViewModel.JobStartDate = contract.StartDate;
                    contractViewModel.TimeUnitId = contract.TimeUnitId;
                    contractViewModel.WeeklyHourLimit = contract.HourlyRate;
                    contractViewModel.WorkerId = contract.WorkerId;
                    contractViewModel.FixedRate = contract.FixedRate;
                }
                return contractViewModel;
            }
        }

        public IEnumerable<GetWorkerViewModel> GetClientTeam(string clientId, long? jobId, bool? showActiveWorkers)
        {
            using (var entities = new Entities())
            {
                return entities.GetClientTeam(clientId,jobId,showActiveWorkers).ToList().Select(x => new GetWorkerViewModel
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Email = x.Email,
                    Country = x.Country1,
                    ProfileImage = x.ProfilePic,
                    WorkerId = x.Id,
                    HourlyRate = x.UserHourlyRate,
                    Rating = x.UserRating
                });
            }
        }

      

        public IEnumerable<GetJobsViewModel> GetJobListForHireWorkerScreen(string workerId, string clientId)
        {
            using (var entities = new Entities())
            {
                return entities.GetJobListForHireWorkerScreen(clientId, workerId).ToList().Select(x => new GetJobsViewModel
                {
                    JobTitle = x.JobTitle,
                    JobId = x.JobId,
                    JobTypeId = x.JobTypeId,
                    FixedRate = x.FixedRate
                });
            }
        }

        public ContractViewModel GetContractForReviewByContractId(long? contractId)
        {
            using (var entities = new Entities())
            {
                return entities.GetContractForReviewByContractId(contractId).Select(x => new ContractViewModel
                {
                    JobTitle = x.JobTitle,
                    ContractId = x.ContractId,
                    EstimatedDuration = x.EstimateDuration,
                    FixedRate = x.FixedRate,
                    HourlyRate = x.HourlyRate,
                    TimeUnitName = x.UnitName,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    JobTypeId = x.JobTypeId,
                    JobId = x.JobId,
                    WeeklyHourLimit = x.HoursLimit,
                    ClientUserName = x.UserName,
                    COntractStatusId = x.ContractStatusId
                }).FirstOrDefault();
            }
        }

        public void ApproveContract(long? contractId, string modifiedByUserId, long jobId)
        {
            using (var entities = new Entities())
            {
                if (contractId.HasValue && !string.IsNullOrEmpty(modifiedByUserId))
                    entities.ApproveContract(contractId, modifiedByUserId,jobId);
            }
        }

        public ContractViewModel GetManageContractScreenData(long? contractId, string userId)
        {
            using (var entities = new Entities())
            {
                ContractViewModel contractViewModel = null;
                var contract = entities.GetManageContractScreenData(contractId, userId).FirstOrDefault();
                if (contract != null)
                {
                    contractViewModel = new ContractViewModel();
                    contractViewModel.ContractId = contract.ContractId;
                    contractViewModel.EstimatedDuration = contract.EstimateDuration;
                    contractViewModel.WeeklyHourLimit = contract.HoursLimit;
                    contractViewModel.FixedRate = contract.FixedRate;
                    contractViewModel.EndReason = contract.EndReason;
                    contractViewModel.COntractStatusId = contract.ContractStatusId;
                    contractViewModel.JobTitle = contract.JobTitle;
                    contractViewModel.JobTypeId = contract.JobTypeId;
                    contractViewModel.JobTypeName = contract.JobTypeName;
                    contractViewModel.HourlyRate = contract.HourlyRate;
                    contractViewModel.UserRatingsViewModel.UserRatingId = contract.UserRatingId;
                    contractViewModel.UserRatingsViewModel.SkillRating = contract.Skill;
                    contractViewModel.UserRatingsViewModel.QualityRating = contract.Quality;
                    contractViewModel.UserRatingsViewModel.AvailabilityRating = contract.Availability;
                    contractViewModel.UserRatingsViewModel.DeadlineRating = contract.Deadline;
                    contractViewModel.UserRatingsViewModel.CommunicationRating = contract.Communication;
                    contractViewModel.UserRatingsViewModel.CooperationRating = contract.Cooperation;
                    contractViewModel.UserRatingsViewModel.Comment = contract.Comment;
                    contractViewModel.ContractEndDate = contract.EndDate;
                    TimeSpan actualDuration = TimeSpan.FromMinutes((double)(contract.ActualDuration.HasValue ? contract.ActualDuration.Value / 60000 : 0));
                    contractViewModel.ActualDuration = string.Format("{0} days, {1} hours, {2} minutes", actualDuration.Days, actualDuration.Hours, actualDuration.Minutes);
                }
                return contractViewModel;
            }
        }

        public void UpdateContractForWorker(ContractViewModel model)
        {
            using (var entities = new Entities())
            {
                entities.UpdateContractForWorker(model.ContractId,
                                                 model.FixedRate,
                                                 model.HourlyRate,
                                                 model.WeeklyHourLimit,
                                                 model.IsEndingContract.ToString(),
                                                 Convert.ToBoolean(model.EndReason),
                                                 model.UserRatingsViewModel.SkillRating,
                                                 model.UserRatingsViewModel.QualityRating,
                                                 model.UserRatingsViewModel.AvailabilityRating,
                                                 model.UserRatingsViewModel.DeadlineRating,
                                                 model.UserRatingsViewModel.CommunicationRating,
                                                 model.UserRatingsViewModel.CooperationRating,
                                                 model.UserRatingsViewModel.Comment,
                                                 model.WorkerId);
            }
        }
    }
}
