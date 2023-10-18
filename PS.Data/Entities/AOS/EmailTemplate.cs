using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PS.Data.Entities.AOS
{
    [DataContract]
    public class EmailTemplate:Entity
    {
        [DataMember]
        public string TemplateBody { get; set; }
    }
}
