namespace POS.Domain.Entities;

public class StockOpnameDetail
{
    public int OpnameDetailId { get; set; }
    public int OpnameId { get; set; }
    public int ProductId { get; set; }
    public int SystemStock { get; set; }
    public int PhysicalStock { get; set; }
    public int Difference { get; set; }   // physical - system

    // Hanya untuk tampilan (di-AS saat join).
    public string? ProductName { get; set; }
}
