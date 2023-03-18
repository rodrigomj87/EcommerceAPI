using Ecommerce.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Business.Services
{
    public class SmtpEmailSender : IEmailSender
    {
        private readonly SmtpClient _smtpClient;

        public SmtpEmailSender(string smtpServer, int smtpPort, string smtpUsername, string smtpPassword)
        {
            _smtpClient = new SmtpClient(smtpServer, smtpPort)
            {
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(smtpUsername, smtpPassword),
                EnableSsl = true
            };
        }

        public async Task SendEmailAsync(string email, string subject, string body)
        {
            var mailMessage = new MailMessage
            {
                From = new MailAddress("rodrigomj87@gmail.com"),
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            };
            mailMessage.To.Add(new MailAddress(email));
            await _smtpClient.SendMailAsync(mailMessage);
        }
    }

}
