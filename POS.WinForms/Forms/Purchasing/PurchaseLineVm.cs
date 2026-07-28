namespace POS.WinForms.Forms.Purchasing;

// View-model baris pembelian (lokal WinForms). Qty & harga dalam satuan beli.
public class PurchaseLineVm
{
    public int ProductId { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public int PurchasePrice { get; set; }
    public int Subtotal => Quantity * PurchasePrice;
}
