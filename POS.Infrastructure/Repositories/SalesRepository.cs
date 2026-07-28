using Dapper;
using POS.Domain.Entities;
using POS.Domain.Interfaces;
using POS.Infrastructure.Data;

namespace POS.Infrastructure.Repositories;

public class SalesRepository : ISalesRepository
{
    private readonly IDbConnectionFactory _factory;
    public SalesRepository(IDbConnectionFactory factory) => _factory = factory;

    private const string HeaderColumns = @"
        sale_id        AS SaleId,
        customer_id    AS CustomerId,
        sale_date      AS SaleDate,
        grand_total    AS GrandTotal,
        payment_method AS PaymentMethod,
        amount_paid    AS AmountPaid";

    public async Task<int> CreateAsync(SalesHeader header, IReadOnlyList<Product> updatedProducts,
        IReadOnlyList<StockLedgerEntry> ledgerEntries)
    {
        using var conn = _factory.CreateConnection();
        using var tx = conn.BeginTransaction();
        try
        {
            var saleId = await conn.ExecuteScalarAsync<int>(@"
                INSERT INTO sales_header
                    (customer_id, grand_total, payment_method, amount_paid)
                VALUES
                    (@CustomerId, @GrandTotal, @PaymentMethod, @AmountPaid);
                SELECT last_insert_rowid();", header, tx);

            foreach (var d in header.Details)
            {
                d.SaleId = saleId;
                await conn.ExecuteAsync(@"
                    INSERT INTO sales_detail
                        (sale_id, product_id, quantity, sale_price, cost_of_goods_sold, subtotal)
                    VALUES
                        (@SaleId, @ProductId, @Quantity, @SalePrice, @CostOfGoodsSold, @Subtotal);", d, tx);
            }

            // Penjualan tidak mengubah average_cost — hanya mengurangi stok.
            foreach (var p in updatedProducts)
                await conn.ExecuteAsync(@"
                    UPDATE products SET
                        stock      = @Stock,
                        updated_at = CURRENT_TIMESTAMP
                    WHERE product_id = @ProductId;", p, tx);

            foreach (var entry in ledgerEntries)
            {
                entry.ReferenceId = saleId;
                await conn.ExecuteAsync(StockLedgerRepository.InsertSql, entry, tx);
            }

            tx.Commit();
            return saleId;
        }
        catch
        {
            tx.Rollback();
            throw;
        }
    }

    public async Task<SalesHeader?> GetByIdAsync(int id)
    {
        using var conn = _factory.CreateConnection();
        var header = await conn.QuerySingleOrDefaultAsync<SalesHeader>(
            $"SELECT {HeaderColumns} FROM sales_header WHERE sale_id = @Id;",
            new { Id = id });
        if (header is null) return null;

        var details = await conn.QueryAsync<SalesDetail>(@"
            SELECT
                d.sale_detail_id      AS SaleDetailId,
                d.sale_id             AS SaleId,
                d.product_id          AS ProductId,
                d.quantity            AS Quantity,
                d.sale_price          AS SalePrice,
                d.cost_of_goods_sold  AS CostOfGoodsSold,
                d.subtotal            AS Subtotal,
                p.product_name        AS ProductName
            FROM sales_detail d
            LEFT JOIN products p ON p.product_id = d.product_id
            WHERE d.sale_id = @Id;", new { Id = id });

        header.Details = details.ToList();
        return header;
    }

    public async Task<IEnumerable<SalesHeader>> GetAllAsync()
    {
        using var conn = _factory.CreateConnection();
        return await conn.QueryAsync<SalesHeader>($@"
            SELECT {HeaderColumns},
                   c.customer_name AS CustomerName
            FROM sales_header h
            LEFT JOIN customers c ON c.customer_id = h.customer_id
            ORDER BY h.sale_date DESC;");
    }
}
