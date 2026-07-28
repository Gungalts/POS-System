namespace POS.Application.Requests;

// Baris item saat membuat transaksi pembelian (qty & harga dalam satuan beli).
public record PurchaseItemRequest(int ProductId, int Quantity, decimal PurchasePrice);

// Baris item saat membuat transaksi penjualan (qty dalam satuan jual).
public record SaleItemRequest(int ProductId, int Quantity);
