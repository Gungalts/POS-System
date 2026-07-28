namespace POS.Domain.Entities;

// Status pembayaran pembelian (disimpan sebagai teks di kolom payment_status).
public static class PaymentStatus
{
    public const string BelumLunas = "Belum Lunas";
    public const string Sebagian = "Sebagian";
    public const string Lunas = "Lunas";
}
