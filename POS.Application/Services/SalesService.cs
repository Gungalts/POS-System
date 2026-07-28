using POS.Application.Interfaces;
using POS.Application.Requests;
using POS.Domain.Entities;
using POS.Domain.Exceptions;
using POS.Domain.Interfaces;

namespace POS.Application.Services;

public class SalesService : ISalesService
{
    private readonly ISalesRepository _repo;
    private readonly IProductRepository _products;

    public SalesService(ISalesRepository repo, IProductRepository products)
    {
        _repo = repo;
        _products = products;
    }

    public async Task<int> CreateSaleAsync(int? customerId, IEnumerable<SaleItemRequest> items,
        string paymentMethod, int amountPaid)
    {
        var itemList = items?.ToList() ?? new List<SaleItemRequest>();
        if (itemList.Count == 0)
            throw new ValidationException("Transaksi Penjualan Harus Memiliki Minimal Satu Item");

        var header = new SalesHeader
        {
            CustomerId = customerId,
            PaymentMethod = string.IsNullOrWhiteSpace(paymentMethod) ? "Tunai" : paymentMethod.Trim(),
            AmountPaid = amountPaid
        };
        var updatedProducts = new List<Product>();
        var ledgerEntries = new List<StockLedgerEntry>();

        foreach (var item in itemList)
        {
            var product = await _products.GetByIdAsync(item.ProductId)
                ?? throw new EntityNotFoundException(
                    $"Produk dengan id {item.ProductId} tidak ditemukan");

            // ReduceStock melempar bila stok tidak cukup.
            int stockBefore = product.Stock;
            product.ReduceStock(item.Quantity);
            updatedProducts.Add(product);

            ledgerEntries.Add(new StockLedgerEntry
            {
                ProductId = product.ProductId,
                MovementType = MovementType.Penjualan,
                QuantityChange = product.Stock - stockBefore, // negatif
                StockBefore = stockBefore,
                StockAfter = product.Stock,
                ReferenceType = ReferenceType.Sale,
                Notes = "Penjualan"
            });

            int salePrice = (int)product.SalePrice;
            header.Details.Add(new SalesDetail
            {
                ProductId = item.ProductId,
                Quantity = item.Quantity,
                SalePrice = salePrice,
                CostOfGoodsSold = product.AverageCost, // snapshot HPP saat transaksi
                Subtotal = item.Quantity * salePrice
            });
        }

        header.GrandTotal = header.Details.Sum(d => d.Subtotal);

        // Aturan bisnis inti: jual harus lunas.
        header.EnsurePaidInFull();

        return await _repo.CreateAsync(header, updatedProducts, ledgerEntries);
    }

    public Task<SalesHeader?> GetByIdAsync(int id) => _repo.GetByIdAsync(id);

    public Task<IEnumerable<SalesHeader>> GetAllAsync() => _repo.GetAllAsync();
}
