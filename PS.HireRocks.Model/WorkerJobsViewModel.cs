using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.HireRocks.Model
{
    public class WorkerJobsViewModel
    {
        public string JobTitle { get; set; }
        public DateTime? StartDate { get; set; }
        public long ContractId { get; set; }
        public decimal? HoursLimit { get; set; }
        public decimal? HourlyRate { get; set; }
        public decimal? FixedRate { get; set; }
        public long? JobTypeId { get; set; }
        public string JobTypeName { get; set; }
        public string ContractStatus { get; set; }
        public string ContractStatusId { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
