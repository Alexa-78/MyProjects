using InvoiceManager.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace InvoiceManager.Services
{
    public class EmailService : IEmailService
    {
        public void SendInvoice(
        string receiver,
        string subject,
        string body,
        string attachment)
        {
            MailMessage mail = new();
            mail.To.Add(receiver);
            mail.Subject = subject;
            mail.Body = body;

            mail.Attachments.Add(new Attachment(attachment));

            SmtpClient smtp = new("smtp.server.de");
            smtp.Port = 587;

            smtp.Send(mail);
        }
    }
}
