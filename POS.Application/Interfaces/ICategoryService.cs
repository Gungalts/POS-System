using POS.Domain.Entities;

namespace POS.Application.Interfaces;

public interface ICategoryService
{
    Task<Category?> GetByIdAsync(int id);
    Task<IEnumerable<Category>> GetAllAsync();
    Task<int> CreateAsync(string categoryName);
    Task UpdateAsync(int id, string categoryName);
    Task DeleteAsync(int id);
}