using AutomobileRentalManagementAPI.Domain.Entities;

namespace AutomobileRentalManagementAPI.Domain.Repositories
{
    public interface IRepositoryBase<T> where T : BaseEntity
    {
        Task<T> AddAsync(T entity, bool isActive = true);
        Task<List<T>> AddRangeAsync(List<T> entities);
        Task UpdateRangeAsync(List<T> entities);
        Task<T?> GetByIdAsync(Guid id);
        Task<List<T>> GetAllAsync();
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task DeleteRangeAsync(List<T> entities);
    }
}