using POS.Application.Interfaces;
using POS.Application.Security;
using POS.Domain.Entities;
using POS.Domain.Exceptions;
using POS.Domain.Interfaces;

namespace POS.Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _repo;
    public UserService(IUserRepository repo) => _repo = repo;

    public async Task EnsureSeedAdminAsync()
    {
        if (await _repo.CountAsync() > 0) return;

        await _repo.AddAsync(new UserAccount
        {
            Username = "admin",
            PasswordHash = PasswordHasher.Hash("admin"),
            Role = UserRole.Manajer,
            FullName = "Administrator"
        });
    }

    public async Task<UserAccount> LoginAsync(string username, string password)
    {
        username = username?.Trim() ?? string.Empty;
        var user = await _repo.GetByUsernameAsync(username);
        if (user is null || !PasswordHasher.Verify(password ?? string.Empty, user.PasswordHash))
            throw new ValidationException("Username Atau Password Salah");

        return user;
    }

    public Task<IEnumerable<UserAccount>> GetAllAsync() => _repo.GetAllAsync();

    public async Task<int> CreateAsync(string username, string password, string role, string? fullName)
    {
        username = ValidateUsername(username);
        ValidatePassword(password);
        role = ValidateRole(role);
        await EnsureUsernameNotDuplicateAsync(username, excludeId: null);

        return await _repo.AddAsync(new UserAccount
        {
            Username = username,
            PasswordHash = PasswordHasher.Hash(password),
            Role = role,
            FullName = fullName?.Trim()
        });
    }

    public async Task UpdateAsync(int id, string role, string? fullName)
    {
        var existing = await _repo.GetByIdAsync(id)
            ?? throw new EntityNotFoundException($"User dengan id {id} tidak ditemukan");

        role = ValidateRole(role);

        // Jangan biarkan Manajer terakhir diturunkan perannya.
        if (existing.Role == UserRole.Manajer && role != UserRole.Manajer)
            await EnsureNotLastManagerAsync(id);

        existing.Role = role;
        existing.FullName = fullName?.Trim();
        await _repo.UpdateAsync(existing);
    }

    public async Task ChangePasswordAsync(int id, string newPassword)
    {
        var existing = await _repo.GetByIdAsync(id)
            ?? throw new EntityNotFoundException($"User dengan id {id} tidak ditemukan");

        ValidatePassword(newPassword);
        existing.PasswordHash = PasswordHasher.Hash(newPassword);
        await _repo.UpdateAsync(existing);
    }

    public async Task DeleteAsync(int id)
    {
        var existing = await _repo.GetByIdAsync(id)
            ?? throw new EntityNotFoundException($"User dengan id {id} tidak ditemukan");

        if (existing.Role == UserRole.Manajer)
            await EnsureNotLastManagerAsync(id);

        await _repo.DeleteAsync(id);
    }

    private static string ValidateUsername(string username)
    {
        username = username?.Trim() ?? string.Empty;
        if (string.IsNullOrWhiteSpace(username))
            throw new ValidationException("Username Tidak Boleh Kosong");
        if (username.Length < 3)
            throw new ValidationException("Username Minimal 3 Karakter");
        return username;
    }

    private static void ValidatePassword(string password)
    {
        if (string.IsNullOrWhiteSpace(password))
            throw new ValidationException("Password Tidak Boleh Kosong");
        if (password.Length < 4)
            throw new ValidationException("Password Minimal 4 Karakter");
    }

    private static string ValidateRole(string role)
    {
        role = role?.Trim() ?? string.Empty;
        if (!UserRole.IsValid(role))
            throw new ValidationException("Role Tidak Valid");
        return role;
    }

    private async Task EnsureUsernameNotDuplicateAsync(string username, int? excludeId)
    {
        var existing = await _repo.GetByUsernameAsync(username);
        if (existing is not null && existing.UserId != excludeId)
            throw new DuplicateEntityException($"Username '{username}' Sudah Digunakan");
    }

    private async Task EnsureNotLastManagerAsync(int excludeId)
    {
        var managers = (await _repo.GetAllAsync()).Count(u => u.Role == UserRole.Manajer);
        if (managers <= 1)
            throw new ValidationException("Tidak Bisa Menghapus/Menurunkan Manajer Terakhir");
    }
}
