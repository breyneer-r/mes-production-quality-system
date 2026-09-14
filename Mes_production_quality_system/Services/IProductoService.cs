using Mes_production_quality_system.Models;

namespace Mes_production_quality_system.Services;

public interface IProductoService
{
    Task<IEnumerable<Producto>> GetAllAsync();
    Task<Producto?> GetByIdAsync(int id);
    Task<Producto> CreateAsync(Producto producto);
    Task<bool> UpdateAsync(Producto producto);
    Task<bool> DeleteAsync(int id);
}