using System.ComponentModel;
using POS.Application.Interfaces;
using POS.Application.Requests;
using POS.Domain.Exceptions;

namespace POS.WinForms.Forms.Purchasing;

public partial class PembelianForm : Form
{
    private readonly IPurchaseService _purchaseService;
    private readonly IProductService _productService;
    private readonly ISupplierService _supplierService;

    private readonly BindingList<PurchaseLineVm> _lines = new();

    private sealed record ComboItem(int Id, string Name);

    public PembelianForm(IPurchaseService purchaseService, IProductService productService,
        ISupplierService supplierService)
    {
        _purchaseService = purchaseService;
        _productService = productService;
        _supplierService = supplierService;
        InitializeComponent();
    }

    private async void PembelianForm_Load(object sender, EventArgs e)
    {
        dgvLines.AutoGenerateColumns = false;
        dgvLines.DataSource = _lines;

        var suppliers = (await _supplierService.GetAllAsync())
            .Select(s => new ComboItem(s.SupplierId, s.SupplierName)).ToList();
        suppliers.Insert(0, new ComboItem(0, "(Pilih Supplier)"));
        cmbSupplier.DisplayMember = nameof(ComboItem.Name);
        cmbSupplier.ValueMember = nameof(ComboItem.Id);
        cmbSupplier.DataSource = suppliers;

        RefreshTotal();
    }

    private async void btnAdd_Click(object sender, EventArgs e) => await AddByBarcodeAsync();

    private async void txtBarcode_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode != Keys.Enter) return;
        e.SuppressKeyPress = true;
        await AddByBarcodeAsync();
    }

    private async Task AddByBarcodeAsync()
    {
        var keyword = txtBarcode.Text.Trim();
        if (string.IsNullOrEmpty(keyword)) return;

        var product = await _productService.GetByBarcodeAsync(keyword);
        if (product is null)
        {
            var matches = (await _productService.SearchAsync(keyword)).ToList();
            if (matches.Count == 1) product = matches[0];
            else
            {
                MessageBox.Show("Produk Tidak Ditemukan Atau Kata Kunci Ambigu", "Info",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        var existing = _lines.FirstOrDefault(l => l.ProductId == product.ProductId);
        if (existing is not null)
            existing.Quantity++;
        else
            _lines.Add(new PurchaseLineVm
            {
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                Quantity = 1,
                PurchasePrice = (int)product.PurchasePrice
            });

        dgvLines.Refresh();
        RefreshTotal();
        txtBarcode.Clear();
        txtBarcode.Focus();
    }

    private void dgvLines_CellEndEdit(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0 || e.RowIndex >= _lines.Count) return;
        var vm = _lines[e.RowIndex];
        if (vm.Quantity < 1) vm.Quantity = 1;
        if (vm.PurchasePrice < 0) vm.PurchasePrice = 0;
        dgvLines.Refresh();
        RefreshTotal();
    }

    private void btnRemoveItem_Click(object sender, EventArgs e)
    {
        if (dgvLines.CurrentRow?.DataBoundItem is not PurchaseLineVm vm) return;
        _lines.Remove(vm);
        RefreshTotal();
    }

    private void RefreshTotal()
    {
        lblTotalValue.Text = $"Rp {GrandTotal():N0}";
        numInitialPayment.Maximum = Math.Max(0, GrandTotal());
    }

    private int GrandTotal() => _lines.Sum(l => l.Subtotal);

    private async void btnSave_Click(object sender, EventArgs e)
    {
        if (_lines.Count == 0)
        {
            MessageBox.Show("Belum Ada Item Pembelian", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        int supplierId = (int)cmbSupplier.SelectedValue!;
        if (supplierId <= 0)
        {
            MessageBox.Show("Pilih Supplier Terlebih Dahulu", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        try
        {
            var items = _lines
                .Select(l => new PurchaseItemRequest(l.ProductId, l.Quantity, l.PurchasePrice))
                .ToList();

            await _purchaseService.CreatePurchaseAsync(supplierId, items,
                (int)numInitialPayment.Value, txtNotes.Text);

            MessageBox.Show("Pembelian Berhasil Disimpan", "Sukses",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            _lines.Clear();
            numInitialPayment.Value = 0;
            txtNotes.Clear();
            RefreshTotal();
            txtBarcode.Focus();
        }
        catch (ValidationException ex)
        {
            MessageBox.Show(ex.Message, "Validasi Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        catch (EntityNotFoundException ex)
        {
            MessageBox.Show(ex.Message, "Data Tidak Ditemukan", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
