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
    
    public partial class ContractDenyReason
    {
        public long ContractDenyReasonId { get; set; }
        public string DenyReason { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public string RoleId { get; set; }
    
        public virtual AspNetRole AspNetRole { get; set; }
    }
}
