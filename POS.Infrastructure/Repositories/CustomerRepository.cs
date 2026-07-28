using Dapper;
using POS.Domain.Entities;
using POS.Domain.Interfaces;
using POS.Infrastructure.Data;

namespace POS.Infrastructure.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private readonly IDbConnectionFactory _factory;
    public CustomerRepository(IDbConnectionFactory factory) => _factory = factory;

    private const string SelectColumns = @"
        customer_id   AS CustomerId,
        customer_name AS CustomerName,
        phone_number  AS PhoneNumber,
        address       AS Address";

    public async Task<Customer?> GetByIdAsync(int id)
    {
        using var conn = _factory.CreateConnection();
        return await conn.QuerySingleOrDefaultAsync<Customer>(
            $"SELECT {SelectColumns} FROM customers WHERE customer_id = @Id;",
            new { Id = id });
    }

    public async Task<IEnumerable<Customer>> GetAllAsync()
    {
        using var conn = _factory.CreateConnection();
        return await conn.QueryAsync<Customer>(
            $"SELECT {SelectColumns} FROM customers ORDER BY customer_name;");
    }

    public async Task<IEnumerable<Customer>> SearchAsync(string keyword)
    {
        using var conn = _factory.CreateConnection();
        return await conn.QueryAsync<Customer>(
            $@"SELECT {SelectColumns} FROM customers
               WHERE customer_name LIKE @Kw OR phone_number LIKE @Kw
               ORDER BY customer_name;",
            new { Kw = $"%{keyword}%" });
    }

    public async Task<int> AddAsync(Customer c)
    {
        using var conn = _factory.CreateConnection();
        return await conn.ExecuteScalarAsync<int>(@"
            INSERT INTO customers (customer_name, phone_number, address)
            VALUES (@CustomerName, @PhoneNumber, @Address);
            SELECT last_insert_rowid();", c);
    }

    public async Task UpdateAsync(Customer c)
    {
        using var conn = _factory.CreateConnection();
        await conn.ExecuteAsync(@"
            UPDATE customers SET
                customer_name = @CustomerName,
                phone_number  = @PhoneNumber,
                address       = @Address,
                updated_at    = CURRENT_TIMESTAMP
            WHERE customer_id = @CustomerId;", c);
    }

    public async Task DeleteAsync(int id)
    {
        using var conn = _factory.CreateConnection();
        await conn.ExecuteAsync(
            "DELETE FROM customers WHERE customer_id = @Id;", new { Id = id });
    }
}