using POS.Application.Interfaces;
using POS.Domain.Entities;
using POS.Domain.Exceptions;

namespace POS.WinForms.Forms.Login;

public partial class UserForm : Form
{
    private readonly IUserService _userService;
    private int? _selectedId;

    public UserForm(IUserService userService)
    {
        _userService = userService;
        InitializeComponent();
    }

    private async void UserForm_Load(object sender, EventArgs e)
    {
        dgvUser.AutoGenerateColumns = false;
        cmbRole.Items.AddRange(UserRole.All);
        cmbRole.SelectedItem = UserRole.Kasir;
        await LoadDataAsync();
    }

    private async Task LoadDataAsync()
    {
        dgvUser.DataSource = (await _userService.GetAllAsync()).ToList();
        ClearForm();
    }

    private async void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            string role = cmbRole.SelectedItem?.ToString() ?? UserRole.Kasir;
            if (_selectedId is null)
                await _userService.CreateAsync(txtUsername.Text, txtPassword.Text, role, txtFullName.Text);
            else
                await _userService.UpdateAsync(_selectedId.Value, role, txtFullName.Text);

            await LoadDataAsync();
            MessageBox.Show("Data User Berhasil Disimpan", "Sukses",
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

    private async void btnResetPassword_Click(object sender, EventArgs e)
    {
        if (_selectedId is null)
        {
            MessageBox.Show("Pilih User Terlebih Dahulu", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        try
        {
            await _userService.ChangePasswordAsync(_selectedId.Value, txtPassword.Text);
            MessageBox.Show("Password Berhasil Diubah", "Sukses",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            txtPassword.Clear();
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

    private async void btnDelete_Click(object sender, EventArgs e)
    {
        if (_selectedId is null)
        {
            MessageBox.Show("Pilih User Yang Ingin Dihapus", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var confirm = MessageBox.Show("Yakin Ingin Menghapus User Ini?", "Konfirmasi",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        if (confirm != DialogResult.Yes) return;

        try
        {
            await _userService.DeleteAsync(_selectedId.Value);
            await LoadDataAsync();
        }
        catch (ValidationException ex)
        {
            MessageBox.Show(ex.Message, "Tidak Diizinkan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        catch (EntityNotFoundException ex)
        {
            MessageBox.Show(ex.Message, "Data Tidak Ditemukan", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void dgvUser_SelectionChanged(object sender, EventArgs e)
    {
        if (dgvUser.CurrentRow?.DataBoundItem is not UserAccount u) return;

        _selectedId = u.UserId;
        txtUsername.Text = u.Username;
        txtUsername.Enabled = false; // username tidak diubah saat edit
        txtFullName.Text = u.FullName;
        cmbRole.SelectedItem = u.Role;
        txtPassword.Clear();
    }

    private void btnClear_Click(object sender, EventArgs e) => ClearForm();

    private void ClearForm()
    {
        _selectedId = null;
        txtUsername.Clear();
        txtUsername.Enabled = true;
        txtFullName.Clear();
        txtPassword.Clear();
        cmbRole.SelectedItem = UserRole.Kasir;
        dgvUser.ClearSelection();
    }
}
