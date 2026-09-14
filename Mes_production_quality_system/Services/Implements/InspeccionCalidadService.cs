namespace Mes_production_quality_system.Services.Implements;

using Mes_production_quality_system.Entities;
using Mes_production_quality_system.Repositories;

public class InspeccionCalidadService : BaseService<InspeccionCalidad>, IInspeccionCalidadService
{
    public InspeccionCalidadService(IUnitOfWork unitOfWork) 
        : base(unitOfWork, unitOfWork.InspeccionesCalidad)
    {
    }
}