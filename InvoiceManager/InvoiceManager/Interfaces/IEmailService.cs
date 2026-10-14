using System;
using System.Collections.Generic;
using System.Text;

namespace InvoiceManager.Interfaces
{
    public interface IEmailService
    {
        public void SendInvoice (string receiver,string subject, string body,string attachment);
    }
}
