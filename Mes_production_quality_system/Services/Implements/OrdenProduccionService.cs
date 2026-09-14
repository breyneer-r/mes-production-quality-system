namespace Mes_production_quality_system.Services.Implements;

using Mes_production_quality_system.Entities;
using Mes_production_quality_system.Repositories;

public class OrdenProduccionService : BaseService<OrdenProduccion>, IOrdenProduccionService
{
    public OrdenProduccionService(IUnitOfWork unitOfWork) 
        : base(unitOfWork, unitOfWork.OrdenesProduccion)
    {
    }
}