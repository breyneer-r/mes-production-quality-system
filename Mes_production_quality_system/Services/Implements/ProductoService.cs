namespace Mes_production_quality_system.Services.Implements;

using Mes_production_quality_system.Entities;
using Mes_production_quality_system.Repositories;

public class ProductoService : BaseService<Producto>, IProductoService
{
    public ProductoService(IUnitOfWork unitOfWork) 
        : base(unitOfWork, unitOfWork.Productos)
    {
    }
}