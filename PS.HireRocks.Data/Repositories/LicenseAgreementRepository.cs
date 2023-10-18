using PS.HireRocks.Data.Database;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.HireRocks.Data.Repositories
{
    public class LicenseAgreementRepository
    {
        public string GetLicenseAgreementById(Int64 id)
        {
            using (var entities = new HireRocks.Data.Database.Entities())
            {
                var licenseAgreement =entities.GetLicenseAgreementById(id).FirstOrDefault();
                return licenseAgreement != null ? licenseAgreement.Agreement : string.Empty;
            }
        }
    }
}
