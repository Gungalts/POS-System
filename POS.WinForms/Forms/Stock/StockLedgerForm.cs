using POS.Application.Interfaces;

namespace POS.WinForms.Forms.Stock;

public partial class StockLedgerForm : Form
{
    private readonly IStockLedgerService _ledgerService;
    private readonly IProductService _productService;

    private sealed record ComboItem(int Id, string Name);

    public StockLedgerForm(IStockLedgerService ledgerService, IProductService productService)
    {
        _ledgerService = ledgerService;
        _productService = productService;
        InitializeComponent();
    }

    private async void StockLedgerForm_Load(object sender, EventArgs e)
    {
        dgvLedger.AutoGenerateColumns = false;

        var products = (await _productService.GetAllAsync())
            .Select(p => new ComboItem(p.ProductId, p.ProductName)).ToList();
        products.Insert(0, new ComboItem(0, "(Semua Produk)"));
        cmbProduct.DisplayMember = nameof(ComboItem.Name);
        cmbProduct.ValueMember = nameof(ComboItem.Id);
        cmbProduct.DataSource = products;

        dtpFrom.Value = DateTime.Today.AddDays(-30);
        dtpTo.Value = DateTime.Today;

        await LoadAllAsync();
    }

    private async Task LoadAllAsync()
        => dgvLedger.DataSource = (await _ledgerService.GetAllAsync()).ToList();

    private async void btnApply_Click(object sender, EventArgs e)
    {
        int productId = cmbProduct.SelectedValue is int v ? v : 0;
        var data = productId > 0
            ? await _ledgerService.GetByProductAsync(productId)
            : await _ledgerService.GetByDateRangeAsync(dtpFrom.Value, dtpTo.Value);
        dgvLedger.DataSource = data.ToList();
    }

    private async void btnAll_Click(object sender, EventArgs e)
    {
        cmbProduct.SelectedValue = 0;
        await LoadAllAsync();
    }
}
