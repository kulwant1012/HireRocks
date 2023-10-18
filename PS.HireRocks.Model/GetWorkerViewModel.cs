using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.HireRocks.Model
{
    public class GetWorkerViewModel
    {
        public string WorkerId { get; set; }
        public string ClientId { get; set; }
        public string Skills { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string ProfileTitle { get; set; }
        public string Country { get; set; }
        public string ProfileImage { get; set; }
        public decimal? HourlyRate { get; set; }
        public decimal? Rating { get; set; }
        public string Email { get; set; }
        public bool IsHired { get; set; }
    }
}
