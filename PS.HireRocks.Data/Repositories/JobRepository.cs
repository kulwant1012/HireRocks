using PS.HireRocks.Data.Database;
using PS.HireRocks.Data.Helpers;
using PS.HireRocks.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using PS.HireRocks.Data.Helpers;

namespace PS.HireRocks.Data.Repositories
{
    public class JobRepository : BaseRepository
    {
        public async Task<Result<PostJobViewModel>> GetPostJobScreenData(long? jobId, string clientId)
        {
            return await TryInvoke(() =>
                   {
                       using (var entities = new Entities())
                       {
                           PostJobViewModel postJobViewModel = new PostJobViewModel();
                           postJobViewModel.SkillList = entities.GetAllSkills().Select(x => new SkillViewModel { SkillId = x.SkillId, SkillName = x.SkillName }).ToList();
                           postJobViewModel.JobCategoryList = entities.GetAllJobCategories().Select(x => new SelectListItem { Text = x.CategoryName, Value = x.JobCategoryId.ToString() }).ToList();
                           postJobViewModel.AllJobSubCategoryList = entities.GetAllJobSubCategories().Select(x => new JobSubCategoryViewModel { JobCategoryId = x.JobCategoryId, JobSubCategoryId = x.JobSubCategoryId, SubCategoryName = x.SubCategoryName }).ToList();
                           postJobViewModel.TimeUnits = entities.GetAllTimeUnits().Select(x => new SelectListItem { Text = x.UnitName, Value = x.TimeUnitId.ToString() }).ToList();
                           postJobViewModel.WorkerTypeList = entities.GetAllWorkerTypes().Select(x => new SelectListItem { Text = x.Name, Value = x.WorkerTypeId.ToString() }).ToList();
                           postJobViewModel.JobTypeList = entities.GetAllJobTypes().Select(x => new SelectListItem { Text = x.JobTypeName, Value = x.JobTypeId.ToString() }).ToList();
                           postJobViewModel.ExperienceLevelList = entities.GetAllExperienceLevels().Select(x => new SelectListItem { Text = x.LevelName, Value = x.ExperianceLevelId.ToString() }).ToList();

                           if (jobId.HasValue && !string.IsNullOrEmpty(clientId))
                           {
                               var job = entities.GetJobByJobIdAndClientId(jobId.Value, clientId).FirstOrDefault();
                               if (job != null)
                               {
                                   postJobViewModel.JobId = job.JobId;
                                   postJobViewModel.JobTitle = job.JobTitle;
                                   postJobViewModel.ClientId = job.ClientId;
                                   postJobViewModel.FixedRate = job.FixedRate;
                                   postJobViewModel.JobStartDate = job.JobStartDate;
                                   postJobViewModel.JobEndDate = job.JobEndDate;
                                   postJobViewModel.Description = job.JobDescription;
                                   postJobViewModel.EstimateDuratoion = job.EstimateDuration;
                                   postJobViewModel.ExperienceLevelId = job.ExperienceLevelExperianceLevelId;
                                   postJobViewModel.IsActive = job.IsActive;
                                   postJobViewModel.IsHiringClosed = job.IsHiringClosed;
                                   postJobViewModel.JobSubCategoryId = job.JobSubCategoryId;
                                   postJobViewModel.JobTypeId = job.JobTypeId;
                                   postJobViewModel.Max_PRF_Rate = job.Max_PRF_Rate;
                                   postJobViewModel.Min_PRF_Rate = job.Min_PRF_Rate;
                                   postJobViewModel.Locality_PRF = job.Locality_PRF;
                                   var attachments = entities.GetJobAttachmentsByJobId(job.JobId).ToList();
                                   if (attachments != null && attachments.Count > 0)
                                       postJobViewModel.JobAttachmentsList = attachments.Select(x => new JobAttachmentsViewModel { JobId = x.JobId, JobAttachmentId = x.JobAttachmentId, AttachmentName = x.AttachmentName }).ToList();
                                   var skillIdsRequiredForJob = job.SkillsRequiredForJobIds.Split(',');
                                   var skillsSelectedList = postJobViewModel.SkillList.Where(x => skillIdsRequiredForJob.Contains(x.SkillId.ToString())).ToList();
                                   postJobViewModel.SkillRequiredForJobIds = string.Join(", ", skillsSelectedList.Select(x => x.SkillName));
                                   skillsSelectedList.ForEach(x => x.IsSelected = true);
                                   postJobViewModel.TimeUnitId = job.TimeUnitId;
                                   postJobViewModel.WorkerTypeId = job.WorkerTypeId;
                                   var subCategoriesList = postJobViewModel.AllJobSubCategoryList.Where(x => x.JobSubCategoryId == job.JobSubCategoryId);
                                   if (subCategoriesList != null && subCategoriesList.Count() > 0)
                                   {
                                       postJobViewModel.JobCategoryId = subCategoriesList.FirstOrDefault().JobCategoryId;
                                       postJobViewModel.JobSubCategoryList = subCategoriesList.Select(x => new SelectListItem { Text = x.SubCategoryName, Value = x.JobSubCategoryId.ToString() }).ToList();
                                   }
                               }
                           }
                           return postJobViewModel;
                       }
                   });
        }

        public async Task<Result> InsertUpdateJob(PostJobViewModel model)
        {
            return await TryInvoke(() =>
            {
                using (var entities = new Entities())
                {
                    entities.insertupdatejob(model.JobId, model.JobTitle, model.Description, model.IsActive, model.IsHiringClosed, model.WorkerTypeId, model.ExperienceLevelId, model.JobTypeId, model.JobSubCategoryId, model.SkillRequiredForJobIds, model.JobStartDate, model.JobEndDate, model.EstimateDuratoion, model.TimeUnitId, model.ClientId, model.JobAttachmentsXML, model.Min_PRF_Rate, model.Max_PRF_Rate, model.FixedRate, model.Locality_PRF);
                }
            });
        }

        public async Task<Result<List<GetJobsViewModel>>> GetJobsByClientId(string clientId)
        {
            return await TryInvoke(() =>
            {
                using (var entities = new Entities())
                {
                    var jobs = entities.GetJobsByClientId(clientId).ToList();
                    if (jobs != null && jobs.Count > 0)
                        return jobs.Select(x => new GetJobsViewModel { JobId = x.JobId, JobTitle = x.JobTitle, JobStartDate = x.JobStartDate, JobEndDate = x.JobEndDate, IsActive = x.IsActive, IsHiringClosed = x.IsHiringClosed, HiringClosed = x.IsHiringClosed ? "Yes" : "No", Active = x.IsActive ? "Yes" : "No" }).ToList();
                    else
                        return null;
                }
            });
        }

        public async Task<Result<ViewJobViewModel>> GetJobDetailScreenDataByJobId(long? jobId)
        {
            return await TryInvoke<ViewJobViewModel>(() =>
            {
                using (var entities = new Entities())
                {
                    ViewJobViewModel viewJobViewModel = new ViewJobViewModel();
                    var job = entities.GetJobByJobId(jobId).FirstOrDefault();
                    if (job != null)
                    {
                        viewJobViewModel.JobId = job.JobId;
                        viewJobViewModel.JobTitle = job.JobTitle;
                        viewJobViewModel.JobDescription = job.JobDescription;
                        viewJobViewModel.JobStartDate = job.JobStartDate;
                        viewJobViewModel.JobEndDate = job.JobEndDate;
                        viewJobViewModel.JobCategory = job.CategoryName;
                        viewJobViewModel.JobSubCategory = job.SubCategoryName;
                        viewJobViewModel.JobType = job.JobTypeName;
                        viewJobViewModel.EstimatedDuration = job.EstimateDuration;
                        viewJobViewModel.TimeUnit = job.UnitName;
                        viewJobViewModel.ExperienceLevel = job.LevelName;
                        viewJobViewModel.ClientName = job.FirstName + " " + job.LastName;
                        viewJobViewModel.WorkerType = job.WorkerType;
                        viewJobViewModel.Active = job.IsActive ? "Yes" : "No";
                        viewJobViewModel.HiringClosed = job.IsHiringClosed ? "Yes" : "No";
                        viewJobViewModel.Max_PRF_Rate = job.Max_PRF_Rate;
                        viewJobViewModel.Min_PRF_Rate = job.Min_PRF_Rate;
                        viewJobViewModel.Locality_PRF = job.Locality_PRF;
                        viewJobViewModel.FixedRate = job.FixedRate;
                        var jobAttachments = entities.GetJobAttachmentsByJobId(jobId).ToList();
                        if (jobAttachments != null && jobAttachments.Count > 0)
                        {
                            viewJobViewModel.JobAttachmentsList = jobAttachments.Select(x => x.AttachmentName).ToList();
                        }
                    }
                    var workerlist = entities.GetClientInfoByJobId(jobId).FirstOrDefault();
                    if (workerlist != null)
                    {
                        viewJobViewModel.ClientInfoViewModel.FirstName = workerlist.FirstName;
                        viewJobViewModel.ClientInfoViewModel.LastName = workerlist.LastName;
                        viewJobViewModel.ClientInfoViewModel.ProfileImage = workerlist.ProfilePic;
                        viewJobViewModel.ClientInfoViewModel.Rating = workerlist.UserRating;
                        viewJobViewModel.ClientInfoViewModel.TotalJobsPosted = workerlist.TotalJobsPosted;
                        viewJobViewModel.ClientInfoViewModel.Country = workerlist.Country1;
                    }
                    return viewJobViewModel;
                }
            });
        }

        public IEnumerable<ViewJobViewModel> GetJobsByFilter(FindJobFilters filter)
        {
            using (var entities = new Entities())
            {
                var result = entities.FindJobsByFilter(filter.JobName, filter.JobCategoryId, filter.JobSubCategoriesIds, filter.JobTypeId, filter.ExperienceLevelId, filter.WorkerId).ToList().Select(x => new ViewJobViewModel
                {
                    Active = x.IsActive ? "Yes" : "No",
                    JobCategory = x.CategoryName,
                    ClientUserName = x.UserName,
                    EstimatedDuration = x.EstimateDuration,
                    //ExperienceLevel=x.
                    HiringClosed = x.IsHiringClosed ? "Yes" : "No",
                    JobDescription = x.JobDescription ?? "No job descriptions available",
                    JobEndDate = x.JobEndDate,
                    JobId = x.JobId,
                    JobStartDate = x.JobStartDate,
                    JobSubCategory = x.SubCategoryName,
                    JobTitle = x.JobTitle,
                    JobType = x.JobTypeName,
                    JobTypeId = x.JobTypeId,
                    FixedRate = x.FixedRate,
                    //SkillsRequiredForJob=
                    TimeUnit = x.UnitName,
                    WorkerType = x.WorkerType,
                    ApplyButtonText = x.ApplyButtonText,
                });
                return result;
            }
        }

        public FindJobScreenViewModel GetFindJobScreenData(string workerId)
        {
            using (var entities = new Entities())
            {
                FindJobScreenViewModel findJobScreenViewModel = new FindJobScreenViewModel();
                findJobScreenViewModel.JobCategoriesList = entities.GetAllJobCategories().ToList().Select(x => new SelectListItem { Text = x.CategoryName, Value = x.JobCategoryId.ToString() });
                findJobScreenViewModel.AllJobSubCategoryList = entities.GetAllJobSubCategories().Select(x => new JobSubCategoryViewModel { JobCategoryId = x.JobCategoryId, JobSubCategoryId = x.JobSubCategoryId, SubCategoryName = x.SubCategoryName }).ToList();
                findJobScreenViewModel.JobTypeList = entities.GetAllPaymentMethods().ToList().Select(x => new SelectListItem { Text = x.PaymentMethodName, Value = x.PaymentMethodId.ToString() });
                findJobScreenViewModel.ExperienceLevelList = entities.GetAllExperienceLevels().ToList().Select(x => new SelectListItem { Text = x.LevelName, Value = x.ExperianceLevelId.ToString() });
                var workerRate = entities.GetWorkerRate(workerId).FirstOrDefault();
                findJobScreenViewModel.WorkerRate = workerRate;
                //if (workerRate != null)
                //{
                //    findJobScreenViewModel.WorkerRate = workerRate.
                //}

                return findJobScreenViewModel;
            }
        }

        public List<ContractViewModel> GetWorkersBidForJob(long? JobId, string clientId)
        {
            using (var entities = new Entities())
            {
                List<ContractViewModel> contractViewModel = new List<ContractViewModel>();
                var workers = entities.GetWorkersBidForJob(JobId, clientId).ToList();
                contractViewModel = workers.Select(x => new ContractViewModel
                {
                    WorkerId = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    ProfileImage = x.ProfilePic,
                    ProfileTitle = x.ProfileTitle,
                    HourlyRate = x.UserHourlyRate,
                    JobRate = x.Rate,
                    Country = x.Country1,
                    Rating = x.UserRating,
                    JobId = x.JobId,
                    IsHired = (bool)x.IsHired,
                    IsDenied = (bool)x.IsDenied,
                    CoverLetter = x.CoverLetter,
                    JobBidId = x.JobBidId,
                    AttachmentsList = string.IsNullOrWhiteSpace(x.Attachments) ? null : XMLToObjectConverter.ConvertXMLToObject<List<JobAttachmentsViewModel>>(x.Attachments),
                    HireButtonText = x.HireButtonText
                }).ToList();
                return contractViewModel;
            }
        }

        public ContractViewModel GetTimeUnitList()
        {
            ContractViewModel contractViewModel = new ContractViewModel();
            using (var entities = new Entities())
            {
                contractViewModel.TimeUnitsList = entities.GetAllTimeUnits().ToList().Select(x => new SelectListItem { Text = x.UnitName, Value = x.TimeUnitId.ToString() });
            }
            return contractViewModel;
        }

        public bool JobRequestDenied(long? jobBidId)
        {
            using (var entities = new Entities())
            {
                return entities.JobRequestDenied(jobBidId) > 0 ? true : false;
            }
        }

        public List<WorkerJobsViewModel> GetJobsByWorkerId(string workerId, bool? isActive)
        {
            using (var entities = new Entities())
            {
                var jobs = entities.GetJobsByWorkerId(workerId, isActive).ToList();
                return jobs.Select(x => new WorkerJobsViewModel
                {
                    ContractId = x.ContractId,
                    HourlyRate = x.JobTypeId == (long)Helpers.JobTypeEnum.Fixed ? x.FixedRate : x.HourlyRate,
                    HoursLimit = x.HoursLimit,
                    JobTypeId = x.JobTypeId,
                    JobTypeName = x.JobTypeName,
                    JobTitle = x.JobTitle,
                    StartDate = x.StartDate,
                    ContractStatus = x.ContractStatus


                }).ToList();
            }
        }
    }
}
