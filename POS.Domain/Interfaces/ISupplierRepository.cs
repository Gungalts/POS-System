using POS.Domain.Entities;

namespace POS.Domain.Interfaces;

public interface ISupplierRepository
{
    Task<Supplier?> GetByIdAsync(int id);
    Task<IEnumerable<Supplier>> GetAllAsync();
    Task<IEnumerable<Supplier>> SearchAsync(string keyword);
    Task<int> AddAsync(Supplier supplier);
    Task UpdateAsync(Supplier supplier);
    Task DeleteAsync(int id);
}
