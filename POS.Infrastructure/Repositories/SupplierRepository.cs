using Dapper;
using POS.Domain.Entities;
using POS.Domain.Interfaces;
using POS.Infrastructure.Data;

namespace POS.Infrastructure.Repositories;

public class SupplierRepository : ISupplierRepository
{
    private readonly IDbConnectionFactory _factory;
    public SupplierRepository(IDbConnectionFactory factory) => _factory = factory;

    private const string SelectColumns = @"
        supplier_id   AS SupplierId,
        supplier_name AS SupplierName,
        phone_number  AS PhoneNumber";

    public async Task<Supplier?> GetByIdAsync(int id)
    {
        using var conn = _factory.CreateConnection();
        return await conn.QuerySingleOrDefaultAsync<Supplier>(
            $"SELECT {SelectColumns} FROM suppliers WHERE supplier_id = @Id;",
            new { Id = id });
    }

    public async Task<IEnumerable<Supplier>> GetAllAsync()
    {
        using var conn = _factory.CreateConnection();
        return await conn.QueryAsync<Supplier>(
            $"SELECT {SelectColumns} FROM suppliers ORDER BY supplier_name;");
    }

    public async Task<IEnumerable<Supplier>> SearchAsync(string keyword)
    {
        using var conn = _factory.CreateConnection();
        return await conn.QueryAsync<Supplier>(
            $@"SELECT {SelectColumns} FROM suppliers
               WHERE supplier_name LIKE @Kw OR phone_number LIKE @Kw
               ORDER BY supplier_name;",
            new { Kw = $"%{keyword}%" });
    }

    public async Task<int> AddAsync(Supplier s)
    {
        using var conn = _factory.CreateConnection();
        return await conn.ExecuteScalarAsync<int>(@"
            INSERT INTO suppliers (supplier_name, phone_number)
            VALUES (@SupplierName, @PhoneNumber);
            SELECT last_insert_rowid();", s);
    }

    public async Task UpdateAsync(Supplier s)
    {
        using var conn = _factory.CreateConnection();
        await conn.ExecuteAsync(@"
            UPDATE suppliers SET
                supplier_name = @SupplierName,
                phone_number  = @PhoneNumber,
                updated_at    = CURRENT_TIMESTAMP
            WHERE supplier_id = @SupplierId;", s);
    }

    public async Task DeleteAsync(int id)
    {
        using var conn = _factory.CreateConnection();
        await conn.ExecuteAsync(
            "DELETE FROM suppliers WHERE supplier_id = @Id;", new { Id = id });
    }
}