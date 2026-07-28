namespace POS.Domain.Entities;

public class StockOpnameHeader
{
    public int OpnameId { get; set; }
    public DateTime OpnameDate { get; set; }
    public string? Notes { get; set; }

    public List<StockOpnameDetail> Details { get; set; } = new();
}
