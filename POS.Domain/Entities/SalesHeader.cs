using POS.Domain.Exceptions;

namespace POS.Domain.Entities;

public class SalesHeader
{
    public int SaleId { get; set; }
    public int? CustomerId { get; set; }
    public DateTime SaleDate { get; set; }
    public int GrandTotal { get; set; }
    public string? PaymentMethod { get; set; }
    public int AmountPaid { get; set; }

    // Hanya untuk tampilan (di-AS saat join).
    public string? CustomerName { get; set; }

    public List<SalesDetail> Details { get; set; } = new();

    // Aturan bisnis inti: penjualan harus lunas.
    public void EnsurePaidInFull()
    {
        if (AmountPaid < GrandTotal)
            throw new ValidationException(
                $"Penjualan Harus Lunas. Total : {GrandTotal}, Dibayar : {AmountPaid}");
    }
}
