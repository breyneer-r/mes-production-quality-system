using Mes_production_quality_system.Models;

namespace Mes_production_quality_system.Services;

public interface IProveedorService
{
    Task<IEnumerable<Proveedore>> GetAllAsync();
    Task<Proveedore?> GetByIdAsync(int id);
    Task<Proveedore> CreateAsync(Proveedore proveedor);
    Task<bool> UpdateAsync(Proveedore proveedor);
    Task<bool> DeleteAsync(int id);
}