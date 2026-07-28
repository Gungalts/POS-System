using POS.Application.Requests;
using POS.Domain.Entities;

namespace POS.Application.Interfaces;

public interface IStockOpnameService
{
    Task<int> CreateOpnameAsync(string? notes, IEnumerable<OpnameLineRequest> lines);
    Task<StockOpnameHeader?> GetByIdAsync(int id);
    Task<IEnumerable<StockOpnameHeader>> GetAllAsync();
}
