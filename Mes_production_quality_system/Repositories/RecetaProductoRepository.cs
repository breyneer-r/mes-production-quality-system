using Mes_production_quality_system.Models;
using Mes_production_quality_system.Repositories.Interfaces;

namespace Mes_production_quality_system.Repositories;

public class RecetaProductoRepository
    : GenericRepository<RecetaProducto>, IRecetaProductoRepository
{
    public RecetaProductoRepository(ApplicationDbContext context)
        : base(context)
    {
    }
}