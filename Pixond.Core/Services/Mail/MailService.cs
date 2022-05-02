using Pixond.Core.Abstraction.Services.Mail;
using Pixond.Core.Configurations;
using System.Net.Mail;
using System.Net.Security;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System;

namespace Pixond.Core.Services.Mail
{
    public class MailService : IMailService
    {
        private readonly MailServerConfiguration _mailServerConfiguration;

        public MailService(MailServerConfiguration mailServerConfiguration)
        {
            _mailServerConfiguration = mailServerConfiguration;
        }
        public bool SendMail(string fromUsername, string toAddress, string subject, string body)
        {
            try
            {
                using (SmtpClient client = new SmtpClient())
                {
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.EnableSsl = true;
                    client.Host = _mailServerConfiguration.Host;
                    client.Port = _mailServerConfiguration.Port;
                    ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };
                    NetworkCredential credentials = new NetworkCredential(_mailServerConfiguration.FromEmail, _mailServerConfiguration.Password);
                    client.UseDefaultCredentials = false;
                    client.Credentials = credentials;
                    MailMessage msg = new MailMessage();
                    msg.From = new MailAddress(_mailServerConfiguration.FromEmail, fromUsername);
                    msg.To.Add(toAddress);
                    msg.Subject = subject;
                    msg.Body = body;
                    client.Send(msg);
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
