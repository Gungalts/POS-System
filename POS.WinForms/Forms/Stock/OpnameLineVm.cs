namespace POS.WinForms.Forms.Stock;

// View-model baris stock opname (lokal WinForms).
public class OpnameLineVm
{
    public int ProductId { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public int SystemStock { get; set; }
    public int PhysicalStock { get; set; }
    public int Difference => PhysicalStock - SystemStock;
}
