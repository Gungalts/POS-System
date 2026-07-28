using POS.Domain.Entities;

namespace POS.Application.Interfaces;

public interface IProductService
{
    Task<Product?> GetByIdAsync(int id);
    Task<Product?> GetByBarcodeAsync(string barcode);
    Task<IEnumerable<Product>> GetAllAsync();
    Task<IEnumerable<Product>> SearchAsync(string keyword);

    Task<int> CreateAsync(string barcode, string productName, int? categoryId, int? supplierId,
        string saleUnit, string purchaseUnit, int conversionFactor,
        decimal salePrice, decimal purchasePrice, int initialStock);

    // Catatan: update tidak mengubah stock/average_cost — perubahan stok lewat beli/jual/opname.
    Task UpdateAsync(int id, string barcode, string productName, int? categoryId, int? supplierId,
        string saleUnit, string purchaseUnit, int conversionFactor,
        decimal salePrice, decimal purchasePrice);

    Task DeleteAsync(int id);
}
