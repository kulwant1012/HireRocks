using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PS.Data.Entities.AOS.Common
{
    public class UserApi
    {
        public int id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string login_id { get; set; }

        public override string ToString()
        {
            return first_name + last_name;
        }
    }
}
