using POS.Application.Interfaces;
using POS.Domain.Entities;
using POS.Domain.Exceptions;

namespace POS.WinForms.Forms.Purchasing;

public partial class PembayaranHutangForm : Form
{
    private readonly IPurchaseService _purchaseService;
    private readonly ISupplierService _supplierService;

    private sealed record ComboItem(int Id, string Name);

    public PembayaranHutangForm(IPurchaseService purchaseService, ISupplierService supplierService)
    {
        _purchaseService = purchaseService;
        _supplierService = supplierService;
        InitializeComponent();
    }

    private async void PembayaranHutangForm_Load(object sender, EventArgs e)
    {
        dgvUnpaid.AutoGenerateColumns = false;
        dgvHistory.AutoGenerateColumns = false;

        var suppliers = (await _supplierService.GetAllAsync())
            .Select(s => new ComboItem(s.SupplierId, s.SupplierName)).ToList();
        suppliers.Insert(0, new ComboItem(0, "(Pilih Supplier)"));
        cmbSupplier.DisplayMember = nameof(ComboItem.Name);
        cmbSupplier.ValueMember = nameof(ComboItem.Id);
        cmbSupplier.DataSource = suppliers;
    }

    private async void cmbSupplier_SelectedIndexChanged(object sender, EventArgs e)
        => await LoadUnpaidAsync();

    private async Task LoadUnpaidAsync()
    {
        dgvHistory.DataSource = null;
        int supplierId = cmbSupplier.SelectedValue is int v ? v : 0;
        if (supplierId <= 0)
        {
            dgvUnpaid.DataSource = null;
            lblDebtValue.Text = "Rp 0";
            return;
        }

        var unpaid = (await _purchaseService.GetUnpaidBySupplierAsync(supplierId)).ToList();
        dgvUnpaid.DataSource = unpaid;
        var debt = await _purchaseService.GetSupplierDebtAsync(supplierId);
        lblDebtValue.Text = $"Rp {debt:N0}";
    }

    private async void dgvUnpaid_SelectionChanged(object sender, EventArgs e)
    {
        if (dgvUnpaid.CurrentRow?.DataBoundItem is not PurchaseHeader h)
        {
            dgvHistory.DataSource = null;
            return;
        }
        var payments = (await _purchaseService.GetPaymentsAsync(h.PurchaseId)).ToList();
        dgvHistory.DataSource = payments;
        numPayment.Maximum = Math.Max(0, h.Remaining);
        numPayment.Value = Math.Max(0, h.Remaining);
    }

    private async void btnPay_Click(object sender, EventArgs e)
    {
        if (dgvUnpaid.CurrentRow?.DataBoundItem is not PurchaseHeader h)
        {
            MessageBox.Show("Pilih Pembelian Yang Ingin Dibayar", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        int amount = (int)numPayment.Value;
        if (amount <= 0)
        {
            MessageBox.Show("Jumlah Pembayaran Harus Lebih Dari 0", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        try
        {
            await _purchaseService.AddPaymentAsync(h.PurchaseId, amount, txtNotes.Text);
            txtNotes.Clear();
            await LoadUnpaidAsync();
            MessageBox.Show("Pembayaran Tercatat", "Sukses",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (ValidationException ex)
        {
            MessageBox.Show(ex.Message, "Validasi Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        catch (InvalidOperationException ex)
        {
            MessageBox.Show(ex.Message, "Tidak Valid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        catch (EntityNotFoundException ex)
        {
            MessageBox.Show(ex.Message, "Data Tidak Ditemukan", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
