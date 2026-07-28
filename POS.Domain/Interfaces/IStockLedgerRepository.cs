using POS.Domain.Entities;

namespace POS.Domain.Interfaces;

public interface IStockLedgerRepository
{
    Task<IEnumerable<StockLedgerEntry>> GetAllAsync();
    Task<IEnumerable<StockLedgerEntry>> GetByProductAsync(int productId);
    Task<IEnumerable<StockLedgerEntry>> GetByDateRangeAsync(DateTime from, DateTime to);
}
