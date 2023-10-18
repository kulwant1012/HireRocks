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
    
    public partial class GetJobByJobId_Result
    {
        public long JobId { get; set; }
        public string JobTitle { get; set; }
        public string JobDescription { get; set; }
        public Nullable<System.DateTime> JobStartDate { get; set; }
        public Nullable<System.DateTime> JobEndDate { get; set; }
        public string CategoryName { get; set; }
        public string SubCategoryName { get; set; }
        public string JobTypeName { get; set; }
        public Nullable<decimal> EstimateDuration { get; set; }
        public string Locality_PRF { get; set; }
        public Nullable<decimal> Min_PRF_Rate { get; set; }
        public Nullable<decimal> Max_PRF_Rate { get; set; }
        public Nullable<decimal> FixedRate { get; set; }
        public string LevelName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string WorkerType { get; set; }
        public bool IsActive { get; set; }
        public string UnitName { get; set; }
        public bool IsHiringClosed { get; set; }
    }
}