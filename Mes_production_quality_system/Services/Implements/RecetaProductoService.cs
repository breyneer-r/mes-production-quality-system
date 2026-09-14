namespace Mes_production_quality_system.Services.Implements;

using Mes_production_quality_system.Entities;
using Mes_production_quality_system.Repositories;

public class RecetaProductoService : BaseService<RecetaProducto>, IRecetaProductoService
{
    public RecetaProductoService(IUnitOfWork unitOfWork) 
        : base(unitOfWork, unitOfWork.RecetaProductos)
    {
    }
}