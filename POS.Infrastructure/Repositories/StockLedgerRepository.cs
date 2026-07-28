using Dapper;
using POS.Domain.Entities;
using POS.Domain.Interfaces;
using POS.Infrastructure.Data;

namespace POS.Infrastructure.Repositories;

public class StockLedgerRepository : IStockLedgerRepository
{
    private readonly IDbConnectionFactory _factory;
    public StockLedgerRepository(IDbConnectionFactory factory) => _factory = factory;

    // Dipakai ulang oleh Purchase/Sales/Opname repo agar penulisan ledger satu tempat.
    // Selalu dijalankan di dalam transaksi milik repo tersebut (parameter tx).
    public const string InsertSql = @"
        INSERT INTO stock_ledger
            (product_id, movement_type, quantity_change, stock_before, stock_after,
             reference_type, reference_id, notes)
        VALUES
            (@ProductId, @MovementType, @QuantityChange, @StockBefore, @StockAfter,
             @ReferenceType, @ReferenceId, @Notes);";

    private const string SelectColumns = @"
        l.ledger_id        AS LedgerId,
        l.product_id       AS ProductId,
        l.movement_type    AS MovementType,
        l.quantity_change  AS QuantityChange,
        l.stock_before     AS StockBefore,
        l.stock_after      AS StockAfter,
        l.reference_type   AS ReferenceType,
        l.reference_id     AS ReferenceId,
        l.notes            AS Notes,
        l.created_at       AS CreatedAt,
        p.product_name     AS ProductName";

    public async Task<IEnumerable<StockLedgerEntry>> GetAllAsync()
    {
        using var conn = _factory.CreateConnection();
        return await conn.QueryAsync<StockLedgerEntry>($@"
            SELECT {SelectColumns}
            FROM stock_ledger l
            LEFT JOIN products p ON p.product_id = l.product_id
            ORDER BY l.created_at DESC, l.ledger_id DESC;");
    }

    public async Task<IEnumerable<StockLedgerEntry>> GetByProductAsync(int productId)
    {
        using var conn = _factory.CreateConnection();
        return await conn.QueryAsync<StockLedgerEntry>($@"
            SELECT {SelectColumns}
            FROM stock_ledger l
            LEFT JOIN products p ON p.product_id = l.product_id
            WHERE l.product_id = @ProductId
            ORDER BY l.created_at DESC, l.ledger_id DESC;", new { ProductId = productId });
    }

    public async Task<IEnumerable<StockLedgerEntry>> GetByDateRangeAsync(DateTime from, DateTime to)
    {
        using var conn = _factory.CreateConnection();
        return await conn.QueryAsync<StockLedgerEntry>($@"
            SELECT {SelectColumns}
            FROM stock_ledger l
            LEFT JOIN products p ON p.product_id = l.product_id
            WHERE l.created_at >= @From AND l.created_at < @To
            ORDER BY l.created_at DESC, l.ledger_id DESC;",
            new { From = from, To = to });
    }
}
