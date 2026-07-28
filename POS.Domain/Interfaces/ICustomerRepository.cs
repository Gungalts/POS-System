using POS.Domain.Entities;

namespace POS.Domain.Interfaces;

public interface ICustomerRepository
{
    Task<Customer?> GetByIdAsync(int id);
    Task<IEnumerable<Customer>> GetAllAsync();
    Task<IEnumerable<Customer>> SearchAsync(string keyword);
    Task<int> AddAsync(Customer customer);
    Task UpdateAsync(Customer customer);
    Task DeleteAsync(int id);
}