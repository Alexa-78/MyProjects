using InvoiceManager.Interfaces;
using InvoiceManager.Models;

namespace InvoiceManager.Forms
{
    public partial class CustomerForm : Form
    {
        private readonly ICustomerService _customerService;
        private Customer? _selectedCustomer;
        public CustomerForm(ICustomerService customerService)
        {
            InitializeComponent();
            _customerService = customerService;
        }

        private async void CustomerForm_Load(object sender, EventArgs e)
        {
            await LoadCustomers();
        }

        private async Task LoadCustomers()
        {
            dgvCustomers.DataSource = await _customerService.GetAllAsync();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        { 
            if (_selectedCustomer == null)
                _selectedCustomer = new Customer();

            _selectedCustomer.Company = txtCompany.Text;
            _selectedCustomer.Contact = txtContact.Text;
            _selectedCustomer.Street = txtStreet.Text;
            _selectedCustomer.Zip = txtZip.Text;
            _selectedCustomer.City = txtCity.Text;
            _selectedCustomer.Email = txtEmail.Text;

            await _customerService.SaveAsync(_selectedCustomer);
            await LoadCustomers();
        }

        private void dgvCustomers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            _selectedCustomer = (Customer)dgvCustomers.Rows[e.RowIndex].DataBoundItem;

            txtCompany.Text = _selectedCustomer.Company;
            txtContact.Text = _selectedCustomer.Contact;
            txtStreet.Text = _selectedCustomer.Street;
            txtZip.Text = _selectedCustomer.Zip;
            txtCity.Text = _selectedCustomer.City;
            txtEmail.Text = _selectedCustomer.Email;
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (_selectedCustomer == null)
                return;

            await _customerService.DeleteAsync(_selectedCustomer);
            await LoadCustomers();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void ClearFields()
        {
            txtCompany.Clear();
            txtContact.Clear();
            txtStreet.Clear();
            txtZip.Clear();
            txtCity.Clear();
            txtEmail.Clear();
        }
    }
}
