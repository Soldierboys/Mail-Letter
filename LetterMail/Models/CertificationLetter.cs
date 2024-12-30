using System;
using System.ComponentModel.DataAnnotations;

namespace LetterMail.Components.Pages
{
    public class CertificationLetter
    {
        public int Id { get; set; }

        [Required]
        [EmailAddress]
        public string RecipientEmail { get; set; }

        public string EmployeeName { get; set; }

        public string EmployeeID { get; set; }

        public string CompanyName { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string Position { get; set; }

        public string Gender { get; set; }

        public string Skill { get; set; }

        [Required]
        public string EmployeeType { get; set; }
        public string HtmlContent { get; set; }

    }
}
