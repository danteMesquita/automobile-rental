using AutomobileRentalManagementAPI.Domain.Entities;
using AutomobileRentalManagementAPI.Domain.Repositories;
using AutomobileRentalManagementAPI.Infra.Contexts.Impl;
using Microsoft.EntityFrameworkCore;

namespace AutomobileRentalManagementAPI.Infra.Repositories
{
    public class RepositoryBase<T>(RentalDbContext db) : IRepositoryBase<T> where T : BaseEntity
    {
        protected readonly DbSet<T> _dbSet = db.Set<T>();

        public async Task<T> AddAsync(T entity, bool isActive = true)
        {
            await db.AddAsync(entity);
            await db.SaveChangesAsync();

            return entity;
        }

        public async Task<List<T>> AddRangeAsync(List<T> entities)
        {
            foreach (var entity in entities)
            {
                await db.Set<T>().AddAsync(entity);
            }


            await db.SaveChangesAsync();

            return entities;
        }

        public async Task UpdateRangeAsync(List<T> entities)
        {
            foreach (var item in entities)
            {
                db.Entry(item).State = EntityState.Modified;
            }

            await db.SaveChangesAsync();
        }

        public async Task<T?> GetByIdAsync(Guid id)
        {
            var find = await db.Set<T>().FindAsync(id);

            if (find != null)
                db.Entry<T>(find).State = EntityState.Detached;

            return find;
        }

        public async Task<List<T>> GetAllAsync() => await db.Set<T>().AsNoTracking().ToListAsync();

        public async Task<T> UpdateAsync(T entity)
        {
            db.Entry(entity).State = EntityState.Modified;
            await db.SaveChangesAsync();

            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            db.Set<T>().Remove(entity);
            await db.SaveChangesAsync();
        }

        public async Task DeleteRangeAsync(List<T> entities)
        {
            if (entities != null)
            {
                db.Set<T>().RemoveRange(entities);
                await db.SaveChangesAsync();
            }
        }
    }
}