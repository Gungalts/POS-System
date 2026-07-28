namespace POS.Domain.Entities;

public class StockLedgerEntry
{
    public int LedgerId { get; set; }
    public int ProductId { get; set; }
    public string MovementType { get; set; } = string.Empty;
    public int QuantityChange { get; set; }   // + masuk / − keluar (satuan jual)
    public int StockBefore { get; set; }
    public int StockAfter { get; set; }
    public string? ReferenceType { get; set; }
    public int? ReferenceId { get; set; }
    public string? Notes { get; set; }
    public DateTime CreatedAt { get; set; }

    // Hanya untuk tampilan (di-AS saat join).
    public string? ProductName { get; set; }
}
