//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PS.HireRocks.Data.Database
{
    using System;
    using System.Collections.Generic;
    
    public partial class JobType
    {
        public JobType()
        {
            this.Jobs = new HashSet<Job>();
        }
    
        public long JobTypeId { get; set; }
        public string JobTypeName { get; set; }
        public bool IsActive { get; set; }
    
        public virtual ICollection<Job> Jobs { get; set; }
    }
}
