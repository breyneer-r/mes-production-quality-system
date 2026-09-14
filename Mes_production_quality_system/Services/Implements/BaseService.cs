namespace Mes_production_quality_system.Services.Implements;

using Mes_production_quality_system.Repositories;

public abstract class BaseService<T> : IBaseService<T> where T : class
{
    protected readonly IUnitOfWork _unitOfWork;
    protected readonly IRepository<T> _repository;

    protected BaseService(IUnitOfWork unitOfWork, IRepository<T> repository)
    {
        _unitOfWork = unitOfWork;
        _repository = repository;
    }

    public virtual async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public virtual async Task<T?> GetByIdAsync(int id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public virtual async Task<T> CreateAsync(T entity)
    {
        await _repository.AddAsync(entity);
        await _unitOfWork.SaveChangesAsync();
        return entity;
    }

    public virtual async Task<bool> UpdateAsync(T entity)
    {
        _repository.Update(entity);
        return await _unitOfWork.SaveChangesAsync() > 0;
    }

    public virtual async Task<bool> DeleteAsync(int id)
    {
        var entity = await _repository.GetByIdAsync(id);
        if (entity == null) return false;

        _repository.Delete(entity);
        return await _unitOfWork.SaveChangesAsync() > 0;
    }
}