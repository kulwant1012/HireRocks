using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.HireRocks.Model
{
    public class GetUserByIdViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public decimal? UserHourlyRate { get; set; }
        public string ProfileImage { get; set; }
        public string Country { get; set; }
        public decimal? Rating { get; set; }
        public string ProfileTitle { get; set; }
        public string VideoIntroduction { get; set; }
        public decimal? TotalTimeBurned { get; set; }
        public long? JobsCompleted { get; set; }
    }
}
