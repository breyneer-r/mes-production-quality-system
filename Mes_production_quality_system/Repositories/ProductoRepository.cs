using Mes_production_quality_system.Models;
using Mes_production_quality_system.Repositories.Interfaces;

namespace Mes_production_quality_system.Repositories;

public class ProductoRepository
    : GenericRepository<Producto>, IProductoRepository
{
    public ProductoRepository(ApplicationDbContext context)
        : base(context)
    {
    }
}