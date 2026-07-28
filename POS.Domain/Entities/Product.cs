namespace POS.Domain.Entities;

public class Product
{
    public int ProductId { get; set; }
    public string Barcode { get; set; } = string.Empty;
    public string ProductName { get; set; } = string.Empty;
    public int? CategoryId { get; set; }
    public int? SupplierId { get; set; }
    public string SaleUnit { get; set; } = "PCS";
    public string PurchaseUnit { get; set; } = "PCS";
    public int ConversionFactor { get; set; } = 1;
    public decimal SalePrice { get; set; }
    public decimal PurchasePrice { get; set; }
    public int Stock { get; set; }

    public bool IsStockSufficient(int qty) => Stock >= qty;

    public void ReduceStock(int qty)
    {
        if (qty <= 0)
            throw new ArgumentException("Kuantitas Harus Lebih Dari 0");
        if (!IsStockSufficient(qty))
            throw new InvalidOperationException(
                $"Stok {ProductName} Tidak Cukup. Stok Tersedia : {Stock}");
        Stock -= qty;
    }

    public int ConvertPurchaseToSaleUnit(int purchaseQty)
        => purchaseQty * ConversionFactor;
}
