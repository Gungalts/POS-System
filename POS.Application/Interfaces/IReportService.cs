using POS.Domain.Reports;

namespace POS.Application.Interfaces;

public interface IReportService
{
    Task<SalesSummaryRow> GetSalesSummaryAsync(DateTime from, DateTime to);
    Task<IEnumerable<SalesByProductRow>> GetSalesByProductAsync(DateTime from, DateTime to);
    Task<IEnumerable<PurchaseBySupplierRow>> GetPurchaseBySupplierAsync(DateTime from, DateTime to);
    Task<IEnumerable<SupplierDebtRow>> GetSupplierDebtAsync();
    Task<IEnumerable<InventoryValueRow>> GetInventoryValueAsync();
}
