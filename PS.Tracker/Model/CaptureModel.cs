using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Tracker.Model
{
    public class CaptureModel
    {
        public long CaptureId { get; set; }
        public int PlanningId { get; set; }
        public int KeyCount { get; set; }
        public int MouseCount { get; set; }
        public string KeyboardCapture { get; set; }
        public string MouseCapture { get; set; }
        public string ScreenCaptureThumbnailImage { get; set; }
        public string ScreenCaptureFullImage { get; set; }
        public DateTime CaptureDate { get; set; }
        public double TimeBurned { get; set; }
        public bool IsSynced { get; set; }
    }
}
