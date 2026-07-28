using POS.Application.Interfaces;
using POS.Domain.Entities;
using POS.Domain.Exceptions;
using POS.Domain.Interfaces;

namespace POS.Application.Services;

public class SupplierService : ISupplierService
{
    private readonly ISupplierRepository _repo;
    public SupplierService(ISupplierRepository repo) => _repo = repo;

    public Task<Supplier?> GetByIdAsync(int id) => _repo.GetByIdAsync(id);

    public Task<IEnumerable<Supplier>> GetAllAsync() => _repo.GetAllAsync();

    public Task<IEnumerable<Supplier>> SearchAsync(string keyword)
        => _repo.SearchAsync(keyword?.Trim() ?? string.Empty);

    public async Task<int> CreateAsync(string supplierName, string? phoneNumber)
    {
        supplierName = ValidateName(supplierName);
        phoneNumber = ValidatePhone(phoneNumber);

        return await _repo.AddAsync(new Supplier
        {
            SupplierName = supplierName,
            PhoneNumber = phoneNumber
        });
    }

    public async Task UpdateAsync(int id, string supplierName, string? phoneNumber)
    {
        var existing = await _repo.GetByIdAsync(id)
            ?? throw new EntityNotFoundException($"Supplier dengan id {id} tidak ditemukan");

        existing.SupplierName = ValidateName(supplierName);
        existing.PhoneNumber = ValidatePhone(phoneNumber);

        await _repo.UpdateAsync(existing);
    }

    public async Task DeleteAsync(int id)
    {
        _ = await _repo.GetByIdAsync(id)
            ?? throw new EntityNotFoundException($"Supplier dengan id {id} tidak ditemukan");

        await _repo.DeleteAsync(id);
    }

    private static string ValidateName(string name)
    {
        name = name?.Trim() ?? string.Empty;
        if (string.IsNullOrWhiteSpace(name))
            throw new ValidationException("Nama Supplier Tidak Boleh Kosong");
        return name;
    }

    private static string? ValidatePhone(string? phone)
    {
        if (string.IsNullOrWhiteSpace(phone))
            return null;

        phone = phone.Trim();
        if (!phone.All(c => char.IsDigit(c) || c is '+' or '-' or ' '))
            throw new ValidationException("Format Nomor Telepon Tidak Valid");

        return phone;
    }
}