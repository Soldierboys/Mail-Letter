using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas;
using iText.Layout;
using iText.Layout.Element;
using iText.Html2pdf;
using iText.IO.Image;
using System.IO;
using iText.Kernel.Pdf.Annot;
using iText.Kernel.Pdf.Action;

public class PdfService
{
    public byte[] GeneratePdf(string htmlContent)
    {
        using (var outputMemoryStream = new MemoryStream())
        using (var tempStream = new MemoryStream())
        {
            // Convert HTML to PDF
            HtmlConverter.ConvertToPdf(htmlContent, tempStream);

            using (var reader = new PdfReader(new MemoryStream(tempStream.ToArray())))
            using (var writer = new PdfWriter(outputMemoryStream))
            using (var pdfDoc = new PdfDocument(reader, writer))
            {
                int numberOfPages = pdfDoc.GetNumberOfPages();

                for (int i = 1; i <= numberOfPages; i++)
                {
                    var page = pdfDoc.GetPage(i);

                    // Add header to every page
                    AddHeaderToPage(page, "https://i.postimg.cc/7hkSxHZQ/header.png");

                    // Add footer to every page
                    AddFooterToPage(page, "https://i.postimg.cc/J4hGjDv5/Foot.png");
                }
            }

            return outputMemoryStream.ToArray();
        }
    }

    private void AddHeaderToPage(PdfPage page, string imageUrl)
    {
        var pageSize = page.GetPageSize();
        var canvas = new PdfCanvas(page.NewContentStreamBefore(), page.GetResources(), page.GetDocument());

        // Load the image for the header
        var imageData = ImageDataFactory.Create(imageUrl);

        // Position and size for the header image
        float headerWidth = pageSize.GetWidth(); // Full width of the page
        float headerHeight = 90; // Height of the header image
        float x = 0; // Start at the left edge of the page
        float y = pageSize.GetTop() - headerHeight; // Top of the page minus the header height

        // Define the area for the header image
        var rectangle = new iText.Kernel.Geom.Rectangle(x, y, headerWidth, headerHeight);
        var layoutCanvas = new Canvas(canvas, rectangle);

        // Create and add the image to the canvas
        var image = new Image(imageData).ScaleAbsolute(headerWidth, headerHeight);
        layoutCanvas.Add(image);

        // Add clickable link area
        var linkRectangle = new iText.Kernel.Geom.Rectangle(x, y, headerWidth, headerHeight);
        PdfAction action = PdfAction.CreateURI("https://vaaradhiitservices.com/");
        PdfAnnotation linkAnnotation = new PdfLinkAnnotation(linkRectangle)
            .SetAction(action)
            .SetBorder(new PdfAnnotationBorder(0, 0, 0)); // No border
        page.AddAnnotation(linkAnnotation);

        // Ensure the content is flushed to the page
        layoutCanvas.Close();
    }

    private void AddFooterToPage(PdfPage page, string imageUrl)
    {
        var pageSize = page.GetPageSize();
        var canvas = new PdfCanvas(page.NewContentStreamBefore(), page.GetResources(), page.GetDocument());

        // Load the image for the footer
        var imageData = ImageDataFactory.Create(imageUrl);

        // Adjusted size and position for the footer image
        float margin = 50; // Margin on both sides
        float footerHeight = 30; // Adjust the height for a more subtle footer
        float footerWidth = pageSize.GetWidth() - 2 * margin; // Footer width with margins on the sides
        float x = margin; // Start after the left margin
        float y = pageSize.GetBottom() + 50; // Slightly above the bottom of the page

        // Define the area for the footer image
        var rectangle = new iText.Kernel.Geom.Rectangle(x, y, footerWidth, footerHeight);
        var layoutCanvas = new Canvas(canvas, rectangle);

        // Create and add the image to the canvas
        var image = new Image(imageData)
            .ScaleAbsolute(footerWidth, footerHeight) // Scale the image to fit within the specified dimensions
            .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER); // Center the image within the rectangle

        layoutCanvas.Add(image);

        // Ensure the content is flushed to the page
        layoutCanvas.Close();
    }
}
