using System.Runtime.Serialization;
using Microsoft.AspNet.Identity.EntityFramework;

namespace PS.HireRocks.Model
{
    [DataContract]
    public class ApplicationUser : IdentityUser
    {
        [DataMember]
        public override string Id { get; set; }


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
        public bool IsEmailVerified { get; set; }
        public bool IsPhoneVerified { get; set; }
        public string EmailVerificationCode { get; set; }
        public string PhoneVerificationCode { get; set; }
        public string ForgotPasswordToken { get; set; }
        public bool IsProfileCompleted { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }
    }
}
