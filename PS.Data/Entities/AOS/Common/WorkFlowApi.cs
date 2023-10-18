using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PS.Data.Entities.AOS.Common
{
    public class WorkFlowApi
    {
        public int id { get; set; }
        public string order { get; set; }
        public string name { get; set; }
        public string color { get; set; }

        public override string ToString()
        {
            return name;
        }
    }
}
