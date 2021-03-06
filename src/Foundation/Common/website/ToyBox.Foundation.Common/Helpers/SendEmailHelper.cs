using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using Sitecore.Diagnostics;

namespace ToyBox.Foundation.Common.Helpers
{
    public class SendEmailHelper
    {
        private static SmtpClient GetSmtpClient()
        {
            var host = Sitecore.Configuration.Settings.GetSetting("MailServer");
            int port = Sitecore.Configuration.Settings.GetIntSetting("MailServerPort", 25);
            var username = Sitecore.Configuration.Settings.GetSetting("MailServerUserName");
            var pwd = Sitecore.Configuration.Settings.GetSetting("MailServerPassword");
            SmtpClient smtpClient = new SmtpClient(host, port);
            smtpClient.UseDefaultCredentials = false;
            smtpClient.EnableSsl = Sitecore.Configuration.Settings.GetBoolSetting("MailServerUseSsl", false);
            smtpClient.Credentials = new NetworkCredential(username, pwd);
            return smtpClient;
        }

        public static void SendEmail(string from, string[] toList, string subject, string body)
        {
            try
            {
                var fromEmail = "no-reply@toybox.com";
                SmtpClient smtpClient = GetSmtpClient();
                MailMessage message = new MailMessage();
                foreach (var to in toList)
                {
                    message.To.Add(to);
                }

                message.From = new MailAddress(fromEmail, from);
                message.Subject = subject;
                message.Body = body;
                message.IsBodyHtml = true;
                smtpClient.Send(message);
            }
            catch (Exception ex)
            {
                Log.Error("SendEmail: There is a problem sending the email", ex, typeof(SendEmailHelper));
            }
        }

    }
}