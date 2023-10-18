using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PS.Data.Entities.AOS.Common
{
    public class ReleaseApi
    {
        public int id { get; set; }
        public string name { get; set; }
        public string release_type { get; set; }

        public override string ToString()
        {
            return name;
        }
    }


}
