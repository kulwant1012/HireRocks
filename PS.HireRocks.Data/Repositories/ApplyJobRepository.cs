using PS.HireRocks.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.HireRocks.Data.Repositories
{
   public class ApplyJobRepository
    {
       public bool ApplyJob(ApplyForJobViewModel applyForJobViewModel)
       {
           using (var entities = new HireRocks.Data.Database.Entities())
           {
               return entities.ApplyJob(
                   applyForJobViewModel.JobId,
                   applyForJobViewModel.Rate,
                   applyForJobViewModel.WorkerId,
                   applyForJobViewModel.ApplyJobAttachmentsXML,
                   applyForJobViewModel.CoverLetter,
                   applyForJobViewModel.UserName
                   ) > 0 ? true : false;
           }
       }
    }
}
