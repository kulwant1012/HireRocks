using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PS.Data.Entities.AOS
{
    [DataContract]
    public class ActivityTool : Entity
    {
        [DataMember]
        public string ToolName { get; set; }
        [DataMember]
        public string ToolDescription { get; set; }
    }
}
