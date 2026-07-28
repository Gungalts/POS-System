namespace POS.Domain.Entities;

public class SalesDetail
{
    public int SaleDetailId { get; set; }
    public int SaleId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }               // satuan jual
    public int SalePrice { get; set; }              // per satuan jual saat transaksi
    public decimal CostOfGoodsSold { get; set; }    // HPP snapshot per satuan jual
    public int Subtotal { get; set; }

    // Hanya untuk tampilan (di-AS saat join).
    public string? ProductName { get; set; }
}
