using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;

namespace PS.HireRocks.Web.Helpers
{
    public class EmailHelper
    {
        public async Task SendEmailNotification(string to, string subject, string body)
        {
            using (SmtpClient smtpClient = new SmtpClient())
            {
                using (MailMessage mailMessage = new MailMessage())
                {

                   
                    mailMessage.To.Add(to);
                    mailMessage.Subject = subject;
                    mailMessage.Body = body;
                    mailMessage.IsBodyHtml = true;
                   // smtpClient.Send(mailMessage);
                    await smtpClient.SendMailAsync(mailMessage);
                }
            }
        }
    }
}