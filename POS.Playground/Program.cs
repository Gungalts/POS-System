using POS.Domain.Entities;
using POS.Infrastructure.Data;
using POS.Infrastructure.Repositories;

var factory = new SqliteConnectionFactory("Data Source=pos.db");
new Migration(factory).Run();

var repo = new ProductRepository(factory);

var id = await repo.AddAsync(new Product
{
    Barcode = "8991234567890",
    ProductName = "Indomie Goreng",
    SaleUnit = "PCS",
    PurchaseUnit = "DUS",
    ConversionFactor = 40,
    SalePrice = 3500,
    PurchasePrice = 2800,
    Stock = 120
});
Console.WriteLine($"Inserted id: {id}");

var found = await repo.GetByBarcodeAsync("8991234567890");
Console.WriteLine($"{found!.ProductName} — stok {found.Stock} — Rp{found.SalePrice:N0}");

found.ReduceStock(5);
await repo.UpdateAsync(found);
Console.WriteLine($"Setelah jual 5: {(await repo.GetByIdAsync(id))!.Stock}");