using Mes_production_quality_system.Models;

namespace Mes_production_quality_system.Services;

public interface IMaterialService
{
    Task<IEnumerable<Materiale>> GetAllAsync();
    Task<Materiale?> GetByIdAsync(int id);
    Task<Materiale> CreateAsync(Materiale material);
    Task<bool> UpdateAsync(Materiale material);
    Task<bool> DeleteAsync(int id);
}