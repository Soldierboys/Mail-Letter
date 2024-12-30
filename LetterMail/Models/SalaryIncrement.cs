using System.ComponentModel.DataAnnotations;


public class SalaryIncrement
{
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string EmployeeName { get; set; } = string.Empty; // Initialize to empty string

    [Required]
    public string Position { get; set; } = string.Empty; // Initialize to empty string

    [Required]
    public decimal NewSalary { get; set; } = 0.0m; // Initialize with default value

    [Required]
    public DateTime EffectiveDate { get; set; } = DateTime.Now; // Initialize with current date

    public string HtmlContent => $@"
    <!DOCTYPE html>
    <html lang='en'>
    <head>
        <meta charset='UTF-8'>
        <meta name='viewport' content='width=device-width, initial-scale=1.0'>
        <title>Salary Increment Letter</title>
        <style>
            body {{ font-family: Arial, sans-serif; margin: 40px; }}
            .container {{ max-width: 800px; margin: auto; padding: 20px; border: 1px solid #ccc; box-shadow: 0 0 10px rgba(0,0,0,0.1); }}
            .content {{ margin-top: 20px; }}
            .content p {{ margin: 10px 0; }}
            .content h3 {{ text-align: center; }}
            .signature {{ margin-top: 40px; text-align: right; }}
        </style>
    </head>
    <body>
        <div class='container'>
            <div class='content'>
                <p>15th July 2022</p>
                <h3>SUBJECT: SALARY INCREMENT LETTER</h3>
                <p>Dear {EmployeeName},</p>
                <p>Congratulations!</p>
                <p>It gives us immense pleasure to recognize your hard work and achievements while serving with Metrolabs Services Pvt. Ltd. We have made an attempt to benchmark Metrolabs Services Pvt. Ltd., Salary package with best in the industry, accordingly your annual salary has been revised to Rs.{NewSalary:N2}/- and designated as {Position}, effective from {EffectiveDate:MMMM yyyy}.</p>
                <p>All other terms & conditions of your employment remain unchanged. We expect that you will continue to put in your best efforts towards the performance of your duties in future as well.</p>
                <p>Wishing you a promising career with Metrolabs Services Pvt. Ltd.</p>
                <div class='signature'>
                    <p>With Regards,</p>
                    <p>For Metrolabs Services Pvt. Ltd.</p>
                    <p>Authorized Signatory</p>
                </div>
            </div>
        </div>
    </body>
    </html>";
}
