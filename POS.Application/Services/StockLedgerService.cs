using POS.Application.Interfaces;
using POS.Domain.Entities;
using POS.Domain.Interfaces;

namespace POS.Application.Services;

public class StockLedgerService : IStockLedgerService
{
    private readonly IStockLedgerRepository _repo;
    public StockLedgerService(IStockLedgerRepository repo) => _repo = repo;

    public Task<IEnumerable<StockLedgerEntry>> GetAllAsync() => _repo.GetAllAsync();

    public Task<IEnumerable<StockLedgerEntry>> GetByProductAsync(int productId)
        => _repo.GetByProductAsync(productId);

    // 'to' diperlakukan inklusif sampai akhir hari.
    public Task<IEnumerable<StockLedgerEntry>> GetByDateRangeAsync(DateTime from, DateTime to)
        => _repo.GetByDateRangeAsync(from.Date, to.Date.AddDays(1));
}
