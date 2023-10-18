using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.HireRocks.Model
{
    public class RejectContractViewModel
    {
        [Display(Name = "Contract")]
        [Required(ErrorMessage = "Please select {0}")]
        public long? ContractId { get; set; }

        [Display(Name = "Contract end reason")]
        [Required(ErrorMessage = "Please select {0}")]
        public long? EndReasonId { get; set; }

        [Display(Name = "Other reason")]
        [Required(ErrorMessage = "Please specify {0}")]
        public string OtherEndReason { get; set; }

        public string ModifiedByUserId { get; set; }
        public string EndReason { get; set; }       
    }
}
