using POS.Domain.Entities;

namespace POS.Domain.Interfaces;

public interface IUserRepository
{
    Task<UserAccount?> GetByIdAsync(int id);
    Task<UserAccount?> GetByUsernameAsync(string username);
    Task<IEnumerable<UserAccount>> GetAllAsync();
    Task<int> CountAsync();
    Task<int> AddAsync(UserAccount user);
    Task UpdateAsync(UserAccount user);
    Task DeleteAsync(int id);
}
