using POS.Domain.Entities;

namespace POS.Domain.Interfaces;

public interface ISalesRepository
{
    // Insert header + detail + update stok produk + tulis stock_ledger, semua dalam satu transaksi.
    Task<int> CreateAsync(SalesHeader header, IReadOnlyList<Product> updatedProducts,
        IReadOnlyList<StockLedgerEntry> ledgerEntries);
    Task<SalesHeader?> GetByIdAsync(int id);
    Task<IEnumerable<SalesHeader>> GetAllAsync();
}
