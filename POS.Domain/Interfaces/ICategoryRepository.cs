using POS.Domain.Entities;

namespace POS.Domain.Interfaces;

public interface ICategoryRepository
{
    Task<Category?> GetByIdAsync(int id);
    Task<IEnumerable<Category>> GetAllAsync();
    Task<int> AddAsync(Category category);
    Task UpdateAsync(Category category);
    Task DeleteAsync(int id);
}
