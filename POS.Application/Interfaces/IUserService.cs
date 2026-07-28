using POS.Domain.Entities;

namespace POS.Application.Interfaces;

public interface IUserService
{
    // Membuat akun Manajer default (admin/admin) bila belum ada user sama sekali.
    Task EnsureSeedAdminAsync();

    // Mengembalikan user bila kredensial benar; melempar ValidationException bila salah.
    Task<UserAccount> LoginAsync(string username, string password);

    Task<IEnumerable<UserAccount>> GetAllAsync();
    Task<int> CreateAsync(string username, string password, string role, string? fullName);
    Task UpdateAsync(int id, string role, string? fullName);
    Task ChangePasswordAsync(int id, string newPassword);
    Task DeleteAsync(int id);
}
