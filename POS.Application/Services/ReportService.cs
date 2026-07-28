using POS.Application.Interfaces;
using POS.Domain.Interfaces;
using POS.Domain.Reports;

namespace POS.Application.Services;

public class ReportService : IReportService
{
    private readonly IReportRepository _repo;
    public ReportService(IReportRepository repo) => _repo = repo;

    // 'to' inklusif sampai akhir hari (konsisten dgn StockLedgerService).
    public Task<SalesSummaryRow> GetSalesSummaryAsync(DateTime from, DateTime to)
        => _repo.GetSalesSummaryAsync(from.Date, to.Date.AddDays(1));

    public Task<IEnumerable<SalesByProductRow>> GetSalesByProductAsync(DateTime from, DateTime to)
        => _repo.GetSalesByProductAsync(from.Date, to.Date.AddDays(1));

    public Task<IEnumerable<PurchaseBySupplierRow>> GetPurchaseBySupplierAsync(DateTime from, DateTime to)
        => _repo.GetPurchaseBySupplierAsync(from.Date, to.Date.AddDays(1));

    public Task<IEnumerable<SupplierDebtRow>> GetSupplierDebtAsync() => _repo.GetSupplierDebtAsync();

    public Task<IEnumerable<InventoryValueRow>> GetInventoryValueAsync() => _repo.GetInventoryValueAsync();
}
