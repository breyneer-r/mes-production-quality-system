namespace Mes_production_quality_system.Services.Implements;

using Mes_production_quality_system.Entities;
using Mes_production_quality_system.Repositories;

public class ProveedorService : BaseService<Proveedor>, IProveedorService
{
    public ProveedorService(IUnitOfWork unitOfWork) 
        : base(unitOfWork, unitOfWork.Proveedores)
    {
    }
}