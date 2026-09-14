using Mes_production_quality_system.Models;
using Mes_production_quality_system.Repositories.Interfaces;


namespace Mes_production_quality_system.Repositories;

public class OrdenProduccionRepository
    : GenericRepository<OrdenesProduccion>, IOrdenProduccionRepository
{
    public OrdenProduccionRepository(ApplicationDbContext context)
        : base(context)
    {
    }
}