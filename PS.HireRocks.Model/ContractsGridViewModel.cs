using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.HireRocks.Model
{
    public class ContractsGridViewModel
    {
        public long? ContractId { get; set; }
        public string JobTitle { get; set; }
        public DateTime? StartDate { get; set; }
        public string ContractStatusName { get; set; }
        public decimal? JobRate { get; set; }
        public string JobType { get; set; }
        public string WorkerId { get; set; }
        public long? JobId { get; set; }
    }
}
