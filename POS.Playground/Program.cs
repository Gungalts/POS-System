using POS.Application.Requests;
using POS.Application.Services;
using POS.Domain.Entities;
using POS.Domain.Exceptions;
using POS.Infrastructure.Data;
using POS.Infrastructure.Repositories;

// Verifikasi backend transaksi Beli & Jual.
// Pakai DB sementara agar assert deterministik (tidak mengotori pos.db).
const string dbPath = "pos_verify.db";
if (File.Exists(dbPath)) File.Delete(dbPath);

var factory = new SqliteConnectionFactory($"Data Source={dbPath}");
new Migration(factory).Run();

var productRepo = new ProductRepository(factory);
var supplierRepo = new SupplierRepository(factory);
var purchaseRepo = new PurchaseRepository(factory);
var salesRepo = new SalesRepository(factory);
var ledgerRepo = new StockLedgerRepository(factory);
var opnameRepo = new StockOpnameRepository(factory);

var purchaseService = new PurchaseService(purchaseRepo, productRepo);
var salesService = new SalesService(salesRepo, productRepo);
var ledgerService = new StockLedgerService(ledgerRepo);
var opnameService = new StockOpnameService(opnameRepo, productRepo);

int passed = 0, failed = 0;
void Check(string label, bool ok)
{
    Console.WriteLine($"  [{(ok ? "PASS" : "FAIL")}] {label}");
    if (ok) passed++; else failed++;
}

async Task ExpectThrows<TEx>(string label, Func<Task> action) where TEx : Exception
{
    try { await action(); Check(label + " (harus melempar)", false); }
    catch (TEx) { Check(label, true); }
    catch (Exception ex) { Check($"{label} (malah {ex.GetType().Name})", false); }
}

// --- Skenario 1: seed produk conversion_factor=40, stok awal 0 ---
Console.WriteLine("1. Seed produk (1 DUS = 40 PCS), stok awal 0");
var supplierId = await supplierRepo.AddAsync(new Supplier { SupplierName = "PT Indofood" });
var productId = await productRepo.AddAsync(new Product
{
    Barcode = "8991234567890",
    ProductName = "Indomie Goreng",
    SupplierId = supplierId,
    SaleUnit = "PCS",
    PurchaseUnit = "DUS",
    ConversionFactor = 40,
    SalePrice = 3500,
    PurchasePrice = 0,
    Stock = 0
});

// --- Skenario 2: beli 1 DUS @ 40000 → avg 1000, stok 40 ---
Console.WriteLine("2. Beli 1 DUS @ 40.000");
await purchaseService.CreatePurchaseAsync(supplierId,
    new[] { new PurchaseItemRequest(productId, 1, 40000m) }, initialPayment: 40000, notes: "beli 1");
var p = (await productRepo.GetByIdAsync(productId))!;
Check($"stok = 40 (aktual {p.Stock})", p.Stock == 40);
Check($"average_cost = 1000 (aktual {p.AverageCost})", p.AverageCost == 1000m);

// --- Skenario 3: beli lagi 1 DUS @ 60000 → moving average 1250, stok 80 ---
Console.WriteLine("3. Beli lagi 1 DUS @ 60.000 (moving average)");
await purchaseService.CreatePurchaseAsync(supplierId,
    new[] { new PurchaseItemRequest(productId, 1, 60000m) }, initialPayment: 60000, notes: "beli 2");
p = (await productRepo.GetByIdAsync(productId))!;
// (40*1000 + 40*1500) / 80 = 1250
Check($"stok = 80 (aktual {p.Stock})", p.Stock == 80);
Check($"average_cost = 1250 (aktual {p.AverageCost})", p.AverageCost == 1250m);

// --- Skenario 4: beli dicicil → Sebagian → Lunas, hutang → 0 ---
Console.WriteLine("4. Beli dicicil: Sebagian → Lunas, hutang supplier → 0");
var creditPurchaseId = await purchaseService.CreatePurchaseAsync(supplierId,
    new[] { new PurchaseItemRequest(productId, 1, 50000m) }, initialPayment: 20000, notes: "hutang");
var creditHeader = (await purchaseRepo.GetByIdAsync(creditPurchaseId))!;
Check($"status = Sebagian (aktual {creditHeader.PaymentStatusValue})",
    creditHeader.PaymentStatusValue == PaymentStatus.Sebagian);
var debtBefore = await purchaseService.GetSupplierDebtAsync(supplierId);
Check($"hutang supplier = 30000 (aktual {debtBefore})", debtBefore == 30000);

await purchaseService.AddPaymentAsync(creditPurchaseId, 30000, "pelunasan");
creditHeader = (await purchaseRepo.GetByIdAsync(creditPurchaseId))!;
Check($"status = Lunas (aktual {creditHeader.PaymentStatusValue})",
    creditHeader.PaymentStatusValue == PaymentStatus.Lunas);
var debtAfter = await purchaseService.GetSupplierDebtAsync(supplierId);
Check($"hutang supplier = 0 (aktual {debtAfter})", debtAfter == 0);
var payments = (await purchaseService.GetPaymentsAsync(creditPurchaseId)).ToList();
Check($"jumlah histori pembayaran = 2 (aktual {payments.Count})", payments.Count == 2);

// --- Skenario 5: jual lunas → stok berkurang & COGS = average_cost saat itu ---
Console.WriteLine("5. Jual 10 PCS lunas → stok berkurang & COGS snapshot");
p = (await productRepo.GetByIdAsync(productId))!;
var avgAtSale = p.AverageCost;                 // 1250 (beli @ 50000/DUS = 1250/PCS, sama)
var stockBeforeSale = p.Stock;                 // 120
var saleId = await salesService.CreateSaleAsync(null,
    new[] { new SaleItemRequest(productId, 10) }, "Tunai", amountPaid: 35000);
p = (await productRepo.GetByIdAsync(productId))!;
Check($"stok berkurang 10 (aktual {stockBeforeSale} → {p.Stock})", p.Stock == stockBeforeSale - 10);
var sale = (await salesRepo.GetByIdAsync(saleId))!;
Check($"COGS = {avgAtSale} (aktual {sale.Details[0].CostOfGoodsSold})",
    sale.Details[0].CostOfGoodsSold == avgAtSale);
Check($"average_cost produk tidak berubah (aktual {p.AverageCost})", p.AverageCost == avgAtSale);

// --- Skenario 6: jual kurang bayar → ValidationException ---
Console.WriteLine("6. Jual kurang bayar → ValidationException");
await ExpectThrows<ValidationException>("tolak kurang bayar", () =>
    salesService.CreateSaleAsync(null,
        new[] { new SaleItemRequest(productId, 1) }, "Tunai", amountPaid: 1000));

// --- Skenario 7: jual melebihi stok → InvalidOperationException ---
Console.WriteLine("7. Jual melebihi stok → InvalidOperationException");
await ExpectThrows<InvalidOperationException>("tolak stok kurang", () =>
    salesService.CreateSaleAsync(null,
        new[] { new SaleItemRequest(productId, 99999) }, "Tunai", amountPaid: 999999999));

// --- Skenario 8: stock ledger merekam tiap pergerakan ---
Console.WriteLine("8. Stock Ledger merekam pergerakan beli & jual");
var ledger = (await ledgerService.GetByProductAsync(productId)).ToList();
// 3x beli (+40 masing-masing) + 1x jual (-10) = 4 baris
Check($"jumlah baris ledger = 4 (aktual {ledger.Count})", ledger.Count == 4);
var beliEntries = ledger.Where(l => l.MovementType == MovementType.Pembelian).ToList();
Check($"ada 3 baris Pembelian +40 (aktual {beliEntries.Count})",
    beliEntries.Count == 3 && beliEntries.All(l => l.QuantityChange == 40));
var jualEntry = ledger.FirstOrDefault(l => l.MovementType == MovementType.Penjualan);
Check("baris Penjualan quantity_change = -10", jualEntry is { QuantityChange: -10 });
Check($"baris Penjualan stock_before 120 → after 110 (aktual {jualEntry?.StockBefore} → {jualEntry?.StockAfter})",
    jualEntry is { StockBefore: 120, StockAfter: 110 });

// --- Skenario 9: stock opname menyesuaikan stok + catat ledger ---
Console.WriteLine("9. Stock Opname (fisik 100 < sistem 110)");
p = (await productRepo.GetByIdAsync(productId))!;  // stok 110
var opnameId = await opnameService.CreateOpnameAsync("opname bulanan",
    new[] { new OpnameLineRequest(productId, 100) });
p = (await productRepo.GetByIdAsync(productId))!;
Check($"stok tersesuaikan ke 100 (aktual {p.Stock})", p.Stock == 100);
var opname = (await opnameService.GetByIdAsync(opnameId))!;
Check($"detail opname tersimpan: selisih -10 (aktual {opname.Details.FirstOrDefault()?.Difference})",
    opname.Details.Count == 1 && opname.Details[0].Difference == -10);
var opnameLedger = (await ledgerService.GetByProductAsync(productId))
    .FirstOrDefault(l => l.MovementType == MovementType.Opname);
Check("ada baris ledger Opname quantity_change = -10", opnameLedger is { QuantityChange: -10 });
Check($"ledger Opname stock_before 110 → after 100 (aktual {opnameLedger?.StockBefore} → {opnameLedger?.StockAfter})",
    opnameLedger is { StockBefore: 110, StockAfter: 100 });

Console.WriteLine();
Console.WriteLine($"HASIL: {passed} PASS, {failed} FAIL");
Environment.Exit(failed == 0 ? 0 : 1);
