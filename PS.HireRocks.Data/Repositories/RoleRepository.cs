using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

using PS.HireRocks.Model;
using PS.HireRocks.Data.Database;
using PS.HireRocks.Data.Helpers;

namespace PS.HireRocks.Data.Repositories
{
    public class RoleRepository
    {
        public IEnumerable<RoleModel> GetAllRoles()
        {
            using (var entities = new Entities())
            {
                return entities.Set<AspNetRole>().AsQueryable().Where(x => x.Id != RoleIdConstants.Supervisor).Select(x => new RoleModel { Id = x.Id, Name = x.Name }).ToList();
            }
        }

        public IEnumerable<AccountTypeViewModel> GetAccountTypes()
        {
            using (var entities = new Entities())
            {
                return entities.Set<AccountType>().AsQueryable().Select(x => new AccountTypeViewModel { AccountTypeId = x.AccountTypeId.ToString(), AccountTypeName = x.AccountTypeName }).ToList();
            }
        }
        public IEnumerable<AccountTypeViewModel> GetAccountTypesView()
        {
            using (var entities = new Entities())
            {
                return entities.Set<AccountType>().AsQueryable().Select(x => new AccountTypeViewModel { AccountTypeId = x.AccountTypeId.ToString(), AccountTypeName = x.AccountTypeName }).ToList();
            }
        }
        
    }
}
