using POS.Application.Requests;
using POS.Domain.Entities;

namespace POS.Application.Interfaces;

public interface ISalesService
{
    Task<int> CreateSaleAsync(int? customerId, IEnumerable<SaleItemRequest> items,
        string paymentMethod, int amountPaid);
    Task<SalesHeader?> GetByIdAsync(int id);
    Task<IEnumerable<SalesHeader>> GetAllAsync();
}
