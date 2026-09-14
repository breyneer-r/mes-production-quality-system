using Mes_production_quality_system.Models;
using Mes_production_quality_system.Repositories.Interfaces;

namespace Mes_production_quality_system.Repositories;

public class InspeccionCalidadRepository
    : GenericRepository<InspeccionesCalidad>, IInspeccionCalidadRepository
{
    public InspeccionCalidadRepository(ApplicationDbContext context)
        : base(context)
    {
    }
}