using Dapper;
using POS.Domain.Entities;
using POS.Domain.Interfaces;
using POS.Infrastructure.Data;

namespace POS.Infrastructure.Repositories;

public class StockOpnameRepository : IStockOpnameRepository
{
    private readonly IDbConnectionFactory _factory;
    public StockOpnameRepository(IDbConnectionFactory factory) => _factory = factory;

    private const string HeaderColumns = @"
        opname_id   AS OpnameId,
        opname_date AS OpnameDate,
        notes       AS Notes";

    public async Task<int> CreateAsync(StockOpnameHeader header, IReadOnlyList<Product> updatedProducts,
        IReadOnlyList<StockLedgerEntry> ledgerEntries)
    {
        using var conn = _factory.CreateConnection();
        using var tx = conn.BeginTransaction();
        try
        {
            var opnameId = await conn.ExecuteScalarAsync<int>(@"
                INSERT INTO stock_opname_header (notes)
                VALUES (@Notes);
                SELECT last_insert_rowid();", header, tx);

            foreach (var d in header.Details)
            {
                d.OpnameId = opnameId;
                await conn.ExecuteAsync(@"
                    INSERT INTO stock_opname_detail
                        (opname_id, product_id, system_stock, physical_stock, difference)
                    VALUES
                        (@OpnameId, @ProductId, @SystemStock, @PhysicalStock, @Difference);", d, tx);
            }

            foreach (var p in updatedProducts)
                await conn.ExecuteAsync(@"
                    UPDATE products SET
                        stock      = @Stock,
                        updated_at = CURRENT_TIMESTAMP
                    WHERE product_id = @ProductId;", p, tx);

            foreach (var entry in ledgerEntries)
            {
                entry.ReferenceId = opnameId;
                await conn.ExecuteAsync(StockLedgerRepository.InsertSql, entry, tx);
            }

            tx.Commit();
            return opnameId;
        }
        catch
        {
            tx.Rollback();
            throw;
        }
    }

    public async Task<StockOpnameHeader?> GetByIdAsync(int id)
    {
        using var conn = _factory.CreateConnection();
        var header = await conn.QuerySingleOrDefaultAsync<StockOpnameHeader>(
            $"SELECT {HeaderColumns} FROM stock_opname_header WHERE opname_id = @Id;",
            new { Id = id });
        if (header is null) return null;

        var details = await conn.QueryAsync<StockOpnameDetail>(@"
            SELECT
                d.opname_detail_id AS OpnameDetailId,
                d.opname_id        AS OpnameId,
                d.product_id       AS ProductId,
                d.system_stock     AS SystemStock,
                d.physical_stock   AS PhysicalStock,
                d.difference       AS Difference,
                p.product_name     AS ProductName
            FROM stock_opname_detail d
            LEFT JOIN products p ON p.product_id = d.product_id
            WHERE d.opname_id = @Id;", new { Id = id });

        header.Details = details.ToList();
        return header;
    }

    public async Task<IEnumerable<StockOpnameHeader>> GetAllAsync()
    {
        using var conn = _factory.CreateConnection();
        return await conn.QueryAsync<StockOpnameHeader>(
            $"SELECT {HeaderColumns} FROM stock_opname_header ORDER BY opname_date DESC;");
    }
}
