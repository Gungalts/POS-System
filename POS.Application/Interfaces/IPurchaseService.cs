using POS.Application.Requests;
using POS.Domain.Entities;

namespace POS.Application.Interfaces;

public interface IPurchaseService
{
    Task<int> CreatePurchaseAsync(int supplierId, IEnumerable<PurchaseItemRequest> items,
        int initialPayment, string? notes);
    Task AddPaymentAsync(int purchaseId, int amount, string? notes);
    Task<int> GetSupplierDebtAsync(int supplierId);
    Task<IEnumerable<PurchaseHeader>> GetUnpaidBySupplierAsync(int supplierId);
    Task<PurchaseHeader?> GetByIdAsync(int id);
    Task<IEnumerable<PurchaseHeader>> GetAllAsync();
    Task<IEnumerable<PurchasePayment>> GetPaymentsAsync(int purchaseId);
}
