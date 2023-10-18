using PS.HireRocks.Data.Database;
using PS.HireRocks.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.HireRocks.Data.Repositories
{
   public class UserDetailRepository
    {
       public GetUserByIdViewModel GetWorkerInfoByWorkerId(string workerId)
       {
           using (var entities = new Entities())
           {
               return entities.GetUserById(workerId).Select(x => new GetUserByIdViewModel
               {
                   UserName = x.UserName,
                   Email = x.Email,
                   FirstName = x.FirstName,
                   LastName = x.LastName,
                   UserHourlyRate = x.UserHourlyRate,
                   Country = x.Country1,
                   VideoIntroduction = x.IntroductionVideo,
                   ProfileImage = x.ProfilePic,
                   ProfileTitle = x.ProfileTitle,
                   Rating = x.UserRating,
                   TotalTimeBurned = x.TimeBurned, 
                   JobsCompleted=x.JobsCompleted

               }).FirstOrDefault();
           }
       }

       public IEnumerable<WorkerJobsViewModel> GetWorkerJobs(string workerId)
       {
           using (var entities = new Entities())
           {
               var result= entities.GetWorkerJobsByWorkerId(workerId).ToList().Select(x => new WorkerJobsViewModel
               {
                   JobTitle=x.JobTitle,
                   StartDate=x.StartDate,
                   HourlyRate=x.HourlyRate,
                   FixedRate=x.FixedRate,
                   ContractStatusId=x.ContractStatusId=='1'?"Open":"Close",
                   EndDate=x.EndDate
               });
               return result;
           }
       }
    }
}
