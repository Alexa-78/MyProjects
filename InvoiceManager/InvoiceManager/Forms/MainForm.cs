using InvoiceManager.Forms;
using InvoiceManager.Interfaces;
using InvoiceManager.Services;
using Microsoft.Extensions.DependencyInjection;

namespace InvoiceManager
{
    public partial class MainForm : Form
    {
        private readonly IServiceProvider _serviceProvider;

        public MainForm(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            var customerservice = _serviceProvider.GetRequiredService<ICustomerService>();
            var productservice = _serviceProvider.GetRequiredService<IProductService>();
            var invoiceservice = _serviceProvider.GetRequiredService<IInvoiceService>();

            int count = await customerservice.CountAsync();
            lblCustomersCount.Text = count.ToString();

            count = await productservice.CountAsync();
            lblProductsCount.Text = count.ToString();
        }

        private void customerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = _serviceProvider.GetRequiredService<CustomerForm>();
            form.ShowDialog();
        }

        private void invoicesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = _serviceProvider.GetRequiredService<InvoiceForm>();
            form.ShowDialog();
        }

        private void productsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = _serviceProvider.GetRequiredService<ProductForm>();
            form.ShowDialog();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = _serviceProvider.GetRequiredService<SettingsForm>();
            form.ShowDialog();
        }

        private void btnCustomers_Click(object sender, EventArgs e)
        {
            var form = _serviceProvider.GetRequiredService<CustomerForm>();
            form.ShowDialog();
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            var form = _serviceProvider.GetRequiredService<ProductForm>();
            form.ShowDialog();
        }

        private void btnInvoices_Click(object sender, EventArgs e)
        {
            var form = _serviceProvider.GetRequiredService<InvoiceForm>();
            form.ShowDialog();
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            var form = _serviceProvider.GetRequiredService<SettingsForm>();
            form.ShowDialog();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
