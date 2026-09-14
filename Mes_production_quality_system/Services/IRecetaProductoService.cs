using Mes_production_quality_system.Models;

namespace Mes_production_quality_system.Services;

public interface IRecetaProductoService
{
    Task<IEnumerable<RecetaProducto>> GetAllAsync();
    Task<RecetaProducto?> GetByIdAsync(int id);
    Task<RecetaProducto> CreateAsync(RecetaProducto receta);
    Task<bool> UpdateAsync(RecetaProducto receta);
    Task<bool> DeleteAsync(int id);
}