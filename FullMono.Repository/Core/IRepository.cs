using System.Linq.Expressions;

namespace FullMono.Repository.Core
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includes);
        Task<T> GetByIdAsync(Guid id, params Expression<Func<T, object>>[] includes);
        Task AddAsync(T entity);
        void Remove(T entity);
        void Update(T entity);
    }
}
