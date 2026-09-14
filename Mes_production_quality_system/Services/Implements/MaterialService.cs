using Mes_production_quality_system.Models;
using Mes_production_quality_system.Repositories.Interfaces;

namespace Mes_production_quality_system.Services.Implements;

public class MaterialService : IMaterialService
{
    private readonly IUnitOfWork _unitOfWork;

    public MaterialService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Materiale>> GetAllAsync()
    {
        return await _unitOfWork.Materiales.GetAllAsync();
    }

    public async Task<Materiale?> GetByIdAsync(int id)
    {
        return await _unitOfWork.Materiales.GetByIdAsync(id);
    }

    public async Task<Materiale> CreateAsync(Materiale material)
    {
        await _unitOfWork.Materiales.AddAsync(material);
        await _unitOfWork.SaveAsync();

        return material;
    }

    public async Task<bool> UpdateAsync(Materiale material)
    {
        _unitOfWork.Materiales.Update(material);
        await _unitOfWork.SaveAsync();

        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var material = await _unitOfWork.Materiales.GetByIdAsync(id);

        if (material == null)
            return false;

        _unitOfWork.Materiales.Delete(material);
        await _unitOfWork.SaveAsync();

        return true;
    }
}