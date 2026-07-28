using Dapper;
using POS.Domain.Entities;
using POS.Domain.Interfaces;
using POS.Domain.Reports;
using POS.Infrastructure.Data;

namespace POS.Infrastructure.Repositories;

public class ReportRepository : IReportRepository
{
    private readonly IDbConnectionFactory _factory;
    public ReportRepository(IDbConnectionFactory factory) => _factory = factory;

    public async Task<SalesSummaryRow> GetSalesSummaryAsync(DateTime from, DateTime to)
    {
        using var conn = _factory.CreateConnection();
        return await conn.QuerySingleAsync<SalesSummaryRow>(@"
            SELECT
                (SELECT COUNT(*) FROM sales_header
                 WHERE sale_date >= @From AND sale_date < @To) AS TransactionCount,
                COALESCE((SELECT SUM(grand_total) FROM sales_header
                 WHERE sale_date >= @From AND sale_date < @To), 0) AS Revenue,
                COALESCE((SELECT SUM(d.cost_of_goods_sold * d.quantity)
                 FROM sales_detail d
                 JOIN sales_header h ON h.sale_id = d.sale_id
                 WHERE h.sale_date >= @From AND h.sale_date < @To), 0) AS Cogs;",
            new { From = from, To = to });
    }

    public async Task<IEnumerable<SalesByProductRow>> GetSalesByProductAsync(DateTime from, DateTime to)
    {
        using var conn = _factory.CreateConnection();
        return await conn.QueryAsync<SalesByProductRow>(@"
            SELECT
                p.product_name AS ProductName,
                SUM(d.quantity) AS QtySold,
                SUM(d.subtotal) AS Revenue,
                SUM(d.cost_of_goods_sold * d.quantity) AS Cogs
            FROM sales_detail d
            JOIN sales_header h ON h.sale_id = d.sale_id
            LEFT JOIN products p ON p.product_id = d.product_id
            WHERE h.sale_date >= @From AND h.sale_date < @To
            GROUP BY d.product_id, p.product_name
            ORDER BY Revenue DESC;",
            new { From = from, To = to });
    }

    public async Task<IEnumerable<PurchaseBySupplierRow>> GetPurchaseBySupplierAsync(DateTime from, DateTime to)
    {
        using var conn = _factory.CreateConnection();
        return await conn.QueryAsync<PurchaseBySupplierRow>(@"
            SELECT
                s.supplier_name AS SupplierName,
                COUNT(*) AS PurchaseCount,
                COALESCE(SUM(h.grand_total), 0) AS TotalPurchase,
                COALESCE(SUM(h.amount_paid), 0) AS TotalPaid
            FROM purchase_header h
            LEFT JOIN suppliers s ON s.supplier_id = h.supplier_id
            WHERE h.purchase_date >= @From AND h.purchase_date < @To
            GROUP BY h.supplier_id, s.supplier_name
            ORDER BY TotalPurchase DESC;",
            new { From = from, To = to });
    }

    public async Task<IEnumerable<SupplierDebtRow>> GetSupplierDebtAsync()
    {
        using var conn = _factory.CreateConnection();
        return await conn.QueryAsync<SupplierDebtRow>(@"
            SELECT
                s.supplier_name AS SupplierName,
                COALESCE(SUM(h.grand_total - h.amount_paid), 0) AS Outstanding
            FROM purchase_header h
            LEFT JOIN suppliers s ON s.supplier_id = h.supplier_id
            WHERE h.payment_status <> @Lunas
            GROUP BY h.supplier_id, s.supplier_name
            HAVING Outstanding > 0
            ORDER BY Outstanding DESC;",
            new { Lunas = PaymentStatus.Lunas });
    }

    public async Task<IEnumerable<InventoryValueRow>> GetInventoryValueAsync()
    {
        using var conn = _factory.CreateConnection();
        return await conn.QueryAsync<InventoryValueRow>(@"
            SELECT
                product_name AS ProductName,
                stock        AS Stock,
                average_cost AS AverageCost
            FROM products
            ORDER BY product_name;");
    }
}
