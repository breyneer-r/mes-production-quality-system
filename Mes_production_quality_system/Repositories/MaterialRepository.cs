using Mes_production_quality_system.Models;
using Mes_production_quality_system.Repositories.Interfaces;

namespace Mes_production_quality_system.Repositories;

public class MaterialRepository
    : GenericRepository<Materiale>, IMaterialRepository
{
    public MaterialRepository(ApplicationDbContext context)
        : base(context)
    {
    }
}