using InvoiceManager.Interfaces;
using InvoiceManager.Models;

namespace InvoiceManager.Forms
{
    public partial class ProductForm : Form
    {
        private readonly IProductService _productService;
        private Product? _selectedProduct;
        public ProductForm(IProductService productService)
        {
            InitializeComponent();
            _productService = productService;
        }

        private async void ProductForm_Load(object sender, EventArgs e)
        {
            await LoadProducts();
        }

        private async Task LoadProducts()
        {
            dgvProducts.DataSource = await _productService.GetAllAsync();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void ClearFields()
        {
            txtArcticleNumber.Clear();
            txtName.Clear();
            txtDescription.Clear();
            txtPrice.Clear();
            txtVatRate.Clear();
            chkbxIsActive.Checked = false;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (_selectedProduct == null)
                _selectedProduct = new Product();

            _selectedProduct.ArticleNumber = txtArcticleNumber.Text;
            _selectedProduct.Name = txtName.Text;
            _selectedProduct.Description = txtDescription.Text;
            _selectedProduct.Price = Convert.ToDecimal(txtPrice.Text);
            _selectedProduct.VatRate = Convert.ToDecimal(txtVatRate.Text);
            _selectedProduct.IsActive = chkbxIsActive.Checked;

            await _productService.SaveAsync(_selectedProduct);
            await LoadProducts();
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (_selectedProduct == null)
                return;

            await _productService.DeleteAsync(_selectedProduct);
            await LoadProducts();
        }

        private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            _selectedProduct = (Product)dgvProducts.Rows[e.RowIndex].DataBoundItem;

            txtArcticleNumber.Text  = _selectedProduct.ArticleNumber;
            txtName.Text            = _selectedProduct.Name;
            txtDescription.Text     = _selectedProduct.Description;
            txtPrice.Text           = _selectedProduct.Price.ToString();
            txtVatRate.Text         = _selectedProduct.VatRate.ToString();
            chkbxIsActive.Checked   = _selectedProduct.IsActive;
        }
    }
}
