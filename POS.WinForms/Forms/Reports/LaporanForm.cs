using POS.Application.Interfaces;
using POS.Domain.Entities;
using POS.WinForms.Data;

namespace POS.WinForms.Forms.Reports;

public partial class LaporanForm : Form
{
    private readonly IReportService _reportService;
    private readonly UserSession _session;

    public LaporanForm(IReportService reportService, UserSession session)
    {
        _reportService = reportService;
        _session = session;
        InitializeComponent();
    }

    private async void LaporanForm_Load(object sender, EventArgs e)
    {
        dgvSales.AutoGenerateColumns = false;
        dgvPurchase.AutoGenerateColumns = false;
        dgvDebt.AutoGenerateColumns = false;
        dgvInventory.AutoGenerateColumns = false;

        var firstOfMonth = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
        dtpSalesFrom.Value = firstOfMonth;
        dtpSalesTo.Value = DateTime.Today;
        dtpPurchaseFrom.Value = firstOfMonth;
        dtpPurchaseTo.Value = DateTime.Today;

        ApplyRole();
        await LoadPermittedInitialAsync();
    }

    // Menyisakan hanya tab yang boleh diakses peran ini.
    private void ApplyRole()
    {
        bool manajer = _session.IsManajer;
        bool stocker = _session.IsStocker;
        bool kasir = _session.IsKasir;

        if (!(manajer || kasir)) tabControl.TabPages.Remove(tabSales);
        if (!(manajer || stocker)) tabControl.TabPages.Remove(tabPurchase);
        if (!manajer) tabControl.TabPages.Remove(tabDebt);
        if (!(manajer || stocker)) tabControl.TabPages.Remove(tabInventory);
    }

    private async Task LoadPermittedInitialAsync()
    {
        // Muat data untuk tab yang tersisa (pertama yang ada).
        if (tabControl.TabPages.Contains(tabSales)) await LoadSalesAsync();
        if (tabControl.TabPages.Contains(tabPurchase)) await LoadPurchaseAsync();
        if (tabControl.TabPages.Contains(tabDebt)) await LoadDebtAsync();
        if (tabControl.TabPages.Contains(tabInventory)) await LoadInventoryAsync();
    }

    // --- Penjualan & Laba Kotor ---
    private async void btnSalesShow_Click(object sender, EventArgs e) => await LoadSalesAsync();

    private async Task LoadSalesAsync()
    {
        var from = dtpSalesFrom.Value;
        var to = dtpSalesTo.Value;
        var summary = await _reportService.GetSalesSummaryAsync(from, to);
        var rows = (await _reportService.GetSalesByProductAsync(from, to)).ToList();

        dgvSales.DataSource = rows;
        lblSalesSummary.Text =
            $"Transaksi: {summary.TransactionCount}    |    Omzet: Rp {summary.Revenue:N0}" +
            $"    |    HPP: Rp {summary.Cogs:N0}    |    Laba Kotor: Rp {summary.GrossProfit:N0}";
    }

    // --- Pembelian per Supplier ---
    private async void btnPurchaseShow_Click(object sender, EventArgs e) => await LoadPurchaseAsync();

    private async Task LoadPurchaseAsync()
    {
        var rows = (await _reportService.GetPurchaseBySupplierAsync(dtpPurchaseFrom.Value, dtpPurchaseTo.Value)).ToList();
        dgvPurchase.DataSource = rows;
        lblPurchaseTotal.Text =
            $"Total Pembelian: Rp {rows.Sum(r => r.TotalPurchase):N0}" +
            $"    |    Sisa Belum Dibayar: Rp {rows.Sum(r => r.Outstanding):N0}";
    }

    // --- Hutang Supplier ---
    private async void btnDebtRefresh_Click(object sender, EventArgs e) => await LoadDebtAsync();

    private async Task LoadDebtAsync()
    {
        var rows = (await _reportService.GetSupplierDebtAsync()).ToList();
        dgvDebt.DataSource = rows;
        lblDebtTotal.Text = $"Total Hutang Berjalan: Rp {rows.Sum(r => r.Outstanding):N0}";
    }

    // --- Nilai Persediaan ---
    private async void btnInventoryRefresh_Click(object sender, EventArgs e) => await LoadInventoryAsync();

    private async Task LoadInventoryAsync()
    {
        var rows = (await _reportService.GetInventoryValueAsync()).ToList();
        dgvInventory.DataSource = rows;
        lblInventoryTotal.Text = $"Total Nilai Persediaan: Rp {rows.Sum(r => r.Value):N0}";
    }
}
