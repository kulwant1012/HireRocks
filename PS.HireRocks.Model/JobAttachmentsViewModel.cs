using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.HireRocks.Model
{
    public class JobAttachmentsViewModel
    {
        public long? JobAttachmentId { get; set; }
        public string AttachmentName { get; set; }
        public string AttachmentOriginalName { get; set; }
        public long? JobId { get; set; }
        public bool IsDeleted { get; set; }
    }

    public class InsertUpdateAttachmentsViewModel
    {
        public List<long> DeleteAttachmentIdsList { get; set; }
        public List<JobAttachmentsViewModel> InsertAttachmentsList { get; set; }
        public InsertUpdateAttachmentsViewModel()
        {
            DeleteAttachmentIdsList = new List<long>();
            InsertAttachmentsList = new List<JobAttachmentsViewModel>();
        }
    }
}
