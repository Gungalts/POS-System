using POS.Domain.Entities;

namespace POS.Domain.Interfaces;

public interface IStockOpnameRepository
{
    // Insert header + detail + update stok produk yang berubah + tulis stock_ledger, satu transaksi.
    Task<int> CreateAsync(StockOpnameHeader header, IReadOnlyList<Product> updatedProducts,
        IReadOnlyList<StockLedgerEntry> ledgerEntries);
    Task<StockOpnameHeader?> GetByIdAsync(int id);
    Task<IEnumerable<StockOpnameHeader>> GetAllAsync();
}
