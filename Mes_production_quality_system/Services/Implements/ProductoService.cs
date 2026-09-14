using Mes_production_quality_system.Models;
using Mes_production_quality_system.Repositories.Interfaces;

namespace Mes_production_quality_system.Services.Implements;

public class ProductoService : IProductoService
{
    private readonly IUnitOfWork _unitOfWork;

    public ProductoService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Producto>> GetAllAsync()
    {
        return await _unitOfWork.Productos.GetAllAsync();
    }

    public async Task<Producto?> GetByIdAsync(int id)
    {
        return await _unitOfWork.Productos.GetByIdAsync(id);
    }

    public async Task<Producto> CreateAsync(Producto producto)
    {
        await _unitOfWork.Productos.AddAsync(producto);
        await _unitOfWork.SaveAsync();

        return producto;
    }

    public async Task<bool> UpdateAsync(Producto producto)
    {
        _unitOfWork.Productos.Update(producto);
        await _unitOfWork.SaveAsync();

        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var producto = await _unitOfWork.Productos.GetByIdAsync(id);

        if (producto == null)
            return false;

        _unitOfWork.Productos.Delete(producto);
        await _unitOfWork.SaveAsync();

        return true;
    }
}