using Mes_production_quality_system.Models;

namespace Mes_production_quality_system.Services;

public interface IInspeccionCalidadService
{
    Task<IEnumerable<InspeccionesCalidad>> GetAllAsync();
    Task<InspeccionesCalidad?> GetByIdAsync(int id);
    Task<InspeccionesCalidad> CreateAsync(InspeccionesCalidad inspeccion);
    Task<bool> UpdateAsync(InspeccionesCalidad inspeccion);
    Task<bool> DeleteAsync(int id);
}