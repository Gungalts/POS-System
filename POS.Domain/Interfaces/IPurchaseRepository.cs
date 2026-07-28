using POS.Domain.Entities;

namespace POS.Domain.Interfaces;

public interface IPurchaseRepository
{
    // Insert header + detail + update stok/average_cost/purchase_price produk dalam satu transaksi.
    Task<int> CreateAsync(PurchaseHeader header, IReadOnlyList<Product> updatedProducts);
    Task<PurchaseHeader?> GetByIdAsync(int id);
    Task<IEnumerable<PurchaseHeader>> GetAllAsync();
    Task<IEnumerable<PurchaseHeader>> GetUnpaidBySupplierAsync(int supplierId);

    // Insert baris pembayaran + update amount_paid/payment_status header dalam satu transaksi.
    Task AddPaymentAsync(PurchasePayment payment, PurchaseHeader updatedHeader);
    Task<IEnumerable<PurchasePayment>> GetPaymentsAsync(int purchaseId);
}
