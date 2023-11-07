using System.Net;
using System.Net.Mail;
using LNDP_API.Dtos;
using LNDP_API.Utils;

namespace LNDP_API.Services
{
    public class EmailService : IEmailService
    {
        private readonly SmtpClient _smtpClient;
        private readonly bool enabled;

        public EmailService()
        {
            var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("emailConfig.json", true)
            .Build();
            enabled = config.GetValue<bool>("enabled");
            _smtpClient = new SmtpClient(config.GetValue<string>("server"), config.GetValue<int>("port"))
            {
                Credentials = new NetworkCredential(config.GetValue<string>("networkMail"), config.GetValue<string>("networkPassword")),
                EnableSsl = config.GetValue<bool>("enableSSL")
            };
            _smtpClient.SendCompleted += new SendCompletedEventHandler(Smtp_SendCompleted);
        }
        public override void SendEmail(EmailDto emailDto)
        {
            SendEmailPromo(EmailTemplates.FROMDEFAULTEMAIL, EmailTemplates.TODEFAULTEMAIL, emailDto.CopyEmail, emailDto.Subject, EmailTemplates.GetNewPromoBody(emailDto.MailMessage));
        }
        void SendEmailPromo(string fromEmail, string destEmail, string copyEmail, string subject, string body)
        {
            if (enabled)
            {
                MailMessage message = new();
                message.To.Add(destEmail);
                message.From = new MailAddress(fromEmail);
                message.CC.Add(copyEmail);
                message.Subject = subject;
                message.IsBodyHtml = true;
                message.Body = body;

                _smtpClient.SendMailAsync(message);
            }
        }

        void Smtp_SendCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            if (e.Cancelled == true || e.Error != null)
            {
                throw new Exception(e.Cancelled ? "Email sending was canceled." : "Error " + e.Error!.ToString());
            }
        }
    }
}