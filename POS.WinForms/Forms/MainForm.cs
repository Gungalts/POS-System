using Microsoft.Extensions.DependencyInjection;
using POS.WinForms.Data;
using POS.WinForms.Forms.Cashier;
using POS.WinForms.Forms.Login;
using POS.WinForms.Forms.Products;
using POS.WinForms.Forms.Purchasing;
using POS.WinForms.Forms.Stock;

namespace POS.WinForms.Forms;

public partial class MainForm : Form
{
    private readonly IServiceProvider _serviceProvider;
    private readonly UserSession _session;

    public MainForm(IServiceProvider serviceProvider, UserSession session)
    {
        _serviceProvider = serviceProvider;
        _session = session;
        InitializeComponent();
        ApplyRole();
    }

    // Menyembunyikan menu sesuai peran user yang login.
    private void ApplyRole()
    {
        var user = _session.CurrentUser;
        lblUser.Text = user is null
            ? "Belum login"
            : $"Login: {user.Username} ({user.Role})";

        bool manajer = _session.IsManajer;
        bool stocker = _session.IsStocker;
        bool kasir = _session.IsKasir;

        // Master data: terlihat semua peran (non-Manajer dibuka mode lihat saja).
        // Penjualan: Manajer & Kasir.
        btnKasir.Visible = manajer || kasir;
        // Input/output barang: Manajer & Stocker.
        btnPembelian.Visible = manajer || stocker;
        btnHutang.Visible = manajer || stocker;
        btnOpname.Visible = manajer || stocker;
        btnLedger.Visible = manajer || stocker;
        // Manajemen user: Manajer saja.
        btnUsers.Visible = manajer;
    }

    private void ShowDialog<TForm>() where TForm : Form
        => _serviceProvider.GetRequiredService<TForm>().ShowDialog();

    // Membuka form master data; mode lihat saja untuk non-Manajer.
    private void ShowMaster<TForm>() where TForm : Form, IReadOnlyForm
    {
        var form = _serviceProvider.GetRequiredService<TForm>();
        if (!_session.IsManajer) form.SetReadOnly();
        form.ShowDialog();
    }

    private void btnCategory_Click(object sender, EventArgs e) => ShowMaster<CategoryForm>();
    private void btnSupplier_Click(object sender, EventArgs e) => ShowMaster<SupplierForm>();
    private void btnCustomer_Click(object sender, EventArgs e) => ShowMaster<CustomerForm>();
    private void btnProduct_Click(object sender, EventArgs e) => ShowMaster<ProductForm>();
    private void btnKasir_Click(object sender, EventArgs e) => ShowDialog<KasirForm>();
    private void btnPembelian_Click(object sender, EventArgs e) => ShowDialog<PembelianForm>();
    private void btnHutang_Click(object sender, EventArgs e) => ShowDialog<PembayaranHutangForm>();
    private void btnOpname_Click(object sender, EventArgs e) => ShowDialog<StockOpnameForm>();
    private void btnLedger_Click(object sender, EventArgs e) => ShowDialog<StockLedgerForm>();
    private void btnUsers_Click(object sender, EventArgs e) => ShowDialog<UserForm>();

    private void btnLogout_Click(object sender, EventArgs e)
    {
        _session.CurrentUser = null;
        System.Windows.Forms.Application.Restart();
    }
}
