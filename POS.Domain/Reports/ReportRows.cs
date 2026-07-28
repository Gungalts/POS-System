namespace POS.Domain.Reports;

// Read-model laporan (bukan entity persist). Field money dipetakan dari SUM(...) via Dapper.

public class SalesSummaryRow
{
    public int TransactionCount { get; set; }
    public decimal Revenue { get; set; }   // omzet
    public decimal Cogs { get; set; }       // HPP
    public decimal GrossProfit => Revenue - Cogs;
}

public class SalesByProductRow
{
    public string ProductName { get; set; } = string.Empty;
    public int QtySold { get; set; }
    public decimal Revenue { get; set; }
    public decimal Cogs { get; set; }
    public decimal GrossProfit => Revenue - Cogs;
}

public class PurchaseBySupplierRow
{
    public string SupplierName { get; set; } = string.Empty;
    public int PurchaseCount { get; set; }
    public decimal TotalPurchase { get; set; }
    public decimal TotalPaid { get; set; }
    public decimal Outstanding => TotalPurchase - TotalPaid;
}

public class SupplierDebtRow
{
    public string SupplierName { get; set; } = string.Empty;
    public decimal Outstanding { get; set; }
}

public class InventoryValueRow
{
    public string ProductName { get; set; } = string.Empty;
    public int Stock { get; set; }
    public decimal AverageCost { get; set; }
    public decimal Value => Stock * AverageCost;
}
