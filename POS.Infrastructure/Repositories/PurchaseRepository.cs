using Dapper;
using POS.Domain.Entities;
using POS.Domain.Interfaces;
using POS.Infrastructure.Data;

namespace POS.Infrastructure.Repositories;

public class PurchaseRepository : IPurchaseRepository
{
    private readonly IDbConnectionFactory _factory;
    public PurchaseRepository(IDbConnectionFactory factory) => _factory = factory;

    private const string HeaderColumns = @"
        purchase_id     AS PurchaseId,
        supplier_id     AS SupplierId,
        purchase_date   AS PurchaseDate,
        grand_total     AS GrandTotal,
        payment_status  AS PaymentStatusValue,
        amount_paid     AS AmountPaid,
        notes           AS Notes";

    public async Task<int> CreateAsync(PurchaseHeader header, IReadOnlyList<Product> updatedProducts)
    {
        using var conn = _factory.CreateConnection();
        using var tx = conn.BeginTransaction();
        try
        {
            var purchaseId = await conn.ExecuteScalarAsync<int>(@"
                INSERT INTO purchase_header
                    (supplier_id, grand_total, payment_status, amount_paid, notes)
                VALUES
                    (@SupplierId, @GrandTotal, @PaymentStatusValue, @AmountPaid, @Notes);
                SELECT last_insert_rowid();", header, tx);

            foreach (var d in header.Details)
            {
                d.PurchaseId = purchaseId;
                await conn.ExecuteAsync(@"
                    INSERT INTO purchase_detail
                        (purchase_id, product_id, quantity, purchase_price, subtotal)
                    VALUES
                        (@PurchaseId, @ProductId, @Quantity, @PurchasePrice, @Subtotal);", d, tx);
            }

            // Catat pembayaran awal sebagai baris histori supaya purchase_payments
            // tetap menjadi sumber kebenaran (total payment == amount_paid).
            if (header.AmountPaid > 0)
                await conn.ExecuteAsync(@"
                    INSERT INTO purchase_payments (purchase_id, amount, notes)
                    VALUES (@PurchaseId, @Amount, @Notes);",
                    new { PurchaseId = purchaseId, Amount = header.AmountPaid, Notes = "Pembayaran awal" }, tx);

            foreach (var p in updatedProducts)
                await conn.ExecuteAsync(@"
                    UPDATE products SET
                        stock          = @Stock,
                        average_cost   = @AverageCost,
                        purchase_price = @PurchasePrice,
                        updated_at     = CURRENT_TIMESTAMP
                    WHERE product_id = @ProductId;", p, tx);

            tx.Commit();
            return purchaseId;
        }
        catch
        {
            tx.Rollback();
            throw;
        }
    }

    public async Task<PurchaseHeader?> GetByIdAsync(int id)
    {
        using var conn = _factory.CreateConnection();
        var header = await conn.QuerySingleOrDefaultAsync<PurchaseHeader>(
            $"SELECT {HeaderColumns} FROM purchase_header WHERE purchase_id = @Id;",
            new { Id = id });
        if (header is null) return null;

        var details = await conn.QueryAsync<PurchaseDetail>(@"
            SELECT
                d.purchase_detail_id AS PurchaseDetailId,
                d.purchase_id        AS PurchaseId,
                d.product_id         AS ProductId,
                d.quantity           AS Quantity,
                d.purchase_price     AS PurchasePrice,
                d.subtotal           AS Subtotal,
                p.product_name       AS ProductName
            FROM purchase_detail d
            LEFT JOIN products p ON p.product_id = d.product_id
            WHERE d.purchase_id = @Id;", new { Id = id });

        header.Details = details.ToList();
        return header;
    }

    public async Task<IEnumerable<PurchaseHeader>> GetAllAsync()
    {
        using var conn = _factory.CreateConnection();
        return await conn.QueryAsync<PurchaseHeader>($@"
            SELECT {HeaderColumns},
                   s.supplier_name AS SupplierName
            FROM purchase_header h
            LEFT JOIN suppliers s ON s.supplier_id = h.supplier_id
            ORDER BY h.purchase_date DESC;");
    }

    public async Task<IEnumerable<PurchaseHeader>> GetUnpaidBySupplierAsync(int supplierId)
    {
        using var conn = _factory.CreateConnection();
        return await conn.QueryAsync<PurchaseHeader>($@"
            SELECT {HeaderColumns} FROM purchase_header
            WHERE supplier_id = @SupplierId AND payment_status <> @Lunas
            ORDER BY purchase_date;",
            new { SupplierId = supplierId, Lunas = PaymentStatus.Lunas });
    }

    public async Task AddPaymentAsync(PurchasePayment payment, PurchaseHeader updatedHeader)
    {
        using var conn = _factory.CreateConnection();
        using var tx = conn.BeginTransaction();
        try
        {
            await conn.ExecuteAsync(@"
                INSERT INTO purchase_payments (purchase_id, amount, notes)
                VALUES (@PurchaseId, @Amount, @Notes);", payment, tx);

            await conn.ExecuteAsync(@"
                UPDATE purchase_header SET
                    amount_paid    = @AmountPaid,
                    payment_status = @PaymentStatusValue,
                    updated_at     = CURRENT_TIMESTAMP
                WHERE purchase_id = @PurchaseId;", updatedHeader, tx);

            tx.Commit();
        }
        catch
        {
            tx.Rollback();
            throw;
        }
    }

    public async Task<IEnumerable<PurchasePayment>> GetPaymentsAsync(int purchaseId)
    {
        using var conn = _factory.CreateConnection();
        return await conn.QueryAsync<PurchasePayment>(@"
            SELECT
                payment_id   AS PaymentId,
                purchase_id  AS PurchaseId,
                amount       AS Amount,
                payment_date AS PaymentDate,
                notes        AS Notes
            FROM purchase_payments
            WHERE purchase_id = @PurchaseId
            ORDER BY payment_date;", new { PurchaseId = purchaseId });
    }
}
