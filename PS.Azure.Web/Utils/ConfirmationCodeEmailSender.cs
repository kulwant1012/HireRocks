using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace PS.Azure.Web.Utils
{
    public class ConfirmationCodeEmailSender
    {
        public static string VerificationCode(string email, string message)
        {
            try
            {
                var fromAddress = new MailAddress("PSapp@gmail.com", "PS");
                var toAddress = new MailAddress(email, email);
                var fromPassword = "PS@123";
                var subject = "PS - Email Verification Code";
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