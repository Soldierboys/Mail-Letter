using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using LetterMail.Components.Pages;
using LetterMail.Models;

public interface IEmailService
{
    Task SendEmailAsync(string toEmail, string subject, string htmlContent);

    Task SendAppointmentLetterAsync(AppointmentLetter appointmentLetter, string toEmail);

    // Method to handle List<EmailAttachment> for attachments
    Task SendEmailAsync(string toEmail, string subject, string htmlContent, List<EmailAttachment> attachments = null);

    Task SendEmailWithAttachmentAsync(string toEmail, string subject, string htmlContent, byte[] attachmentBytes);

    Task SendEmailWithAttachmentAsync(string toEmail, string subject, string htmlContent, byte[] attachmentData, string attachmentName);

    Task SendEmailWithAttachmentAsync(string toEmail, string subject, string htmlContent, string attachmentName, Stream attachmentStream);

    Task SendRelievingLetterAsync(RelievingLetter relievingLetter, string toEmail);

    Task SendCertificationEmailAsync(CertificationLetter certificationEmail, string toEmail);

    Task SendSalaryIncrementAsync(SalaryIncrement salaryIncrement, string toEmail);

    // Use fully qualified name to resolve ambiguity
    Task SendExperienceLetterAsync(LetterMail.Models.ExperienceLetter experienceLetter, string toEmail);
}
