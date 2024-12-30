using static LetterMail.Components.Pages.RelievingLetter;

public class RelievingLetter
{
    public int Id { get; set; }
    public string RecipientEmail { get; set; }
    public string EmployeeName { get; set; }
    public string Designation { get; set; }
    public DateTime ResignationDate { get; set; }
    public DateTime RelievingDate { get; set; }
    public DateTime IssuanceDate { get; set; }

    public string HtmlContent => $@"
        <!DOCTYPE html>
        <html lang='en'>
        <head>
            <meta charset='UTF-8'>
            <meta name='viewport' content='width=device-width, initial-scale=1.0'>
            <title>Relieving Letter</title>
            <style>
                body {{
                    font-family: 'Times New Roman', serif;
                    margin: 25px;
                    color: #000;
                }}

                .container {{
                    max-width: 800px;
                    margin: auto;
                    padding: 15px;
                    box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
                    color: #000;
                    background-color: #fff;
                }}

                .header {{
                    padding-bottom: 20px;
                    text-align: center;
                }}

                .header img {{
                    max-width: 750px;
                    height: auto;
                }}

                .content {{
                    margin-top: 30px;
                    color: #000;
                    padding: 0;
                    background-color: rgba(255, 255, 255, 0.8);
                    background-image: url('https://i.postimg.cc/Gm8t50cB/Backg.jpg');
                    background-size: 80%;
                    background-repeat: no-repeat;
                    background-position: center;
                    background-blend-mode: lighten;
                    text-align: left;
                }}

                .content p {{
                    margin: 10px 0;
                    text-align: justify;
                    font-size: 16px;
                    line-height: 1.6;
                }}

                .content h3 {{
                    text-align: center;
                    color: #000;
                    margin-bottom: 20px;
                }}

                .signature-section {{
                    margin-top: 40px;
                    text-align: left;
                    color: #000;
                }}

                .bold {{
                    font-weight: bold;
                    color: #000;
                }}

                .left-align {{
                    text-align: left;
                    color: #000;
                }}

                .right-align {{
                    text-align: right;
                    color: #000;
                }}

                .signature-content img {{
                    max-width: 150px;
                    height: auto;
                }}

                .footer {{
                    margin-top: 167px;
                    text-align: center;
                }}

                .footer img {{
                    max-width: 100%;
                    height: auto;
                    margin-top: 20px;
                }}
            </style>
        </head>
        <body>
            <div class='container'>
                <div class='header'>
                    <a href='https://vaaradhiitservices.com/' target='_blank'>
                        <img src='https://i.postimg.cc/7hkSxHZQ/header.png' border='0' alt='company-logo' />
                    </a>
                </div>
                <div class='content'>
                    <h3>RELIEVING LETTER</h3>
                   <p>Date: {DateTime.Now:dd MMMM yyyy}</p>
                    <p>To,</p>
                    <p>{EmployeeName},</p>
                    <p>Designation: {Designation},</p>
                    <p>Employee ID: MTLHD21020,</p>
                    <p>Location: Hyderabad, Telangana.</p>
                    <p>With reference to your resignation letter, we acknowledge that you have been relieved from all services, duties, and responsibilities of <span class='bold'>Metrolabs Services Pvt. Ltd.</span>, with effect from the closing hours of {RelievingDate:dd MMMM, yyyy}.</p>
                    <p>We wish you all success in your future endeavors.</p>
                </div>
                <div class='left-align'>
                    <p>With Regards,</p>
                    <p>Metrolabs Services Pvt. Ltd.</p>
                    <div class='signature-content'>
                        <a href='https://vaaradhiitservices.com/' target='_blank'>
                            <img src='https://i.postimg.cc/rp4dzB36/Sign.png' border='0' alt='signature-1'/>
                        </a>
                        <p>Authorized Signatory</p>
                    </div>
                </div>
                <div class='footer'>
                    <img src='https://i.postimg.cc/J4hGjDv5/Foot.png' alt='footer' />
                </div>
            </div>
        </body>
        </html>";
}
