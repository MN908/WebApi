using System.Linq.Expressions;
using webAPI.Entity;

namespace webAPI.Repository.Interface.Base
{
    public interface IRepository <T> : IDisposable where T : class
    {
        Task<T> AddAsync(T entity);
        Task RemoveByIdAsync(Guid id);
        Task<T?> GetAnyEntityByIdAsync(Guid id);
        Task<T?> UpdateAsync(T entity);
        Task<IEnumerable<T>?> SearchAsync(List<Expression<Func<T, bool>>> where, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, List<Expression<Func<T, object>>> includes = null);
        Task<IEnumerable<T>?> SearchAsync(Expression<Func<T, bool>> where, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, List<Expression<Func<T, object>>> includes = null);
    }
}
