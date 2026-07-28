using POS.Application.Interfaces;
using POS.Domain.Entities;
using POS.Domain.Exceptions;

namespace POS.WinForms.Forms.Products;

public partial class SupplierForm : Form
{
    private readonly ISupplierService _supplierService;
    private int? _selectedId;

    public SupplierForm(ISupplierService supplierService)
    {
        _supplierService = supplierService;
        InitializeComponent();
    }

    private async void SupplierForm_Load(object sender, EventArgs e)
    {
        await LoadDataAsync();
    }

    private async Task LoadDataAsync()
    {
        var suppliers = await _supplierService.GetAllAsync();

        dgvSupplier.DataSource = suppliers.ToList();
        ClearForm();
    }

    private async void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (_selectedId is null)
                await _supplierService.CreateAsync(txtSupplierName.Text, txtPhoneNumber.Text);
            else
                await _supplierService.UpdateAsync(_selectedId.Value, txtSupplierName.Text, txtPhoneNumber.Text);

            await LoadDataAsync();
            MessageBox.Show("Data Supplier Berhasil Disimpan", "Sukses",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (ValidationException ex)
        {
            MessageBox.Show(ex.Message, "Validasi Gagal",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        catch (DuplicateEntityException ex)
        {
            MessageBox.Show(ex.Message, "Data Duplikat",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        catch (EntityNotFoundException ex)
        {
            MessageBox.Show(ex.Message, "Data Tidak Ditemukan",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private async void btnDelete_Click(object sender, EventArgs e)
    {
        if (_selectedId is null)
        {
            MessageBox.Show("Pilih Supplier Yang Ingin Dihapus", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var confirm = MessageBox.Show("Yakin Ingin Menghapus Supplier Ini?", "Konfirmasi",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        if (confirm != DialogResult.Yes) return;

        try
        {
            await _supplierService.DeleteAsync(_selectedId.Value);
            await LoadDataAsync();
        }
        catch (EntityNotFoundException ex)
        {
            MessageBox.Show(ex.Message, "Data Tidak Ditemukan",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void dgvSupplier_SelectionChanged(object sender, EventArgs e)
    {
        if (dgvSupplier.CurrentRow?.DataBoundItem is not Supplier selected) return;

        _selectedId = selected.SupplierId;
        txtSupplierName.Text = selected.SupplierName;
        txtPhoneNumber.Text = selected.PhoneNumber;
    }

    private void btnClear_Click(object sender, EventArgs e) => ClearForm();

    private void ClearForm()
    {
        _selectedId = null;
        txtSupplierName.Clear();
        txtPhoneNumber.Clear();
        dgvSupplier.ClearSelection();
    }
}
