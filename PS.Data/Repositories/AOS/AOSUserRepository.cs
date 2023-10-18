using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PS.Data.Entities.AOS;
using Raven.Client.Linq;
using System.IO;
using PS.Data.Entities;
using System.Configuration;
using PS.Data.Entities.AVS;
using System.Net.Mail;
namespace PS.Data.Repositories.AOS
{
    public class AOSUserRepository : Repository<PS.Data.Entities.AOS.User>, IAOSUserRepository
    {
        public ICollection<PS.Data.Entities.AOS.User> GetUsersByQSpaceId(string qSpaceId)
        {
            using (var session = DocumentStore.OpenSession())
            {
                var activities = session.Query<Activity>().Where(x => x.QSpaceID == qSpaceId);
                var activityUsers = session.Query<ActivityUser>().Customize(x => x.Include<PS.Data.Entities.AOS.User>(y => y.Id)).Where(x => x.ActivityId.In(activities.Select(y => y.Id)));
                var test = session.Load<PS.Data.Entities.AOS.User>(activityUsers.Select(x => x.UserId).Distinct());
                return session.Load<PS.Data.Entities.AOS.User>(activityUsers.Select(x => x.UserId).Distinct());
            }
        }

        public void InsertDefaultUserAndData()
        {
            using (var session = DocumentStore.OpenSession())
            {
                #region Insert default ststus
                var user = session.Query<PS.Data.Entities.AOS.User>().Where(x => x.Login == "Admin").FirstOrDefault();
                if (user == null)
                {
                    user = new PS.Data.Entities.AOS.User();
                    user.FirstName = "Admin";
                    user.LastName = "AMS";
                    user.Login = "Admin";
                    user.Password = "Test@123";
                    user.Roles = new UserRole[] { UserRole.Manager };
                    user.Email = "admin@eqosoft.com";
                    user.IsActive = true;
                    user.IsLocked = true;
                    session.Store(user);
                }
                #endregion

                #region Insert default status

                var activityStatus1 = session.Query<ActivityStatus>().Where(x => x.StatusName == "New Request").FirstOrDefault();
                if (activityStatus1 == null)
                {
                    activityStatus1 = new ActivityStatus();
                    activityStatus1.StatusName = "New Request";
                    session.Store(activityStatus1);
                }

                var activityStatus2 = session.Query<ActivityStatus>().FirstOrDefault(x => x.StatusName == "Approved");
                if (activityStatus2 == null)
                {
                    activityStatus2 = new ActivityStatus();
                    activityStatus2.StatusName = "Approved";
                    session.Store(activityStatus2);
                }

                var activityStatus3 = session.Query<ActivityStatus>().FirstOrDefault(x => x.StatusName == "In Progress");
                if (activityStatus3 == null)
                {
                    activityStatus3 = new ActivityStatus();
                    activityStatus3.StatusName = "In Progress";
                    session.Store(activityStatus3);
                }

                var activityStatus4 = session.Query<ActivityStatus>().FirstOrDefault(x => x.StatusName == "Ready For Testing");
                if (activityStatus4 == null)
                {
                    activityStatus4 = new ActivityStatus();
                    activityStatus4.StatusName = "Ready For Testing";
                    session.Store(activityStatus4);
                }

                var activityStatus5 = session.Query<ActivityStatus>().FirstOrDefault(x => x.StatusName == "Completed");
                if (activityStatus5 == null)
                {
                    activityStatus5 = new ActivityStatus();
                    activityStatus5.StatusName = "Completed";
                    session.Store(activityStatus5);
                }

                var activityStatus6 = session.Query<ActivityStatus>().FirstOrDefault(x => x.StatusName == "Rejected");
                if (activityStatus6 == null)
                {
                    activityStatus6 = new ActivityStatus();
                    activityStatus6.StatusName = "Rejected";
                    session.Store(activityStatus6);
                }

                #endregion

                #region Insert default dictionaries

                var dictionary1 = session.Query<KeywordDictionary>().FirstOrDefault(x => x.DictionaryName == "C#");
                if (dictionary1 == null)
                {
                    dictionary1 = new KeywordDictionary();
                    dictionary1.DictionaryName = "C#";
                    dictionary1.Keywords = new string[] 
                    {
                        "class",
                        "const",
                        "continue",
                        "decimal",
                        "default",
                        "delegate",
                        "do",
                        "double",
                        "else",
                        "enum",
                        "event",
                        "explicit",
                        "extern",
                        "false",
                        "finally",
                        "fixed",
                        "float",
                        "for",
                        "foreach",
                        "goto",
                        "if",
                        "implicit",
                        "in",
                        "int",
                        "interface",
                        "internal",
                        "is",
                        "lock",
                        "long",
                        "namespace",
                        "new",
                        "null",
                        "object",
                        "operator",
                        "out",
                        "override",
                        "params",
                        "private",
                        "protected",
                        "public",
                        "readonly",
                        "ref",
                        "return",
                        "sbyte",
                        "sealed",
                        "short",
                        "sizeof",
                        "stackalloc",
                        "static",
                        "string",
                        "struct",
                        "switch",
                        "this",
                        "throw",
                        "true",
                        "try",
                        "typeof",
                        "uint",
                        "ulong",
                        "unchecked",
                        "unsafe",
                        "ushort",
                        "using",
                        "virtual",
                        "void",
                        "volatile",
                        "while"
                    };
                    session.Store(dictionary1);
                }

                var dictionary2 = session.Query<KeywordDictionary>().FirstOrDefault(x => x.DictionaryName == "VB.NET");
                if (dictionary2 == null)
                {
                    dictionary2 = new KeywordDictionary();
                    dictionary2.DictionaryName = "VB.NET";
                    dictionary2.Keywords = new string[] 
                    {
                        "AddHandler",
                        "AddressOf",
                        "Alias",
                        "And",
                        "AndAlso",
                        "Ansi",
                        "As",
                        "Assembly",
                        "Auto",
                        "Boolean",
                        "ByRef",
                        "Byte",
                        "ByVal",
                        "Call",
                        "Case",
                        "Catch",
                        "CBool",
                        "CByte",
                        "CChar",
                        "CDate",
                        "CDec",
                        "CDbl",
                        "Char",
                        "CInt",
                        "Class",
                        "CLng",
                        "CObj",
                        "Const",
                        "CShort",
                        "CSng",
                        "CStr",
                        "CType",
                        "Date",
                        "Decimal",
                        "Declare",
                        "Default",
                        "Delegate",
                        "Dim",
                        "DirectCast",
                        "Do",
                        "Double",
                        "Each",
                        "Else",
                        "ElseIf",
                        "End",
                        "Enum",
                        "Erase",
                        "Error",
                        "Event",
                        "Exit",
                        "False",
                        "Finally",
                        "For",
                        "Friend",
                        "Function",
                        "Get",
                        "GetType",
                        "GoTo",
                        "Handles",
                        "If",
                        "Implements",
                        "Imports",
                        "In",
                        "Inherits",
                        "Integer",
                        "Interface",
                        "is",
                        "Lib",
                        "Like",
                        "Long",
                        "Loop",
                        "Me",
                        "Mod",
                        "Module",
                        "MustInherit",
                        "MustOverride",
                        "MyBase",
                        "MyClass",
                        "Namespace",
                        "New",
                        "Next",
                        "Not",
                        "Nothing",
                        "NotInheritable",
                        "NotOverridable",
                        "Object",
                        "On",
                        "Option",
                        "Optional",
                        "Or",
                        "OrElse",
                        "Overloads",
                        "Overridable",
                        "Overrides",
                        "ParamArray",
                        "Preserve",
                        "Private",
                        "Property",
                        "Protected",
                        "Public",
                        "RaiseEvent",
                        "ReadOnly",
                        "ReDim",
                        "REM",
                        "RemoveHandler",
                        "Resume",
                        "Return",
                        "Select",
                        "Set",
                        "Shadows",
                        "Shared",
                        "Short",
                        "Single",
                        "Static",
                        "Step",
                        "Stop",
                        "String",
                        "Structure",
                        "Sub",
                        "SyncLock",
                        "Then",
                        "Throw",
                        "To",
                        "True",
                        "Try",
                        "TypeOf",
                        "Unicode",
                        "Until",
                        "When",
                        "While",
                        "With",
                        "WithEvents",
                        "WriteOnly",
                        "Xor",
                        "#Const",
                        "#ExternalSource",
                        "#Region",
                        "-",
                        "&",
                        "&=",
                        "*",
                        "*=",
                        "/",
                        "/=",
                        "^",
                        "^=",
                        "+",
                        "+=",
                        "=",
                        "-=",
                        "\\",
                        "\\="
                    };
                    session.Store(dictionary2);
                }

                #endregion

                #region Insert default activity tools
                var tool1 = session.Query<ActivityTool>().FirstOrDefault(x => x.ToolName == "notepad");
                if (tool1 == null)
                {
                    tool1 = new ActivityTool();
                    tool1.ToolName = "notepad";
                    tool1.ToolDescription = "Notepad";
                    session.Store(tool1);
                }

                var tool2 = session.Query<ActivityTool>().FirstOrDefault(x => x.ToolName == "WINWORD");
                if (tool2 == null)
                {
                    tool2 = new ActivityTool();
                    tool2.ToolName = "WINWORD";
                    tool2.ToolDescription = "Ms Office";
                    session.Store(tool2);
                }

                var tool3 = session.Query<ActivityTool>().FirstOrDefault(x => x.ToolName == "devenv");
                if (tool3 == null)
                {
                    tool3 = new ActivityTool();
                    tool3.ToolName = "devenv";
                    tool3.ToolDescription = "Visual studio";
                    session.Store(tool3);
                }

                var tool4 = session.Query<ActivityTool>().FirstOrDefault(x => x.ToolName == "EXCEL");
                if (tool4 == null)
                {
                    tool4 = new ActivityTool();
                    tool4.ToolName = "EXCEL";
                    tool4.ToolDescription = "Excel";
                    session.Store(tool4);
                }
                #endregion

                #region Insert default activity priorities
                var activityPriority1 = session.Query<ActivityPriority>().FirstOrDefault(x => x.PriorityName == "Low");
                if (activityPriority1 == null)
                {
                    activityPriority1 = new ActivityPriority();
                    activityPriority1.PriorityName = "Low";
                    session.Store(activityPriority1);
                }
                var activityPriority2 = session.Query<ActivityPriority>().FirstOrDefault(x => x.PriorityName == "High");
                if (activityPriority2 == null)
                {
                    activityPriority2 = new ActivityPriority();
                    activityPriority2.PriorityName = "High";
                    session.Store(activityPriority2);
                }
                var activityPriority3 = session.Query<ActivityPriority>().FirstOrDefault(x => x.PriorityName == "Medium");
                if (activityPriority3 == null)
                {
                    activityPriority3 = new ActivityPriority();
                    activityPriority3.PriorityName = "Medium";
                    session.Store(activityPriority3);
                }

                #endregion

                #region Insert default roles
                var role1 = session.Query<UserRoles>().FirstOrDefault(x => x.RoleName == UserRole.Manager.ToString());
                if (role1 == null)
                {
                    role1 = new UserRoles();
                    role1.Id = ((int)UserRole.Manager).ToString();
                    role1.RoleName = "Manager";
                    session.Store(role1);
                }

                var role2 = session.Query<UserRoles>().FirstOrDefault(x => x.RoleName == UserRole.User.ToString());
                if (role2 == null)
                {
                    role2 = new UserRoles();
                    role2.Id = ((int)UserRole.User).ToString();
                    role2.RoleName = "User";
                    session.Store(role2);
                }
                #endregion

                #region Insert Default Email Template
                string baseUrl = ConfigurationManager.AppSettings["ServerURL"];
                var template1 = session.Query<EmailTemplate>().FirstOrDefault(x => x.Id == "ActivityEmailTemplate");
                if (template1 == null)
                {
                    var activityTemplate = File.ReadAllText(System.Web.HttpContext.Current.Server.MapPath("~/Email") + "/welcomeEmail.html");
                    activityTemplate = activityTemplate.Replace("#HeaderImage#", baseUrl + "Email/images/Header.png");
                    activityTemplate = activityTemplate.Replace("#LineImage#", baseUrl + "Email/images/Line.png");
                    activityTemplate = activityTemplate.Replace("#FooterImage#", baseUrl + "Email/images/Footer.png");
                    template1 = new EmailTemplate();
                    template1.Id = "ActivityEmailTemplate";
                    template1.TemplateBody = activityTemplate;
                    session.Store(template1);
                }

                var template2 = session.Query<EmailTemplate>().FirstOrDefault(x => x.Id == "NewUserEmailTemplate");
                if (template2 == null)
                {
                    var welcomeUserTemplate = File.ReadAllText(System.Web.HttpContext.Current.Server.MapPath("~/Email") + "/newUserEmail.html");
                    welcomeUserTemplate = welcomeUserTemplate.Replace("#HeaderImage#", baseUrl + "Email/images/Header.png");
                    welcomeUserTemplate = welcomeUserTemplate.Replace("#LineImage#", baseUrl + "Email/images/Line.png");
                    welcomeUserTemplate = welcomeUserTemplate.Replace("#FooterImage#", baseUrl + "Email/images/Footer.png");
                    template2 = new EmailTemplate();
                    template2.Id = "NewUserEmailTemplate";
                    template2.TemplateBody = welcomeUserTemplate;
                    session.Store(template2);
                }
                #endregion
                session.SaveChanges();
            }
        }

        public string GenerateEmailTemplate()
        {
            using (var session = DocumentStore.OpenSession())
            {
                try
                {
                    DateTime lastSyncDateTime = DateTime.Now.AddDays(-90);
                    var captures = session.Query<ActivityCapture>().Where(x => x.CaptureDateTime >= lastSyncDateTime).ToList();
                    var activityUsers = session.Query<ActivityUser>().Where(x => x.Id.In<string>(captures.Select(y => y.ActivityUserID).Distinct()) && x.IsActive == true).ToList();
                    var users = session.Query<PS.Data.Entities.AOS.User>().Where(x => x.Id.In<string>(activityUsers.Select(y => y.UserId).Distinct())).ToList();
                    var activities = session.Query<Activity>().Where(x => x.Id.In<string>(activityUsers.Select(y => y.ActivityId).Distinct())).ToList();
                    var qSpaces = session.Query<AOSQSpace>().Where(x => x.Id.In<string>(activities.Select(y => y.QSpaceID).Distinct())).ToList();
                    string template = "<table width='1086' border='0' cellspacing='0' cellpadding='0' style='border-collapse:collapse;width:651.8pt;margin-left:0.15pt;'>";
                    foreach (var user in users)
                    {
                        foreach (var activityUser in activityUsers.Where(x => x.UserId == user.Id))
                        {                            
                            var activity = activities.FirstOrDefault(x => x.Id == activityUser.ActivityId);
                            if (activity != null)
                            {
                                var qSpace = qSpaces.FirstOrDefault(x => x.Id == activity.QSpaceID);
                                if (qSpaces != null)
                                {
                                    template += "<tr height='50' style='height:30pt;background-color:lightgray;border: 1px solid black;'><td colSpan=3 style='padding-left: 10px;background: gray;color:white'>" + user.FirstName + " " + user.LastName + "</td></tr>";
                                    template += "<tr height='50' style='height:30pt'>";
                                    template += "<td width='50' valign='middle' nowrap='' style='width:30pt;height:30pt;background-color:white;padding:0 5.4pt;border:1pt solid windowtext;'>" +
                                    qSpace.Description + "</td><td width='50' valign='middle' nowrap='' style='width:30pt;height:30pt;background-color:white;padding:0 5.4pt;border:1pt solid windowtext;'>" +
                                    activity.ActivityName + "</td><td width='50' valign='middle' nowrap='' style='width:30pt;height:30pt;background-color:white;padding:0 5.4pt;border:1pt solid windowtext;'>";
                                    template += Math.Round(captures.Where(x => x.ActivityUserID == activityUser.Id).ToList().Sum(x => x.TimeBurned.TotalHours),3) + " Hours</td>";
                                    template += "</tr>";
                                }
                            }
                        }
                    }
                    template += "</table>";

                    return template;
                }
                catch (Exception)
                {
                    
                    throw;
                }
                
            }
        }

        public async void SendDailyWorkProgress(object info)
        {
            using (var client = new SmtpClient())
            {
                var mailMessage = new MailMessage();
                mailMessage.Body = GenerateEmailTemplate();
                mailMessage.IsBodyHtml = true;
                mailMessage.To.Add("kulwant.singh@eqosoft.com");
                mailMessage.Subject = "Hours Summary";
                await client.SendMailAsync(mailMessage);
            }
        }
    }
}
