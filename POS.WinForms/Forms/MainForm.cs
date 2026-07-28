using Microsoft.Extensions.DependencyInjection;
using POS.WinForms.Forms.Cashier;
using POS.WinForms.Forms.Products;
using POS.WinForms.Forms.Purchasing;
using POS.WinForms.Forms.Stock;

namespace POS.WinForms.Forms;

public partial class MainForm : Form
{
    private readonly IServiceProvider _serviceProvider;

    public MainForm(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
        InitializeComponent();
    }

    private void ShowDialog<TForm>() where TForm : Form
        => _serviceProvider.GetRequiredService<TForm>().ShowDialog();

    private void btnCategory_Click(object sender, EventArgs e) => ShowDialog<CategoryForm>();
    private void btnSupplier_Click(object sender, EventArgs e) => ShowDialog<SupplierForm>();
    private void btnCustomer_Click(object sender, EventArgs e) => ShowDialog<CustomerForm>();
    private void btnProduct_Click(object sender, EventArgs e) => ShowDialog<ProductForm>();
    private void btnKasir_Click(object sender, EventArgs e) => ShowDialog<KasirForm>();
    private void btnPembelian_Click(object sender, EventArgs e) => ShowDialog<PembelianForm>();
    private void btnHutang_Click(object sender, EventArgs e) => ShowDialog<PembayaranHutangForm>();
    private void btnOpname_Click(object sender, EventArgs e) => ShowDialog<StockOpnameForm>();
    private void btnLedger_Click(object sender, EventArgs e) => ShowDialog<StockLedgerForm>();
}
