namespace POS.Domain.Entities;

public class PurchasePayment
{
    public int PaymentId { get; set; }
    public int PurchaseId { get; set; }
    public int Amount { get; set; }
    public DateTime PaymentDate { get; set; }
    public string? Notes { get; set; }
}
