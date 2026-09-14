namespace Mes_production_quality_system.Repositories.Interfaces;

public interface IUnitOfWork
{
    IProveedorRepository Proveedores { get; }
    IMaterialRepository Materiales { get; }
    IProductoRepository Productos { get; }
    IRecetaProductoRepository RecetasProductos { get; }
    IOrdenProduccionRepository OrdenesProduccion { get; }
    IInspeccionCalidadRepository InspeccionesCalidad { get; }

    Task SaveAsync();
}