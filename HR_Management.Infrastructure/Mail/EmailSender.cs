using HR_Management.Application.Cantracts.Infrastructure;
using HR_Management.Application.Models;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HR_Management.Infrastructure.Mail
{
    public class EmailSender : IEmailSender
    {
        private readonly EmailSetting _options;
        public EmailSender(IOptions<EmailSetting> options)
        {
            _options = options.Value;
        }

        public async Task<bool> SendEmail(Email email)
        {
            var client = new SendGridClient(_options.ApiKey);
            var destination = new EmailAddress(email.DestinationEmail);
            var from = new EmailAddress(_options.FromAddress, _options.SenderName);
            var message = MailHelper.CreateSingleEmail(from, destination, email.Subject, email.Body, email.Body);

            var response = await client.SendEmailAsync(message);

            return response.StatusCode == HttpStatusCode.OK
                || response.StatusCode == HttpStatusCode.Accepted;
        }
    }
}
