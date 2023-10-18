using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.HireRocks.Model
{
   public  class CaptureViewModel
    {
        public long CaptureId { get; set; }
        public long? ContractId { get; set; }
        public int? KeyCount { get; set; }
        public int? MouseCount { get; set; }
        public string KeyboardCapture { get; set; }
        public string MouseCapture { get; set; }
        public string ScreenCaptureThumbnailImage { get; set; }
        public string ScreenCaptureFullImage { get; set; }
        public DateTime? CaptureDate { get; set; }
        public decimal? TimeBurned { get; set; }
        public bool IsSynced { get; set; }
        public bool? IsRejected { get; set; }
    }
}
