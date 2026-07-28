namespace POS.Domain.Entities;

// Jenis pergerakan stok (disimpan sebagai teks di kolom movement_type).
public static class MovementType
{
    public const string Pembelian = "Pembelian";
    public const string Penjualan = "Penjualan";
    public const string Opname = "Opname";
}

// Jenis dokumen sumber pergerakan (kolom reference_type).
public static class ReferenceType
{
    public const string Purchase = "Purchase";
    public const string Sale = "Sale";
    public const string Opname = "Opname";
}
