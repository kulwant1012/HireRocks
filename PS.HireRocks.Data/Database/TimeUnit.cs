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
    
    public partial class TimeUnit
    {
        public TimeUnit()
        {
            this.Contracts = new HashSet<Contract>();
            this.Jobs = new HashSet<Job>();
        }
    
        public long TimeUnitId { get; set; }
        public string UnitName { get; set; }
        public bool IsActive { get; set; }
    
        public virtual ICollection<Contract> Contracts { get; set; }
        public virtual ICollection<Job> Jobs { get; set; }
    }
}
