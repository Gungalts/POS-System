namespace POS.Domain.Entities;

public class PurchaseDetail
{
    public int PurchaseDetailId { get; set; }
    public int PurchaseId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }       // satuan beli
    public int PurchasePrice { get; set; }  // per satuan beli
    public int Subtotal { get; set; }

    // Hanya untuk tampilan (di-AS saat join).
    public string? ProductName { get; set; }
}
