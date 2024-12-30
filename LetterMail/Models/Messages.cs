public class Message
{
    public string[] To { get; set; }
    public string Subject { get; set; }
    public string Body { get; set; }
    public byte[] Attachments { get; set; }
    public string AttachmentFileName { get; set; }

    public Message(string[] to, string subject, string body, byte[] attachments, string attachmentFileName)
    {
        To = to;
        Subject = subject;
        Body = body;
        Attachments = attachments;
        AttachmentFileName = attachmentFileName;
    }
}
