using Dapper;
using POS.Domain.Entities;
using POS.Domain.Interfaces;
using POS.Infrastructure.Data;

namespace POS.Infrastructure.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly IDbConnectionFactory _factory;
    public CategoryRepository(IDbConnectionFactory factory) => _factory = factory;

    private const string SelectColumns = @"
        category_id   AS CategoryId,
        category_name AS CategoryName";

    public async Task<Category?> GetByIdAsync(int id)
    {
        using var conn = _factory.CreateConnection();
        return await conn.QuerySingleOrDefaultAsync<Category>(
            $"SELECT {SelectColumns} FROM category WHERE category_id = @Id;",
            new { Id = id });
    }

    public async Task<IEnumerable<Category>> GetAllAsync()
    {
        using var conn = _factory.CreateConnection();
        return await conn.QueryAsync<Category>(
            $"SELECT {SelectColumns} FROM category ORDER BY category_name;");
    }

    public async Task<int> AddAsync(Category c)
    {
        using var conn = _factory.CreateConnection();
        return await conn.ExecuteScalarAsync<int>(@"
            INSERT INTO category (category_name)
            VALUES (@CategoryName);
            SELECT last_insert_rowid();", c);
    }

    public async Task UpdateAsync(Category c)
    {
        using var conn = _factory.CreateConnection();
        await conn.ExecuteAsync(@"
            UPDATE category SET
                category_name = @CategoryName,
                updated_at    = CURRENT_TIMESTAMP
            WHERE category_id = @CategoryId;", c);
    }

    public async Task DeleteAsync(int id)
    {
        using var conn = _factory.CreateConnection();
        await conn.ExecuteAsync(
            "DELETE FROM category WHERE category_id = @Id;", new { Id = id });
    }
}
