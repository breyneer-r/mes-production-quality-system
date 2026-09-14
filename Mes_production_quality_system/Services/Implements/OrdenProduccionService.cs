using Mes_production_quality_system.Models;
using Mes_production_quality_system.Repositories.Interfaces;

namespace Mes_production_quality_system.Services.Implements;

public class OrdenProduccionService : IOrdenProduccionService
{
    private readonly IUnitOfWork _unitOfWork;

    public OrdenProduccionService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<OrdenesProduccion>> GetAllAsync()
    {
        return await _unitOfWork.OrdenesProduccion.GetAllAsync();
    }

    public async Task<OrdenesProduccion?> GetByIdAsync(int id)
    {
        return await _unitOfWork.OrdenesProduccion.GetByIdAsync(id);
    }

    public async Task<OrdenesProduccion> CreateAsync(OrdenesProduccion orden)
    {
        await _unitOfWork.OrdenesProduccion.AddAsync(orden);
        await _unitOfWork.SaveAsync();

        return orden;
    }

    public async Task<bool> UpdateAsync(OrdenesProduccion orden)
    {
        _unitOfWork.OrdenesProduccion.Update(orden);
        await _unitOfWork.SaveAsync();

        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var orden = await _unitOfWork.OrdenesProduccion.GetByIdAsync(id);

        if (orden == null)
            return false;

        _unitOfWork.OrdenesProduccion.Delete(orden);
        await _unitOfWork.SaveAsync();

        return true;
    }
}