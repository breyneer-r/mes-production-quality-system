using Mes_production_quality_system.Models;
using Mes_production_quality_system.Repositories.Interfaces;

namespace Mes_production_quality_system.Repositories;

public class ProveedorRepository
    : GenericRepository<Proveedore>, IProveedorRepository
{
    public ProveedorRepository(ApplicationDbContext context)
        : base(context)
    {
    }
}