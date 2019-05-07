using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TaskManagmentSystem.Core.Interfaces
{
    public interface IAsyncRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        Task<T> CreateAsync(T entity);
        Task DeleteAsync(T entity);
        Task UpdateAsync(T entity);
        Task<ICollection<T>> ListAllAsync();
        Task<ICollection<T>> ListAsync(Expression<Func<T,bool>> predicate);
        Task<int> CountAsync();
    }
}
