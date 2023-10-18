using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace PS.Azure.Web.Utils
{
    public class EmailSender
    {
        /// <summary>
        /// Send recovery password email
        /// </summary>
        /// <param name="email"></param>
        /// <param name="message"></param>
        /// <returns>empy: good, not empty string: error message</returns>
        public static string SendEmail(string email, string message)
        {
            try
            {
                var fromAddress = new MailAddress("PS@gmail.com", "PS");
                var toAddress = new MailAddress(email, email);
                var fromPassword = "dsgdsg456346dsgsdg3450345";
                var subject = "PS - Password Recovery";
                var body = message;

                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
                };

                using (var msg = new MailMessage(fromAddress, toAddress) { Subject = subject, Body = body })
                {
                    smtp.Send(msg);
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            return string.Empty;
        }     
    }
}