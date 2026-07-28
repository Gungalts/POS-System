using System.ComponentModel;
using POS.Application.Interfaces;
using POS.Application.Requests;
using POS.Domain.Exceptions;

namespace POS.WinForms.Forms.Cashier;

public partial class KasirForm : Form
{
    private readonly ISalesService _salesService;
    private readonly IProductService _productService;
    private readonly ICustomerService _customerService;

    private readonly BindingList<CartItemVm> _cart = new();

    private sealed record ComboItem(int Id, string Name);

    public KasirForm(ISalesService salesService, IProductService productService,
        ICustomerService customerService)
    {
        _salesService = salesService;
        _productService = productService;
        _customerService = customerService;
        InitializeComponent();
    }

    private async void KasirForm_Load(object sender, EventArgs e)
    {
        dgvCart.AutoGenerateColumns = false;
        dgvCart.DataSource = _cart;

        var customers = (await _customerService.GetAllAsync())
            .Select(c => new ComboItem(c.CustomerId, c.CustomerName)).ToList();
        customers.Insert(0, new ComboItem(0, "(Pelanggan Umum)"));
        cmbCustomer.DisplayMember = nameof(ComboItem.Name);
        cmbCustomer.ValueMember = nameof(ComboItem.Id);
        cmbCustomer.DataSource = customers;

        cmbPaymentMethod.Items.AddRange(new object[] { "Tunai", "Transfer", "QRIS", "Debit" });
        cmbPaymentMethod.SelectedIndex = 0;

        RefreshTotals();
        txtBarcode.Focus();
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
            else if (matches.Count == 0)
            {
                MessageBox.Show($"Produk '{keyword}' Tidak Ditemukan", "Tidak Ditemukan",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                MessageBox.Show("Barcode/Kata Kunci Cocok Dengan Banyak Produk. Perjelas Pencarian.",
                    "Ambigu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        var existing = _cart.FirstOrDefault(c => c.ProductId == product.ProductId);
        if (existing is not null)
            existing.Quantity++;
        else
            _cart.Add(new CartItemVm
            {
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                SalePrice = (int)product.SalePrice,
                Quantity = 1
            });

        dgvCart.Refresh();
        RefreshTotals();
        txtBarcode.Clear();
        txtBarcode.Focus();
    }

    private void dgvCart_CellEndEdit(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0 || e.RowIndex >= _cart.Count) return;
        if (dgvCart.Columns[e.ColumnIndex].Name != "colQty") return;

        var vm = _cart[e.RowIndex];
        if (vm.Quantity < 1) vm.Quantity = 1;
        dgvCart.Refresh();
        RefreshTotals();
    }

    private void btnRemoveItem_Click(object sender, EventArgs e)
    {
        if (dgvCart.CurrentRow?.DataBoundItem is not CartItemVm vm) return;
        _cart.Remove(vm);
        RefreshTotals();
    }

    private void btnClearCart_Click(object sender, EventArgs e)
    {
        _cart.Clear();
        numAmountPaid.Value = 0;
        RefreshTotals();
        txtBarcode.Focus();
    }

    private void numAmountPaid_ValueChanged(object sender, EventArgs e) => RefreshChange();

    private void RefreshTotals()
    {
        lblTotalValue.Text = $"Rp {GrandTotal():N0}";
        RefreshChange();
    }

    private void RefreshChange()
    {
        int change = (int)numAmountPaid.Value - GrandTotal();
        lblChangeValue.Text = change >= 0 ? $"Rp {change:N0}" : $"Kurang Rp {-change:N0}";
        lblChangeValue.ForeColor = change >= 0 ? System.Drawing.Color.Green : System.Drawing.Color.Firebrick;
    }

    private int GrandTotal() => _cart.Sum(c => c.Subtotal);

    private async void btnCheckout_Click(object sender, EventArgs e)
    {
        if (_cart.Count == 0)
        {
            MessageBox.Show("Keranjang Masih Kosong", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        try
        {
            int? customerId = ((int)cmbCustomer.SelectedValue!) is var cid && cid > 0 ? cid : null;
            var items = _cart.Select(c => new SaleItemRequest(c.ProductId, c.Quantity)).ToList();

            await _salesService.CreateSaleAsync(customerId, items,
                cmbPaymentMethod.SelectedItem?.ToString() ?? "Tunai", (int)numAmountPaid.Value);

            int change = (int)numAmountPaid.Value - GrandTotal();
            MessageBox.Show($"Transaksi Berhasil.\nKembalian: Rp {change:N0}", "Sukses",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            _cart.Clear();
            numAmountPaid.Value = 0;
            RefreshTotals();
            txtBarcode.Focus();
        }
        catch (ValidationException ex)
        {
            MessageBox.Show(ex.Message, "Validasi Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        catch (InvalidOperationException ex)
        {
            MessageBox.Show(ex.Message, "Stok Tidak Cukup", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        catch (EntityNotFoundException ex)
        {
            MessageBox.Show(ex.Message, "Data Tidak Ditemukan", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
