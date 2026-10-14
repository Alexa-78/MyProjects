using InvoiceManager.Interfaces;
using InvoiceManager.Models;
using QuestPDF.Fluent;


namespace InvoiceManager.Services
{
    public class PDFService : IPDFService
    {
        public void CreatePdf(Invoice invoice, string filename)
        {
            QuestPDF.Fluent.Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Content().Column(col =>
                    {
                        col.Item().Text($"Rechnung {invoice.InvoiceNumber}");

                        col.Item().Text(invoice.Customer.Company);

                        foreach (var item in invoice.Items)
                        {
                            col.Item().Text(
                                $"{item.Product.Name}   {item.Quantity} x {item.UnitPrice:C}");
                        }

                        col.Item().Text($"Gesamt: {invoice.GrossTotal:C}");
                    });
                });
            })
            .GeneratePdf(filename);
        }
    }
}
