using POS.Application.Interfaces;
using POS.Application.Requests;
using POS.Domain.Entities;
using POS.Domain.Exceptions;
using POS.Domain.Interfaces;

namespace POS.Application.Services;

public class PurchaseService : IPurchaseService
{
    private readonly IPurchaseRepository _repo;
    private readonly IProductRepository _products;

    public PurchaseService(IPurchaseRepository repo, IProductRepository products)
    {
        _repo = repo;
        _products = products;
    }

    public async Task<int> CreatePurchaseAsync(int supplierId, IEnumerable<PurchaseItemRequest> items,
        int initialPayment, string? notes)
    {
        var itemList = items?.ToList() ?? new List<PurchaseItemRequest>();
        if (itemList.Count == 0)
            throw new ValidationException("Transaksi Pembelian Harus Memiliki Minimal Satu Item");

        var header = new PurchaseHeader
        {
            SupplierId = supplierId,
            Notes = notes?.Trim()
        };
        var updatedProducts = new List<Product>();
        var ledgerEntries = new List<StockLedgerEntry>();

        foreach (var item in itemList)
        {
            var product = await _products.GetByIdAsync(item.ProductId)
                ?? throw new EntityNotFoundException(
                    $"Produk dengan id {item.ProductId} tidak ditemukan");

            // Moving average + penambahan stok dihitung di entity.
            int stockBefore = product.Stock;
            product.ReceiveStock(item.Quantity, item.PurchasePrice);
            updatedProducts.Add(product);

            ledgerEntries.Add(new StockLedgerEntry
            {
                ProductId = product.ProductId,
                MovementType = MovementType.Pembelian,
                QuantityChange = product.Stock - stockBefore,
                StockBefore = stockBefore,
                StockAfter = product.Stock,
                ReferenceType = ReferenceType.Purchase,
                Notes = "Pembelian"
            });

            int purchasePrice = (int)item.PurchasePrice;
            header.Details.Add(new PurchaseDetail
            {
                ProductId = item.ProductId,
                Quantity = item.Quantity,
                PurchasePrice = purchasePrice,
                Subtotal = item.Quantity * purchasePrice
            });
        }

        header.GrandTotal = header.Details.Sum(d => d.Subtotal);

        if (initialPayment < 0)
            throw new ValidationException("Pembayaran Awal Tidak Boleh Negatif");
        if (initialPayment > header.GrandTotal)
            throw new ValidationException("Pembayaran Awal Melebihi Total Pembelian");

        header.AmountPaid = initialPayment;
        header.RecalculatePaymentStatus();

        return await _repo.CreateAsync(header, updatedProducts, ledgerEntries);
    }

    public async Task AddPaymentAsync(int purchaseId, int amount, string? notes)
    {
        var header = await _repo.GetByIdAsync(purchaseId)
            ?? throw new EntityNotFoundException(
                $"Pembelian dengan id {purchaseId} tidak ditemukan");

        // ApplyPayment memvalidasi amount > 0 dan tidak melebihi sisa hutang.
        header.ApplyPayment(amount);

        var payment = new PurchasePayment
        {
            PurchaseId = purchaseId,
            Amount = amount,
            Notes = notes?.Trim()
        };

        await _repo.AddPaymentAsync(payment, header);
    }

    public async Task<int> GetSupplierDebtAsync(int supplierId)
    {
        var unpaid = await _repo.GetUnpaidBySupplierAsync(supplierId);
        return unpaid.Sum(h => h.Remaining);
    }

    public Task<IEnumerable<PurchaseHeader>> GetUnpaidBySupplierAsync(int supplierId)
        => _repo.GetUnpaidBySupplierAsync(supplierId);

    public Task<PurchaseHeader?> GetByIdAsync(int id) => _repo.GetByIdAsync(id);

    public Task<IEnumerable<PurchaseHeader>> GetAllAsync() => _repo.GetAllAsync();

    public Task<IEnumerable<PurchasePayment>> GetPaymentsAsync(int purchaseId)
        => _repo.GetPaymentsAsync(purchaseId);
}
