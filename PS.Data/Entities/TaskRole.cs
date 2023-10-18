using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PS.Data.Entities
{
    [DataContract]
    public class TaskRole : QSpaceRole
    {
        [DataMember]
        public bool CanCreateTask { get; set; }

        [DataMember]
        public bool CanDeleteTask { get; set; }
    }   
}
