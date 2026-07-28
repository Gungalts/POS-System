using Dapper;
using POS.Domain.Entities;
using POS.Domain.Interfaces;
using POS.Infrastructure.Data;

namespace POS.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly IDbConnectionFactory _factory;
    public UserRepository(IDbConnectionFactory factory) => _factory = factory;

    private const string SelectColumns = @"
        user_id       AS UserId,
        username      AS Username,
        password_hash AS PasswordHash,
        role          AS Role,
        full_name     AS FullName";

    public async Task<UserAccount?> GetByIdAsync(int id)
    {
        using var conn = _factory.CreateConnection();
        return await conn.QuerySingleOrDefaultAsync<UserAccount>(
            $"SELECT {SelectColumns} FROM users WHERE user_id = @Id;", new { Id = id });
    }

    public async Task<UserAccount?> GetByUsernameAsync(string username)
    {
        using var conn = _factory.CreateConnection();
        return await conn.QuerySingleOrDefaultAsync<UserAccount>(
            $"SELECT {SelectColumns} FROM users WHERE username = @Username;",
            new { Username = username });
    }

    public async Task<IEnumerable<UserAccount>> GetAllAsync()
    {
        using var conn = _factory.CreateConnection();
        return await conn.QueryAsync<UserAccount>(
            $"SELECT {SelectColumns} FROM users ORDER BY username;");
    }

    public async Task<int> CountAsync()
    {
        using var conn = _factory.CreateConnection();
        return await conn.ExecuteScalarAsync<int>("SELECT COUNT(*) FROM users;");
    }

    public async Task<int> AddAsync(UserAccount user)
    {
        using var conn = _factory.CreateConnection();
        return await conn.ExecuteScalarAsync<int>(@"
            INSERT INTO users (username, password_hash, role, full_name)
            VALUES (@Username, @PasswordHash, @Role, @FullName);
            SELECT last_insert_rowid();", user);
    }

    public async Task UpdateAsync(UserAccount user)
    {
        using var conn = _factory.CreateConnection();
        await conn.ExecuteAsync(@"
            UPDATE users SET
                username      = @Username,
                password_hash = @PasswordHash,
                role          = @Role,
                full_name     = @FullName,
                updated_at    = CURRENT_TIMESTAMP
            WHERE user_id = @UserId;", user);
    }

    public async Task DeleteAsync(int id)
    {
        using var conn = _factory.CreateConnection();
        await conn.ExecuteAsync("DELETE FROM users WHERE user_id = @Id;", new { Id = id });
    }
}
