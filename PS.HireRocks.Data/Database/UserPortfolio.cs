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
    
    public partial class UserPortfolio
    {
        public long UserPortfolioId { get; set; }
        public string ProjectTitle { get; set; }
        public string ProjectDescription { get; set; }
        public Nullable<System.DateTime> ProjectStartDate { get; set; }
        public Nullable<System.DateTime> ProjectEndDate { get; set; }
        public Nullable<long> ContractId { get; set; }
        public string WorkerId { get; set; }
    
        public virtual AspNetUser AspNetUser { get; set; }
        public virtual Contract Contract { get; set; }
    }
}
