using Mes_production_quality_system.Models;
using Mes_production_quality_system.Repositories.Interfaces;

namespace Mes_production_quality_system.Services.Implements;

public class InspeccionCalidadService : IInspeccionCalidadService
{
    private readonly IUnitOfWork _unitOfWork;

    public InspeccionCalidadService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<InspeccionesCalidad>> GetAllAsync()
    {
        return await _unitOfWork.InspeccionesCalidad.GetAllAsync();
    }

    public async Task<InspeccionesCalidad?> GetByIdAsync(int id)
    {
        return await _unitOfWork.InspeccionesCalidad.GetByIdAsync(id);
    }

    public async Task<InspeccionesCalidad> CreateAsync(InspeccionesCalidad inspeccion)
    {
        await _unitOfWork.InspeccionesCalidad.AddAsync(inspeccion);
        await _unitOfWork.SaveAsync();

        return inspeccion;
    }

    public async Task<bool> UpdateAsync(InspeccionesCalidad inspeccion)
    {
        _unitOfWork.InspeccionesCalidad.Update(inspeccion);
        await _unitOfWork.SaveAsync();

        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var inspeccion = await _unitOfWork.InspeccionesCalidad.GetByIdAsync(id);

        if (inspeccion == null)
            return false;

        _unitOfWork.InspeccionesCalidad.Delete(inspeccion);
        await _unitOfWork.SaveAsync();

        return true;
    }
}