using POS.Application.Interfaces;
using POS.Domain.Entities;
using POS.Domain.Exceptions;
using POS.Domain.Interfaces;

namespace POS.Application.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _repo;
    public ProductService(IProductRepository repo) => _repo = repo;

    public Task<Product?> GetByIdAsync(int id) => _repo.GetByIdAsync(id);

    public Task<Product?> GetByBarcodeAsync(string barcode)
        => _repo.GetByBarcodeAsync(barcode?.Trim() ?? string.Empty);

    public Task<IEnumerable<Product>> GetAllAsync() => _repo.GetAllAsync();

    public Task<IEnumerable<Product>> SearchAsync(string keyword)
        => _repo.SearchAsync(keyword?.Trim() ?? string.Empty);

    public async Task<int> CreateAsync(string barcode, string productName, int? categoryId, int? supplierId,
        string saleUnit, string purchaseUnit, int conversionFactor,
        decimal salePrice, decimal purchasePrice, int initialStock)
    {
        barcode = ValidateBarcode(barcode);
        productName = ValidateName(productName);
        ValidateNumbers(conversionFactor, salePrice, purchasePrice, initialStock);
        await EnsureBarcodeNotDuplicateAsync(barcode, excludeId: null);

        return await _repo.AddAsync(new Product
        {
            Barcode = barcode,
            ProductName = productName,
            CategoryId = categoryId,
            SupplierId = supplierId,
            SaleUnit = NormalizeUnit(saleUnit),
            PurchaseUnit = NormalizeUnit(purchaseUnit),
            ConversionFactor = conversionFactor,
            SalePrice = salePrice,
            PurchasePrice = purchasePrice,
            // Stok awal (opening balance) dinilai pada harga beli sebagai HPP awal.
            AverageCost = initialStock > 0 ? purchasePrice : 0m,
            Stock = initialStock
        });
    }

    public async Task UpdateAsync(int id, string barcode, string productName, int? categoryId, int? supplierId,
        string saleUnit, string purchaseUnit, int conversionFactor,
        decimal salePrice, decimal purchasePrice)
    {
        var existing = await _repo.GetByIdAsync(id)
            ?? throw new EntityNotFoundException($"Produk dengan id {id} tidak ditemukan");

        barcode = ValidateBarcode(barcode);
        productName = ValidateName(productName);
        ValidateNumbers(conversionFactor, salePrice, purchasePrice, initialStock: 0);
        await EnsureBarcodeNotDuplicateAsync(barcode, excludeId: id);

        existing.Barcode = barcode;
        existing.ProductName = productName;
        existing.CategoryId = categoryId;
        existing.SupplierId = supplierId;
        existing.SaleUnit = NormalizeUnit(saleUnit);
        existing.PurchaseUnit = NormalizeUnit(purchaseUnit);
        existing.ConversionFactor = conversionFactor;
        existing.SalePrice = salePrice;
        existing.PurchasePrice = purchasePrice;
        // Stock & AverageCost sengaja tidak diubah di sini (dikelola beli/jual/opname).

        await _repo.UpdateAsync(existing);
    }

    public async Task DeleteAsync(int id)
    {
        _ = await _repo.GetByIdAsync(id)
            ?? throw new EntityNotFoundException($"Produk dengan id {id} tidak ditemukan");

        await _repo.DeleteAsync(id);
    }

    private static string ValidateBarcode(string barcode)
    {
        barcode = barcode?.Trim() ?? string.Empty;
        if (string.IsNullOrWhiteSpace(barcode))
            throw new ValidationException("Barcode Tidak Boleh Kosong");
        return barcode;
    }

    private static string ValidateName(string name)
    {
        name = name?.Trim() ?? string.Empty;
        if (string.IsNullOrWhiteSpace(name))
            throw new ValidationException("Nama Produk Tidak Boleh Kosong");
        return name;
    }

    private static void ValidateNumbers(int conversionFactor, decimal salePrice, decimal purchasePrice, int initialStock)
    {
        if (conversionFactor < 1)
            throw new ValidationException("Faktor Konversi Minimal 1");
        if (salePrice < 0 || purchasePrice < 0)
            throw new ValidationException("Harga Tidak Boleh Negatif");
        if (initialStock < 0)
            throw new ValidationException("Stok Awal Tidak Boleh Negatif");
    }

    private static string NormalizeUnit(string? unit)
    {
        unit = unit?.Trim();
        return string.IsNullOrWhiteSpace(unit) ? "PCS" : unit.ToUpperInvariant();
    }

    private async Task EnsureBarcodeNotDuplicateAsync(string barcode, int? excludeId)
    {
        var existing = await _repo.GetByBarcodeAsync(barcode);
        if (existing is not null && existing.ProductId != excludeId)
            throw new DuplicateEntityException($"Barcode '{barcode}' Sudah Digunakan Produk Lain");
    }
}
