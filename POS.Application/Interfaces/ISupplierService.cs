using POS.Domain.Entities;

namespace POS.Application.Interfaces;

public interface ISupplierService
{
    Task<Supplier?> GetByIdAsync(int id);
    Task<IEnumerable<Supplier>> GetAllAsync();
    Task<IEnumerable<Supplier>> SearchAsync(string keyword);
    Task<int> CreateAsync(string supplierName, string? phoneNumber);
    Task UpdateAsync(int id, string supplierName, string? phoneNumber);
    Task DeleteAsync(int id);
}