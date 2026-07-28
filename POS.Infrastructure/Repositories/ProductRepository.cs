using Dapper;
using POS.Domain.Entities;
using POS.Domain.Interfaces;
using POS.Infrastructure.Data;

namespace POS.Infrastructure.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly IDbConnectionFactory _factory;
    public ProductRepository(IDbConnectionFactory factory) => _factory = factory;

    private const string SelectColumns = @"
        product_id          AS ProductId,
        barcode             AS Barcode,
        product_name        AS ProductName,
        category_id         AS CategoryId,
        supplier_id         AS SupplierId,
        sale_unit           AS SaleUnit,
        purchase_unit       AS PurchaseUnit,
        conversion_factor   AS ConversionFactor,
        sale_price          AS SalePrice,
        purchase_price      AS PurchasePrice,
        average_cost        AS AverageCost,
        stock               AS Stock";

    public async Task<Product?> GetByIdAsync(int id)
    {
        using var conn = _factory.CreateConnection();
        return await conn.QuerySingleOrDefaultAsync<Product>(
            $"SELECT {SelectColumns} FROM products WHERE product_id = @Id;",
            new { Id = id });
    }

    public async Task<Product?> GetByBarcodeAsync(string barcode)
    {
        using var conn = _factory.CreateConnection();
        return await conn.QuerySingleOrDefaultAsync<Product>(
            $"SELECT {SelectColumns} FROM products WHERE barcode = @Barcode;",
            new { Barcode = barcode });
    }

    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        using var conn = _factory.CreateConnection();
        return await conn.QueryAsync<Product>(
            $"SELECT {SelectColumns} FROM products ORDER BY product_name;");
    }

    public async Task<IEnumerable<Product>> SearchAsync(string keyword)
    {
        using var conn = _factory.CreateConnection();
        return await conn.QueryAsync<Product>(
            $@"SELECT {SelectColumns} FROM products
               WHERE product_name LIKE @Kw OR barcode LIKE @Kw
               ORDER BY product_name;",
            new { Kw = $"%{keyword}%" });
    }

    public async Task<int> AddAsync(Product p)
    {
        using var conn = _factory.CreateConnection();
        return await conn.ExecuteScalarAsync<int>(@"
            INSERT INTO products
                (barcode, product_name, category_id, supplier_id, sale_unit,
                 purchase_unit, conversion_factor, sale_price, purchase_price, average_cost, stock)
            VALUES
                (@Barcode, @ProductName, @CategoryId, @SupplierId, @SaleUnit,
                 @PurchaseUnit, @ConversionFactor, @SalePrice, @PurchasePrice, @AverageCost, @Stock);
            SELECT last_insert_rowid();", p);
    }

    public async Task UpdateAsync(Product p)
    {
        using var conn = _factory.CreateConnection();
        await conn.ExecuteAsync(@"
            UPDATE products SET
                barcode           = @Barcode,
                product_name      = @ProductName,
                category_id       = @CategoryId,
                supplier_id       = @SupplierId,
                sale_unit         = @SaleUnit,
                purchase_unit     = @PurchaseUnit,
                conversion_factor = @ConversionFactor,
                sale_price        = @SalePrice,
                purchase_price    = @PurchasePrice,
                average_cost      = @AverageCost,
                stock             = @Stock,
                updated_at        = CURRENT_TIMESTAMP
            WHERE product_id = @ProductId;", p);
    }

    public async Task DeleteAsync(int id)
    {
        using var conn = _factory.CreateConnection();
        await conn.ExecuteAsync(
            "DELETE FROM products WHERE product_id = @Id;", new { Id = id });
    }
}
