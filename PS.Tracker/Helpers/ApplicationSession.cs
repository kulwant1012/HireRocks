using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PS.Tracker.Model;

namespace PS.Tracker.Helpers
{
    public static class ApplicationSession
    {
        public static string UserId { get; set; }
        public static int? ProjectId { get; set; }
    }
}
