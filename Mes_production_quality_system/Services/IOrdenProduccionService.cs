using Mes_production_quality_system.Models;

namespace Mes_production_quality_system.Services;

public interface IOrdenProduccionService
{
    Task<IEnumerable<OrdenesProduccion>> GetAllAsync();
    Task<OrdenesProduccion?> GetByIdAsync(int id);
    Task<OrdenesProduccion> CreateAsync(OrdenesProduccion orden);
    Task<bool> UpdateAsync(OrdenesProduccion orden);
    Task<bool> DeleteAsync(int id);
}