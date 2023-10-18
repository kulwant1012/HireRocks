using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.HireRocks.Model
{
    public class ReportInfoViewModel
    {
        public string WorkerId { get; set; }
        public string rangeType { get; set; }
        public DateTime fromdate { get; set; }
        public DateTime todate { get; set; }
        public bool type { get; set; }
        public long? JobId { get; set; }
    }
}
