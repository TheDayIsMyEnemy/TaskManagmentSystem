using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TaskManagmentSystem.Core.Interfaces;

namespace TaskManagmentSystem.Infrastructure.Data
{
    public abstract class EfRepository<T> : IAsyncRepository<T> where T : class
    {
        protected readonly AppDbContext db;

        public EfRepository(AppDbContext db) => this.db = db;

        public async Task<T> GetByIdAsync(int id)
        {
            return await db.Set<T>().FindAsync(id);
        }

        public async Task UpdateAsync(T entity)
        {
            db.Entry(entity).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }

        public async Task<T> CreateAsync(T entity)
        {
            db.Set<T>().Add(entity);
            await db.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            db.Remove(entity);
            await db.SaveChangesAsync();
        }

        public async Task<ICollection<T>> ListAllAsync()
            => await db.Set<T>().ToListAsync();

        public async Task<ICollection<T>> ListAsync(Expression<Func<T, bool>> predicate)
            => await db.Set<T>().Where(predicate).ToListAsync();

        public async Task<int> CountAsync()
            => await db.Set<T>().CountAsync();
    }
}
