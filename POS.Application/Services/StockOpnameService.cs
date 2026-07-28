using POS.Application.Interfaces;
using POS.Application.Requests;
using POS.Domain.Entities;
using POS.Domain.Exceptions;
using POS.Domain.Interfaces;

namespace POS.Application.Services;

public class StockOpnameService : IStockOpnameService
{
    private readonly IStockOpnameRepository _repo;
    private readonly IProductRepository _products;

    public StockOpnameService(IStockOpnameRepository repo, IProductRepository products)
    {
        _repo = repo;
        _products = products;
    }

    public async Task<int> CreateOpnameAsync(string? notes, IEnumerable<OpnameLineRequest> lines)
    {
        var lineList = lines?.ToList() ?? new List<OpnameLineRequest>();
        if (lineList.Count == 0)
            throw new ValidationException("Stock Opname Harus Memiliki Minimal Satu Baris");

        var header = new StockOpnameHeader { Notes = notes?.Trim() };
        var updatedProducts = new List<Product>();
        var ledgerEntries = new List<StockLedgerEntry>();

        foreach (var line in lineList)
        {
            var product = await _products.GetByIdAsync(line.ProductId)
                ?? throw new EntityNotFoundException(
                    $"Produk dengan id {line.ProductId} tidak ditemukan");

            int systemStock = product.Stock;
            int difference = line.PhysicalStock - systemStock;

            header.Details.Add(new StockOpnameDetail
            {
                ProductId = product.ProductId,
                SystemStock = systemStock,
                PhysicalStock = line.PhysicalStock,
                Difference = difference
            });

            // Hanya sesuaikan stok & catat ledger bila ada selisih.
            if (difference == 0) continue;

            product.SetStockFromOpname(line.PhysicalStock);
            updatedProducts.Add(product);

            ledgerEntries.Add(new StockLedgerEntry
            {
                ProductId = product.ProductId,
                MovementType = MovementType.Opname,
                QuantityChange = difference,
                StockBefore = systemStock,
                StockAfter = line.PhysicalStock,
                ReferenceType = ReferenceType.Opname,
                Notes = "Stock Opname"
            });
        }

        return await _repo.CreateAsync(header, updatedProducts, ledgerEntries);
    }

    public Task<StockOpnameHeader?> GetByIdAsync(int id) => _repo.GetByIdAsync(id);

    public Task<IEnumerable<StockOpnameHeader>> GetAllAsync() => _repo.GetAllAsync();
}
