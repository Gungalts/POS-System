using POS.Application.Interfaces;
using POS.Domain.Entities;
using POS.Domain.Exceptions;
using POS.Domain.Interfaces;

namespace POS.Application.Services;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _repo;
    public CategoryService(ICategoryRepository repo) => _repo = repo;

    public Task<Category?> GetByIdAsync(int id) => _repo.GetByIdAsync(id);

    public Task<IEnumerable<Category>> GetAllAsync() => _repo.GetAllAsync();

    public async Task<int> CreateAsync(string categoryName)
    {
        categoryName = ValidateName(categoryName);
        await EnsureNameNotDuplicateAsync(categoryName, excludeId: null);

        return await _repo.AddAsync(new Category { CategoryName = categoryName });
    }

    public async Task UpdateAsync(int id, string categoryName)
    {
        var existing = await _repo.GetByIdAsync(id)
            ?? throw new EntityNotFoundException($"Kategori dengan id {id} tidak ditemukan");

        categoryName = ValidateName(categoryName);
        await EnsureNameNotDuplicateAsync(categoryName, excludeId: id);

        existing.CategoryName = categoryName;
        await _repo.UpdateAsync(existing);
    }

    public async Task DeleteAsync(int id)
    {
        _ = await _repo.GetByIdAsync(id)
            ?? throw new EntityNotFoundException($"Kategori dengan id {id} tidak ditemukan");

        await _repo.DeleteAsync(id);
    }

    private static string ValidateName(string name)
    {
        name = name?.Trim() ?? string.Empty;
        if (string.IsNullOrWhiteSpace(name))
            throw new ValidationException("Nama Kategori Tidak Boleh Kosong");
        if (name.Length > 100)
            throw new ValidationException("Nama Kategori Maksimal 100 Karakter");
        return name;
    }

    private async Task EnsureNameNotDuplicateAsync(string name, int? excludeId)
    {
        var all = await _repo.GetAllAsync();
        var duplicate = all.Any(c =>
            c.CategoryName.Equals(name, StringComparison.OrdinalIgnoreCase)
            && c.CategoryId != excludeId);

        if (duplicate)
            throw new DuplicateEntityException($"Kategori '{name}' Sudah Ada");
    }
}