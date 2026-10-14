using InvoiceManager.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace InvoiceManager.Interfaces
{
    public interface IPDFService
    {
        public void CreatePdf(Invoice invoice, string filename);
    }
}
