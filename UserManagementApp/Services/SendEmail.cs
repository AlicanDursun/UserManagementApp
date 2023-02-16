
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using MimeKit;
using MimeKit.Text;
using System.Net;

namespace UserManagementApp.Services
{
    public class SendEmail : IEmailSender
    {
       
        public EmailOptions Options { get; }
        public SendEmail(IOptions<EmailOptions> optionsAccessor)
        {
            Options = optionsAccessor.Value;
        }

        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            
            var email1 = new MimeMessage();
            email1.From.Add(MailboxAddress.Parse(Options.EmailUserName));
            email1.To.Add(MailboxAddress.Parse(email));
            email1.Subject = subject;
            email1.Body = new TextPart(TextFormat.Html) { Text = htmlMessage };
           
            using var smtp = new SmtpClient();
            smtp.Connect(Options.EmailHost, 587);
            //smtp.Connect(Options.EmailHost, 587, SecureSocketOptions.StartTls);
            smtp.Authenticate(Options.EmailUserName, Options.EmailPassword);
            await smtp.SendAsync(email1);
            await smtp.DisconnectAsync(true);

        }


    }
}
