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
    
    public partial class AspNetUser
    {
        public AspNetUser()
        {
            this.AspNetUserClaims = new HashSet<AspNetUserClaim>();
            this.AspNetUserLogins = new HashSet<AspNetUserLogin>();
            this.Contracts = new HashSet<Contract>();
            this.Contracts1 = new HashSet<Contract>();
            this.Jobs = new HashSet<Job>();
            this.JobsBids = new HashSet<JobsBid>();
            this.Messages = new HashSet<Message>();
            this.Messages1 = new HashSet<Message>();
            this.Contracts2 = new HashSet<Contract>();
            this.Notifications = new HashSet<Notification>();
            this.ReadyMadeTools = new HashSet<ReadyMadeTool>();
            this.Teams = new HashSet<Team>();
            this.Teams1 = new HashSet<Team>();
            this.UserRatings = new HashSet<UserRating>();
            this.UserPortfolios = new HashSet<UserPortfolio>();
            this.UserProfiles = new HashSet<UserProfile>();
            this.AspNetRoles = new HashSet<AspNetRole>();
            this.UserAccountTypes = new HashSet<UserAccountType>();
        }
    
        public string Id { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City1 { get; set; }
        public string City2 { get; set; }
        public string State1 { get; set; }
        public string State2 { get; set; }
        public string Country1 { get; set; }
        public string Country2 { get; set; }
        public string HomePhone { get; set; }
        public string WorkPhone { get; set; }
        public string CellPhone { get; set; }
        public string Email { get; set; }
        public string ProfilePic { get; set; }
        public Nullable<bool> IsEmailVerified { get; set; }
        public Nullable<bool> IsPhoneVerified { get; set; }
        public string Discriminator { get; set; }
        public string EmailVerificationCode { get; set; }
        public string PhoneVerificationCode { get; set; }
        public string ForgotPasswordToken { get; set; }
        public Nullable<bool> IsProfileCompleted { get; set; }
    
        public virtual ICollection<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual ICollection<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual ICollection<Contract> Contracts { get; set; }
        public virtual ICollection<Contract> Contracts1 { get; set; }
        public virtual ICollection<Job> Jobs { get; set; }
        public virtual ICollection<JobsBid> JobsBids { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
        public virtual ICollection<Message> Messages1 { get; set; }
        public virtual ICollection<Contract> Contracts2 { get; set; }
        public virtual ICollection<Notification> Notifications { get; set; }
        public virtual ICollection<ReadyMadeTool> ReadyMadeTools { get; set; }
        public virtual ICollection<Team> Teams { get; set; }
        public virtual ICollection<Team> Teams1 { get; set; }
        public virtual ICollection<UserRating> UserRatings { get; set; }
        public virtual ICollection<UserPortfolio> UserPortfolios { get; set; }
        public virtual ICollection<UserProfile> UserProfiles { get; set; }
        public virtual ICollection<AspNetRole> AspNetRoles { get; set; }
        public virtual ICollection<UserAccountType> UserAccountTypes { get; set; }
    }
}