using POS.Application.Interfaces;
using POS.Domain.Entities;
using POS.Domain.Exceptions;

namespace POS.WinForms.Forms.Products;

public partial class ProductForm : Form
{
    private readonly IProductService _productService;
    private readonly ICategoryService _categoryService;
    private readonly ISupplierService _supplierService;
    private int? _selectedId;

    private sealed record ComboItem(int Id, string Name);

    public ProductForm(IProductService productService, ICategoryService categoryService,
        ISupplierService supplierService)
    {
        _productService = productService;
        _categoryService = categoryService;
        _supplierService = supplierService;
        InitializeComponent();
    }

    private async void ProductForm_Load(object sender, EventArgs e)
    {
        await LoadLookupsAsync();
        await LoadDataAsync();
    }

    private async Task LoadLookupsAsync()
    {
        var categories = (await _categoryService.GetAllAsync())
            .Select(c => new ComboItem(c.CategoryId, c.CategoryName)).ToList();
        categories.Insert(0, new ComboItem(0, "(Tanpa Kategori)"));
        cmbCategory.DisplayMember = nameof(ComboItem.Name);
        cmbCategory.ValueMember = nameof(ComboItem.Id);
        cmbCategory.DataSource = categories;

        var suppliers = (await _supplierService.GetAllAsync())
            .Select(s => new ComboItem(s.SupplierId, s.SupplierName)).ToList();
        suppliers.Insert(0, new ComboItem(0, "(Tanpa Supplier)"));
        cmbSupplier.DisplayMember = nameof(ComboItem.Name);
        cmbSupplier.ValueMember = nameof(ComboItem.Id);
        cmbSupplier.DataSource = suppliers;
    }

    private async Task LoadDataAsync()
    {
        var products = await _productService.GetAllAsync();
        dgvProduct.DataSource = products.ToList();
        ClearForm();
    }

    private async void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            int? categoryId = ((int)cmbCategory.SelectedValue!) is var c && c > 0 ? c : null;
            int? supplierId = ((int)cmbSupplier.SelectedValue!) is var s && s > 0 ? s : null;

            if (_selectedId is null)
                await _productService.CreateAsync(txtBarcode.Text, txtName.Text, categoryId, supplierId,
                    txtSaleUnit.Text, txtPurchaseUnit.Text, (int)numConversion.Value,
                    numSalePrice.Value, numPurchasePrice.Value, (int)numInitialStock.Value);
            else
                await _productService.UpdateAsync(_selectedId.Value, txtBarcode.Text, txtName.Text,
                    categoryId, supplierId, txtSaleUnit.Text, txtPurchaseUnit.Text,
                    (int)numConversion.Value, numSalePrice.Value, numPurchasePrice.Value);

            await LoadDataAsync();
            MessageBox.Show("Data Produk Berhasil Disimpan", "Sukses",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (ValidationException ex)
        {
            MessageBox.Show(ex.Message, "Validasi Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        catch (DuplicateEntityException ex)
        {
            MessageBox.Show(ex.Message, "Data Duplikat", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        catch (EntityNotFoundException ex)
        {
            MessageBox.Show(ex.Message, "Data Tidak Ditemukan", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private async void btnDelete_Click(object sender, EventArgs e)
    {
        if (_selectedId is null)
        {
            MessageBox.Show("Pilih Produk Yang Ingin Dihapus", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var confirm = MessageBox.Show("Yakin Ingin Menghapus Produk Ini?", "Konfirmasi",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        if (confirm != DialogResult.Yes) return;

        try
        {
            await _productService.DeleteAsync(_selectedId.Value);
            await LoadDataAsync();
        }
        catch (EntityNotFoundException ex)
        {
            MessageBox.Show(ex.Message, "Data Tidak Ditemukan", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void dgvProduct_SelectionChanged(object sender, EventArgs e)
    {
        if (dgvProduct.CurrentRow?.DataBoundItem is not Product p) return;

        _selectedId = p.ProductId;
        txtBarcode.Text = p.Barcode;
        txtName.Text = p.ProductName;
        cmbCategory.SelectedValue = p.CategoryId ?? 0;
        cmbSupplier.SelectedValue = p.SupplierId ?? 0;
        txtSaleUnit.Text = p.SaleUnit;
        txtPurchaseUnit.Text = p.PurchaseUnit;
        numConversion.Value = Math.Max(numConversion.Minimum, p.ConversionFactor);
        numSalePrice.Value = ClampDecimal(numSalePrice, p.SalePrice);
        numPurchasePrice.Value = ClampDecimal(numPurchasePrice, p.PurchasePrice);
        numInitialStock.Value = Math.Max(numInitialStock.Minimum, p.Stock);
        numInitialStock.Enabled = false; // stok hanya di-set saat buat baru
        lblAvgCostValue.Text = $"HPP (Average Cost): {p.AverageCost:N2}  |  Stok: {p.Stock}";
    }

    private void btnClear_Click(object sender, EventArgs e) => ClearForm();

    private void ClearForm()
    {
        _selectedId = null;
        txtBarcode.Clear();
        txtName.Clear();
        if (cmbCategory.DataSource is not null) cmbCategory.SelectedValue = 0;
        if (cmbSupplier.DataSource is not null) cmbSupplier.SelectedValue = 0;
        txtSaleUnit.Text = "PCS";
        txtPurchaseUnit.Text = "PCS";
        numConversion.Value = 1;
        numSalePrice.Value = 0;
        numPurchasePrice.Value = 0;
        numInitialStock.Value = 0;
        numInitialStock.Enabled = true;
        lblAvgCostValue.Text = "HPP (Average Cost): -";
        dgvProduct.ClearSelection();
    }

    private static decimal ClampDecimal(NumericUpDown num, decimal value)
        => Math.Min(num.Maximum, Math.Max(num.Minimum, value));
}
