using InvoiceManager.Interfaces;
using InvoiceManager.Models;
using InvoiceManager.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace InvoiceManager.Forms
{
    public partial class InvoiceForm : Form
    {
        private readonly IInvoiceService _invoiceService;
        private readonly ICustomerService _customerService;
        private readonly IProductService _productService;
        private Invoice _invoice;

        public InvoiceForm(IInvoiceService invoiceService, ICustomerService customerService, IProductService productService)
        {
            InitializeComponent();
            _invoiceService = invoiceService;
            _customerService = customerService;
            _productService = productService;           
        }

        private void InvoiceForm_Load(object sender, EventArgs e)
        {
            LoadCustomers();
            LoadProducts();
        }

        private async Task LoadCustomers()
        {
            var customers = await _customerService.GetAllAsync();

            cmbCustomer.DataSource = customers;
            cmbCustomer.DisplayMember = "Company";
            cmbCustomer.ValueMember = "Id";
        }

        private async Task LoadProducts()
        {
            var products = await _productService.GetAllAsync();

            cmbProduct.DataSource = products;
            cmbProduct.DisplayMember = "Name";
            cmbProduct.ValueMember = "Id";
        }

        private void btnAddPosition_Click(object sender, EventArgs e)
        {
            if (_invoice == null)
            {
                MessageBox.Show("Please create a new invoice");
                return;
            }

            Product product = (Product)cmbProduct.SelectedItem;

            _invoiceService.AddItem(
                _invoice,
                product,
                nudQuantity.Value);

            RefreshInvoice();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            Customer customer = (Customer)cmbCustomer.SelectedItem;

            _invoice = _invoiceService.CreateInvoice(customer);

            txtInvoiceNumber.Text = _invoice.InvoiceNumber;
            dtInvoiceDate.Value = _invoice.InvoiceDate;

            RefreshInvoice();
        }

        private void RefreshInvoice()
        {
            dgvItems.DataSource = null;
            dgvItems.DataSource = _invoice.Items;

            lblNet.Text = _invoice.NetTotal.ToString("C");
            lblVat.Text = _invoice.Vat.ToString("C");
            lblGross.Text = _invoice.GrossTotal.ToString("C");
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            await _invoiceService.SaveInvoiceAsync(_invoice);

            MessageBox.Show("Invoice saved");
        }

        
    }
}
