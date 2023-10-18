using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Data
{
    public class Notification
    {
        public string ActivityId { get; set; }

        public string Message { get; set; }

        public string UserId { get; set; }

        public ActivityOperationEnum Operation { get; set; }
    }

    public enum ActivityOperationEnum
    {
        Add = 1,
        Update = 2,
        Delete = 3
    }
}
