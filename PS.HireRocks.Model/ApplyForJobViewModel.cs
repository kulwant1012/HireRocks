using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PS.HireRocks.Model
{
    public class ApplyForJobViewModel
    {
        [Required(ErrorMessage = "Please select job")]
        public long? JobId { get; set; }
        public long? JobTypeId { get; set; }
        public string JobTypeName { get; set; }
        [Required(ErrorMessage = "Please specify rate")]
        public decimal Rate { get; set; }
        [AllowHtml]
        public string CoverLetter { get; set; }
        public string WorkerId { get; set; }
        public string ApplyJobAttachmentsXML { get; set; }
        public List<JobAttachmentsViewModel> InsertedAttachmentsNamesList { get; set; }
        public string JobName { get; set; }
        public long JobBidId { get; set; }
        public string UserName { get; set; }
        public string ClientUserName { get; set; }
    }
}
