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
    public decimal AverageCost { get; set; }
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

    // qty & price dalam SATUAN BELI; dikonversi ke satuan jual memakai ConversionFactor
    // supaya Stock, AverageCost, dan HPP semuanya konsisten dalam satuan jual.
    public void ReceiveStock(int purchaseQty, decimal purchasePrice)
    {
        if (purchaseQty <= 0)
            throw new ArgumentException("Kuantitas Beli Harus Lebih Dari 0");
        if (purchasePrice < 0)
            throw new ArgumentException("Harga Beli Tidak Boleh Negatif");

        int addedSaleQty = ConvertPurchaseToSaleUnit(purchaseQty);   // ke satuan jual
        decimal costPerSaleUnit = purchasePrice / ConversionFactor;  // biaya per satuan jual

        // moving average (HPP berjalan) dalam satuan jual
        AverageCost = (Stock * AverageCost + addedSaleQty * costPerSaleUnit)
                      / (Stock + addedSaleQty);
        Stock += addedSaleQty;
        PurchasePrice = purchasePrice; // referensi harga beli terakhir saja
    }
}
