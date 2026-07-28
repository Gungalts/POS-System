using System.ComponentModel;
using POS.Application.Interfaces;
using POS.Application.Requests;
using POS.Domain.Exceptions;

namespace POS.WinForms.Forms.Stock;

public partial class StockOpnameForm : Form
{
    private readonly IStockOpnameService _opnameService;
    private readonly IProductService _productService;

    private readonly BindingList<OpnameLineVm> _lines = new();

    public StockOpnameForm(IStockOpnameService opnameService, IProductService productService)
    {
        _opnameService = opnameService;
        _productService = productService;
        InitializeComponent();
    }

    private async void StockOpnameForm_Load(object sender, EventArgs e)
    {
        dgvOpname.AutoGenerateColumns = false;
        dgvOpname.DataSource = _lines;
        await LoadProductsAsync();
    }

    private async Task LoadProductsAsync()
    {
        _lines.Clear();
        var products = await _productService.GetAllAsync();
        foreach (var p in products.OrderBy(p => p.ProductName))
            _lines.Add(new OpnameLineVm
            {
                ProductId = p.ProductId,
                ProductName = p.ProductName,
                SystemStock = p.Stock,
                PhysicalStock = p.Stock // default: dianggap sama sampai dihitung
            });
        dgvOpname.Refresh();
    }

    private void dgvOpname_CellEndEdit(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0 || e.RowIndex >= _lines.Count) return;
        var vm = _lines[e.RowIndex];
        if (vm.PhysicalStock < 0) vm.PhysicalStock = 0;
        dgvOpname.Refresh();
    }

    private async void btnReload_Click(object sender, EventArgs e) => await LoadProductsAsync();

    private async void btnSave_Click(object sender, EventArgs e)
    {
        if (_lines.Count == 0)
        {
            MessageBox.Show("Tidak Ada Produk Untuk Diopname", "Peringatan",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        int changed = _lines.Count(l => l.Difference != 0);
        var confirm = MessageBox.Show(
            $"Simpan Stock Opname?\n{changed} produk memiliki selisih dan stoknya akan disesuaikan.",
            "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        if (confirm != DialogResult.Yes) return;

        try
        {
            var lines = _lines
                .Select(l => new OpnameLineRequest(l.ProductId, l.PhysicalStock))
                .ToList();

            await _opnameService.CreateOpnameAsync(txtNotes.Text, lines);

            MessageBox.Show("Stock Opname Berhasil Disimpan", "Sukses",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            txtNotes.Clear();
            await LoadProductsAsync();
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
