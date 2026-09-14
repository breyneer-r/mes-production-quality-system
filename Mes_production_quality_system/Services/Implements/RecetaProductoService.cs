using Mes_production_quality_system.Models;
using Mes_production_quality_system.Repositories.Interfaces;

namespace Mes_production_quality_system.Services.Implements;

public class RecetaProductoService : IRecetaProductoService
{
    private readonly IUnitOfWork _unitOfWork;

    public RecetaProductoService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<RecetaProducto>> GetAllAsync()
    {
        return await _unitOfWork.RecetasProductos.GetAllAsync();
    }

    public async Task<RecetaProducto?> GetByIdAsync(int id)
    {
        return await _unitOfWork.RecetasProductos.GetByIdAsync(id);
    }

    public async Task<RecetaProducto> CreateAsync(RecetaProducto receta)
    {
        await _unitOfWork.RecetasProductos.AddAsync(receta);
        await _unitOfWork.SaveAsync();

        return receta;
    }

    public async Task<bool> UpdateAsync(RecetaProducto receta)
    {
        _unitOfWork.RecetasProductos.Update(receta);
        await _unitOfWork.SaveAsync();

        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var receta = await _unitOfWork.RecetasProductos.GetByIdAsync(id);

        if (receta == null)
            return false;

        _unitOfWork.RecetasProductos.Delete(receta);
        await _unitOfWork.SaveAsync();

        return true;
    }
}