using POS.Domain.Entities;

namespace POS.Application.Interfaces;

public interface ICustomerService
{
    Task<Customer?> GetByIdAsync(int id);
    Task<IEnumerable<Customer>> GetAllAsync();
    Task<IEnumerable<Customer>> SearchAsync(string keyword);
    Task<int> CreateAsync(string customerName, string? phoneNumber, string? address);
    Task UpdateAsync(int id, string customerName, string? phoneNumber, string? address);
    Task DeleteAsync(int id);
}