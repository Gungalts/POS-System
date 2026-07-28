using POS.Application.Interfaces;
using POS.Domain.Entities;
using POS.Domain.Exceptions;
using POS.Domain.Interfaces;

namespace POS.Application.Services;

public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _repo;
    public CustomerService(ICustomerRepository repo) => _repo = repo;

    public Task<Customer?> GetByIdAsync(int id) => _repo.GetByIdAsync(id);

    public Task<IEnumerable<Customer>> GetAllAsync() => _repo.GetAllAsync();

    public Task<IEnumerable<Customer>> SearchAsync(string keyword)
        => _repo.SearchAsync(keyword?.Trim() ?? string.Empty);

    public async Task<int> CreateAsync(string customerName, string? phoneNumber, string? address)
    {
        customerName = ValidateName(customerName);
        phoneNumber = NormalizePhone(phoneNumber);
        await EnsurePhoneNotDuplicateAsync(phoneNumber, excludeId: null);

        return await _repo.AddAsync(new Customer
        {
            CustomerName = customerName,
            PhoneNumber = phoneNumber,
            Address = address?.Trim()
        });
    }

    public async Task UpdateAsync(int id, string customerName, string? phoneNumber, string? address)
    {
        var existing = await _repo.GetByIdAsync(id)
            ?? throw new EntityNotFoundException($"Customer dengan id {id} tidak ditemukan");

        phoneNumber = NormalizePhone(phoneNumber);
        await EnsurePhoneNotDuplicateAsync(phoneNumber, excludeId: id);

        existing.CustomerName = ValidateName(customerName);
        existing.PhoneNumber = phoneNumber;
        existing.Address = address?.Trim();

        await _repo.UpdateAsync(existing);
    }

    public async Task DeleteAsync(int id)
    {
        _ = await _repo.GetByIdAsync(id)
            ?? throw new EntityNotFoundException($"Customer dengan id {id} tidak ditemukan");

        await _repo.DeleteAsync(id);
    }

    private static string ValidateName(string name)
    {
        name = name?.Trim() ?? string.Empty;
        if (string.IsNullOrWhiteSpace(name))
            throw new ValidationException("Nama Customer Tidak Boleh Kosong");
        return name;
    }

    private static string? NormalizePhone(string? phone)
    {
        phone = phone?.Trim();
        return string.IsNullOrWhiteSpace(phone) ? null : phone;
    }

    private async Task EnsurePhoneNotDuplicateAsync(string? phoneNumber, int? excludeId)
    {
        // Telepon opsional — keunikan hanya berlaku bila nomor benar-benar diisi.
        if (phoneNumber is null) return;

        var all = await _repo.GetAllAsync();
        var duplicate = all.Any(c =>
            string.Equals(c.PhoneNumber, phoneNumber, StringComparison.OrdinalIgnoreCase)
            && c.CustomerId != excludeId);

        if (duplicate)
            throw new DuplicateEntityException(
                $"Nomor Telepon '{phoneNumber}' Sudah Digunakan Customer Lain");
    }
}