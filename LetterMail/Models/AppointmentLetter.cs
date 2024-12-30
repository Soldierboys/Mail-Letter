using System.ComponentModel.DataAnnotations;

public class AppointmentLetter
{
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string EmployeeName { get; set; } = string.Empty;

    [Required]
    public string Position { get; set; }

    [Required]
    public DateTime StartDate { get; set; } = DateTime.Now;

    [Required]
    [DataType(DataType.Currency)]
    public decimal MonthlyCTC { get; set; } = 0.0m;

    [Required]
    [DataType(DataType.Currency)]
    public decimal AnnualCTC { get; set; } = 0.0m;

    [Required]
    public byte[] PdfAttachment { get; set; }


    public string HtmlContent => $@"
    <!DOCTYPE html>
    <html lang='en'>
    <head>
        <meta charset='UTF-8'>
        <meta name='viewport' content='width=device-width, initial-scale=1.0'>
        <title>Appointment Letter</title>
        <style>
            body {{ font-family: Arial, sans-serif; margin: 40px; }}
            .container {{ max-width: 800px; margin: auto; padding: 20px; border: 1px solid #ccc; box-shadow: 0 0 10px rgba(0,0,0,0.1); }}
            .header, .footer {{ text-align: center; }}
            .content {{ margin-top: 20px; }}
            .content p {{ margin: 10px 0; }}
            .content h2 {{ text-align: center; text-decoration: underline; }}
            .salary-table {{ width: 100%; border-collapse: collapse; margin-top: 20px; }}
            .salary-table th, .salary-table td {{ border: 1px solid #000; padding: 8px; text-align: left; }}
            .signature-section {{ margin-top: 40px; }}
            .signature-section p {{ display: inline-block; width: 45%; }}
            .signature-section p.right {{ text-align: right; }}
        </style>
    </head>
    <body>
        <div class='container'>
            <div class='header'>
                <h2>APPOINTMENT LETTER</h2>
            </div>
            <div class='content'>
                <p>Date: {DateTime.Now:dd MMMM yyyy}</p>
                <p>Name: {EmployeeName}</p>
                <p>Work location: Hyderabad, Telangana.</p>
                <p>Dear {EmployeeName},</p>
                <p>With reference to your appointment with Metrolabs Services Pvt. Ltd., we have pleasure in offering you the position as {Position} in our organization on a fixed term contract basis. The details of the offer are as follows:</p>
                <p>Start date of Assignment: {StartDate:dd MMMM yyyy}</p>
                <p>Monthly CTC: {MonthlyCTC:C} (Rupees {ToWords(MonthlyCTC)} Only)</p>
                <p>Annual CTC: {AnnualCTC:C} (Rupees {ToWords(AnnualCTC)} Only)</p>
                <p>Any statutory dues like PF, ESIC, Bonus etc., if applicable, will be Paid / Deducted as per law after probation period of one (1) year from the date of joining. All taxes will be deducted as applicable by law.</p>
                <p>If you wish to accept this offer, kindly send the accepted copy of the same along with a copy of your resignation letter or relieving letter (if applicable). If in case the signed acceptance and required documents are not received by Metrolabs Services Pvt. Ltd. within 48 hours of the offer date, Metrolabs Services Pvt. Ltd. at their discretion reserve their right to treat this offer as withdrawn automatically without further notice.</p>
                <h2>Annexure-I: Fixed Annual CTC</h2>
                <table class='salary-table'>
                    <tr><th>Salary Breakup</th><th>Monthly</th><th>Yearly</th></tr>
                    <tr><td>CTC</td><td>{MonthlyCTC:C}</td><td>{AnnualCTC:C}</td></tr>
                    <tr><td>BASIC</td><td>{MonthlyCTC / 2:C}</td><td>{AnnualCTC / 2:C}</td></tr>
                    <!-- Add other rows as necessary -->
                </table>
                <p>Income Tax and Professional tax as applicable will be deducted. All taxes will be deducted as applicable by law. Your salary is strictly confidential.</p>
                <div class='signature-section'>
                    <p>For Metrolabs Services Pvt. Ltd.</p>
                    <p class='right'>Accepted By</p>
                    <p class='right'>Signature of employee</p>
                </div>
            </div>
        </div>
    </body>
    </html>";

    // Method to convert number to words, if required
    private string ToWords(decimal number)
    {
        // Implement the conversion logic or use an external library
        return "Your implementation here";
    }
}
