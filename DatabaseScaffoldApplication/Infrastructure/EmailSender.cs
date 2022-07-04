using Microsoft.AspNetCore.Identity.UI.Services;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseScaffoldApplication.Infrastructure
{

    public class EmailSender : IEmailSender
    {

        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var client = new SendGridClient("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");

            var msg = new SendGridMessage()
            {
                From = new EmailAddress("mert.alptekin@neominal.com", "Neominal"),
                Subject = subject,
                PlainTextContent = htmlMessage,
                HtmlContent = htmlMessage
            };

            msg.AddTo(new EmailAddress(email));
            return client.SendEmailAsync(msg);
        }
        
    }
}
