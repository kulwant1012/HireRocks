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
    
    public partial class UserRating
    {
        public long UserRatingId { get; set; }
        public Nullable<decimal> Skill { get; set; }
        public Nullable<decimal> Quality { get; set; }
        public Nullable<decimal> Availability { get; set; }
        public Nullable<decimal> Deadline { get; set; }
        public Nullable<decimal> Communication { get; set; }
        public Nullable<decimal> Cooperation { get; set; }
        public string Comment { get; set; }
        public string UserId { get; set; }
        public Nullable<long> ContractId { get; set; }
    
        public virtual AspNetUser AspNetUser { get; set; }
        public virtual Contract Contract { get; set; }
    }
}