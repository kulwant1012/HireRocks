using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.HireRocks.Model
{
    public class InsertCaptureResultViewModel
    {
        public decimal? TotalBurnedHours { get; set; }
        public decimal? WeeklyBurnedHours { get; set; }
        public decimal? TodayBurnedHours { get; set; }
        public bool? IsContractOpen { get; set; }
    }
}
