using POS.Application.Interfaces;
using POS.Domain.Entities;
using POS.Domain.Exceptions;

namespace POS.WinForms.Forms.Products;

public partial class CustomerForm : Form
{
    private readonly ICustomerService _customerService;
    private int? _selectedId;

    public CustomerForm(ICustomerService customerService)
    {
        _customerService = customerService;
        InitializeComponent();
    }

    private async void CustomerForm_Load(object sender, EventArgs e)
    {
        await LoadDataAsync();
    }

    private async Task LoadDataAsync()
    {
        var customers = await _customerService.GetAllAsync();

        dgvCustomer.DataSource = customers.ToList();
        ClearForm();
    }

    private async void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (_selectedId is null)
                await _customerService.CreateAsync(txtCustomerName.Text, txtPhoneNumber.Text, txtAddress.Text);
            else
                await _customerService.UpdateAsync(_selectedId.Value, txtCustomerName.Text, txtPhoneNumber.Text, txtAddress.Text);

            await LoadDataAsync();
            MessageBox.Show("Data Customer Berhasil Disimpan", "Sukses",
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
            MessageBox.Show("Pilih Customer Yang Ingin Dihapus", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var confirm = MessageBox.Show("Yakin Ingin Menghapus Customer Ini?", "Konfirmasi",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        if (confirm != DialogResult.Yes) return;

        try
        {
            await _customerService.DeleteAsync(_selectedId.Value);
            await LoadDataAsync();
        }
        catch (EntityNotFoundException ex)
        {
            MessageBox.Show(ex.Message, "Data Tidak Ditemukan",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void dgvCustomer_SelectionChanged(object sender, EventArgs e)
    {
        if (dgvCustomer.CurrentRow?.DataBoundItem is not Customer selected) return;

        _selectedId = selected.CustomerId;
        txtCustomerName.Text = selected.CustomerName;
        txtPhoneNumber.Text = selected.PhoneNumber;
        txtAddress.Text = selected.Address;
    }

    private void btnClear_Click(object sender, EventArgs e) => ClearForm();

    private void ClearForm()
    {
        _selectedId = null;
        txtCustomerName.Clear();
        txtPhoneNumber.Clear();
        txtAddress.Clear();
        dgvCustomer.ClearSelection();
    }
}
