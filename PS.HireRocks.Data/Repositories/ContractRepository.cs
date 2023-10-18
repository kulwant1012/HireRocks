using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PS.HireRocks.Data.Database;
using PS.HireRocks.Model;

namespace PS.HireRocks.Data.Repositories
{
    public class ContractRepository
    {
        public IEnumerable<ContractEndOrDenyReasonViewModel> GetContractEndReasonsByRoleId(string roleId)
        {
            using (var entities = new Entities())
            {
                return entities.GetContractEndReasonsByRoleId(roleId).ToList().Select(x => new ContractEndOrDenyReasonViewModel
                {
                    ContractEndOrDenyReasonId = x.ContractEndReasonId,
                    EndOrDenyReason = x.EndReason
                });
            }
        }

        public IEnumerable<ContractEndOrDenyReasonViewModel> GetContractDenyReasonsByRoleId(string roleId)
        {
            using (var entities = new Entities())
            {
                return entities.GetContractDenyReasonsByRoleId(roleId).ToList().Select(x => new ContractEndOrDenyReasonViewModel
                {
                    ContractEndOrDenyReasonId = x.ContractDenyReasonId,
                    EndOrDenyReason = x.DenyReason
                });
            }
        }

        public void RejectContract(RejectContractViewModel model)
        {
            using (var entities = new Entities())
            {
                entities.RejectContract(model.ContractId,model.ModifiedByUserId, model.EndReasonId == (long)PS.HireRocks.Data.Helpers.ContractDenyReasonEnum.Other ? model.OtherEndReason : model.EndReason);
            }
        }
    }
}
