using Mes_production_quality_system.Models;
using Mes_production_quality_system.Repositories.Interfaces;

namespace Mes_production_quality_system.Services.Implements;

public class ProveedorService : IProveedorService
{
    private readonly IUnitOfWork _unitOfWork;

    public ProveedorService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Proveedore>> GetAllAsync()
    {
        return await _unitOfWork.Proveedores.GetAllAsync();
    }

    public async Task<Proveedore?> GetByIdAsync(int id)
    {
        return await _unitOfWork.Proveedores.GetByIdAsync(id);
    }

    public async Task<Proveedore> CreateAsync(Proveedore proveedor)
    {
        await _unitOfWork.Proveedores.AddAsync(proveedor);
        await _unitOfWork.SaveAsync();

        return proveedor;
    }

    public async Task<bool> UpdateAsync(Proveedore proveedor)
    {
        _unitOfWork.Proveedores.Update(proveedor);
        await _unitOfWork.SaveAsync();

        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var proveedor = await _unitOfWork.Proveedores.GetByIdAsync(id);

        if (proveedor == null)
            return false;

        _unitOfWork.Proveedores.Delete(proveedor);
        await _unitOfWork.SaveAsync();

        return true;
    }
}