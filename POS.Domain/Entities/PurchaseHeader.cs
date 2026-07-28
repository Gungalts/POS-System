namespace POS.Domain.Entities;

public class PurchaseHeader
{
    public int PurchaseId { get; set; }
    public int SupplierId { get; set; }
    public DateTime PurchaseDate { get; set; }
    public int GrandTotal { get; set; }
    public string PaymentStatusValue { get; set; } = PaymentStatus.BelumLunas;
    public int AmountPaid { get; set; }
    public string? Notes { get; set; }

    // Hanya untuk tampilan (di-AS saat join), tidak dipersist di purchase_header.
    public string? SupplierName { get; set; }

    public List<PurchaseDetail> Details { get; set; } = new();

    public int Remaining => GrandTotal - AmountPaid;

    public void ApplyPayment(int amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Jumlah Pembayaran Harus Lebih Dari 0");
        if (amount > Remaining)
            throw new InvalidOperationException(
                $"Pembayaran Melebihi Sisa Hutang. Sisa : {Remaining}");

        AmountPaid += amount;
        RecalculatePaymentStatus();
    }

    public void RecalculatePaymentStatus()
    {
        PaymentStatusValue = AmountPaid <= 0
            ? PaymentStatus.BelumLunas
            : AmountPaid >= GrandTotal
                ? PaymentStatus.Lunas
                : PaymentStatus.Sebagian;
    }
}
