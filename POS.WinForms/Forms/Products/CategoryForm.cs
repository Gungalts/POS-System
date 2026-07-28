using POS.Application.Interfaces;
using POS.Domain.Entities;
using POS.Domain.Exceptions;

namespace POS.WinForms.Forms.Products;

public partial class CategoryForm : Form
{
    private readonly ICategoryService _categoryService;
    private int? _selectedId;

    public CategoryForm(ICategoryService categoryService)
    {
        _categoryService = categoryService;
        InitializeComponent();
    }

    private async void CategoryForm_Load(object sender, EventArgs e)
    {
        await LoadDataAsync();
    }

    private async Task LoadDataAsync()
    {
        var categories = await _categoryService.GetAllAsync();

        dgvCategory.DataSource = categories.ToList();
        ClearForm();
    }

    private async void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (_selectedId is null)
                await _categoryService.CreateAsync(txtCategoryName.Text);
            else
                await _categoryService.UpdateAsync(_selectedId.Value, txtCategoryName.Text);

            await LoadDataAsync();
            MessageBox.Show("Data Kategori Berhasil Disimpan", "Sukses",
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
            MessageBox.Show("Pilih Kategori Yang Ingin Dihapus", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var confirm = MessageBox.Show("Yakin Ingin Menghapus Kategori Ini?", "Konfirmasi",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        if (confirm != DialogResult.Yes) return;

        try
        {
            await _categoryService.DeleteAsync(_selectedId.Value);
            await LoadDataAsync();
        }
        catch (EntityNotFoundException ex)
        {
            MessageBox.Show(ex.Message, "Data Tidak Ditemukan",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void dgvCategory_SelectionChanged(object sender, EventArgs e)
    {
        if (dgvCategory.CurrentRow?.DataBoundItem is not Category selected) return;

        _selectedId = selected.CategoryId;
        txtCategoryName.Text = selected.CategoryName;
    }

    private void btnClear_Click(object sender, EventArgs e) => ClearForm();

    private void ClearForm()
    {
        _selectedId = null;
        txtCategoryName.Clear();
        dgvCategory.ClearSelection();
    }
}