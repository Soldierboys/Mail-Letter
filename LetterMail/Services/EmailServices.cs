using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MimeKit;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Logging;
using LetterMail.Models;
using LetterMail.Components.Pages;

namespace Lettermail
{
    public class EmailService : IEmailService
    {
        private readonly SmtpSettings _smtpSettings;
        private readonly ILogger<EmailService> _logger;

        public EmailService(IOptions<SmtpSettings> smtpSettings, ILogger<EmailService> logger)
        {
            _smtpSettings = smtpSettings.Value;
            _logger = logger;
        }

        private async Task SendEmailWithRetryAsync(MimeMessage emailMessage, int maxRetries = 3)
        {
            int delay = 2000; // Initial delay of 2 seconds
            for (int i = 0; i < maxRetries; i++)
            {
                try
                {
                    using (var client = new SmtpClient())
                    {
                        // Connect to the SMTP server
                        await client.ConnectAsync(_smtpSettings.SmtpServer, _smtpSettings.SmtpPort, MailKit.Security.SecureSocketOptions.StartTls);

                        // Authenticate with the SMTP server
                        await client.AuthenticateAsync(_smtpSettings.Username, _smtpSettings.Password);

                        _logger.LogInformation($"Attempt {i + 1} - Sending email to: {emailMessage.To[0].ToString()}, Subject: {emailMessage.Subject}");
                        _logger.LogInformation($"SMTP Server: {_smtpSettings.SmtpServer}, Port: {_smtpSettings.SmtpPort}");

                        // Send the email
                        await client.SendAsync(emailMessage);
                        await client.DisconnectAsync(true);
                        _logger.LogInformation("Email sent successfully.");
                        return; // Success
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, $"Exception on attempt {i + 1} of {maxRetries}. Message: {ex.Message}");
                    _logger.LogError($"Inner Exception: {ex.InnerException?.Message}");
                }

                await Task.Delay(delay); // Wait before retrying
                delay *= 2; // Exponential backoff
            }

            _logger.LogError("Failed to send email after multiple retries.");
            throw new Exception("Failed to send email after multiple retries.");
        }

        private MimeMessage CreateMimeMessage(string toEmail, string subject, string htmlContent, List<EmailAttachment> attachments = null)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress(_smtpSettings.FromName, _smtpSettings.FromAddress));
            emailMessage.To.Add(new MailboxAddress(toEmail, toEmail));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart("html")
            {
                Text = htmlContent
            };

            if (attachments != null)
            {
                foreach (var attachment in attachments)
                {
                    if (attachment.Content != null && attachment.Content.Length > 0)
                    {
                        var attachmentStream = new MemoryStream(attachment.Content);
                        var mimeAttachment = new MimePart(attachment.ContentType)
                        {
                            Content = new MimeContent(attachmentStream, MimeKit.ContentEncoding.Default),
                            FileName = attachment.FileName
                        };
                        emailMessage.Body = new Multipart("mixed")
                        {
                            emailMessage.Body,
                            mimeAttachment
                        };
                    }
                }
            }

            return emailMessage;
        }

        public async Task SendEmailAsync(string toEmail, string subject, string htmlContent)
        {
            var emailMessage = CreateMimeMessage(toEmail, subject, htmlContent);
            await SendEmailWithRetryAsync(emailMessage);
        }

        public async Task SendEmailAsync(string toEmail, string subject, string htmlContent, List<EmailAttachment> attachments = null)
        {
            var emailMessage = CreateMimeMessage(toEmail, subject, htmlContent, attachments);
            await SendEmailWithRetryAsync(emailMessage);
        }

        public async Task SendAppointmentLetterAsync(AppointmentLetter appointmentLetter, string toEmail)
        {
            await SendEmailAsync(toEmail, "Appointment Letter", appointmentLetter.HtmlContent);
        }

        public async Task SendEmailWithAttachmentAsync(string toEmail, string subject, string htmlContent, byte[] attachmentBytes)
        {
            var emailMessage = CreateMimeMessage(toEmail, subject, htmlContent);
            if (attachmentBytes != null && attachmentBytes.Length > 0)
            {
                var attachment = new MimePart("application", "octet-stream")
                {
                    Content = new MimeContent(new MemoryStream(attachmentBytes)),
                    FileName = "attachment"
                };
                emailMessage.Body = new Multipart("mixed")
                {
                    emailMessage.Body,
                    attachment
                };
            }
            await SendEmailWithRetryAsync(emailMessage);
        }

        public async Task SendEmailWithAttachmentAsync(string toEmail, string subject, string htmlContent, byte[] attachmentData, string attachmentName)
        {
            var emailMessage = CreateMimeMessage(toEmail, subject, htmlContent);
            if (attachmentData != null && attachmentData.Length > 0)
            {
                var attachment = new MimePart("application", "octet-stream")
                {
                    Content = new MimeContent(new MemoryStream(attachmentData)),
                    FileName = attachmentName
                };
                emailMessage.Body = new Multipart("mixed")
                {
                    emailMessage.Body,
                    attachment
                };
            }
            await SendEmailWithRetryAsync(emailMessage);
        }

        public async Task SendEmailWithAttachmentAsync(string toEmail, string subject, string htmlContent, string attachmentName, Stream attachmentStream)
        {
            var emailMessage = CreateMimeMessage(toEmail, subject, htmlContent);
            if (attachmentStream != null && attachmentStream.Length > 0)
            {
                var attachment = new MimePart("application", "octet-stream")
                {
                    Content = new MimeContent(attachmentStream),
                    FileName = attachmentName
                };
                emailMessage.Body = new Multipart("mixed")
                {
                    emailMessage.Body,
                    attachment
                };
            }
            await SendEmailWithRetryAsync(emailMessage);
        }

        public async Task SendRelievingLetterAsync(RelievingLetter relievingLetter, string toEmail)
        {
            await SendEmailAsync(toEmail, "Relieving Letter", relievingLetter.HtmlContent);
        }

        public async Task SendCertificationEmailAsync(CertificationLetter certificationEmail, string toEmail)
        {
            await SendEmailAsync(toEmail, "Certification Letter", certificationEmail.HtmlContent);
        }

        public async Task SendSalaryIncrementAsync(SalaryIncrement salaryIncrement, string toEmail)
        {
            await SendEmailAsync(toEmail, "Salary Increment Letter", salaryIncrement.HtmlContent);
        }

        public async Task SendExperienceLetterAsync(LetterMail.Models.ExperienceLetter experienceLetter, string toEmail)
        {
            await SendEmailAsync(toEmail, "Experience Letter", experienceLetter.HtmlContent);
        }

        public Task SendEmailAsync(Message message)
        {
            throw new NotImplementedException();
        }
    }
}