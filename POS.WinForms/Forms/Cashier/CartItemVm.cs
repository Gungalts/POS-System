namespace POS.WinForms.Forms.Cashier;

// View-model baris keranjang kasir (lokal WinForms, bukan entity Domain).
public class CartItemVm
{
    public int ProductId { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public int SalePrice { get; set; }
    public int Quantity { get; set; }
    public int Subtotal => SalePrice * Quantity;
}
