using POS.Domain.Entities;

namespace POS.Application.Interfaces;

public interface IStockLedgerService
{
    Task<IEnumerable<StockLedgerEntry>> GetAllAsync();
    Task<IEnumerable<StockLedgerEntry>> GetByProductAsync(int productId);
    Task<IEnumerable<StockLedgerEntry>> GetByDateRangeAsync(DateTime from, DateTime to);
}
