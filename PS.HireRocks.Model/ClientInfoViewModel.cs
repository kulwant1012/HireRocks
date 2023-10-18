using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.HireRocks.Model
{
  public  class ClientInfoViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal? Rating { get; set; }
        public decimal? TotalJobsPosted { get; set; }
        public string Country { get; set; }
        public string ProfileImage { get; set; }

    }
}
