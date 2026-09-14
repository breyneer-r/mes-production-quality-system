using Mes_production_quality_system.Models;
using Mes_production_quality_system.Repositories.Interfaces;

namespace Mes_production_quality_system.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;

    public IProveedorRepository Proveedores { get; }
    public IMaterialRepository Materiales { get; }
    public IProductoRepository Productos { get; }
    public IRecetaProductoRepository RecetasProductos { get; }
    public IOrdenProduccionRepository OrdenesProduccion { get; }
    public IInspeccionCalidadRepository InspeccionesCalidad { get; }

    public UnitOfWork(
        ApplicationDbContext context,
        IProveedorRepository proveedores,
        IMaterialRepository materiales,
        IProductoRepository productos,
        IRecetaProductoRepository recetasProductos,
        IOrdenProduccionRepository ordenesProduccion,
        IInspeccionCalidadRepository inspeccionesCalidad)
    {
        _context = context;

        Proveedores = proveedores;
        Materiales = materiales;
        Productos = productos;
        RecetasProductos = recetasProductos;
        OrdenesProduccion = ordenesProduccion;
        InspeccionesCalidad = inspeccionesCalidad;
    }

    public async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }
}