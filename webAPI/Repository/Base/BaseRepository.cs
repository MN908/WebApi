using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using webAPI.Data;
using webAPI.Entity.Request;
using webAPI.Models;
using webAPI.Models.Base;
using webAPI.Repository.Interface.Base;

namespace webAPI.Repository.Base
{
    public abstract class BaseRepository<T> : IRepository<T> where T : EntityBase
    {
        protected readonly ServiceDBContext _context;
        protected readonly DbSet<T> _dbSet;
        public BaseRepository(ServiceDBContext context)
        {
            _context = context ?? throw new ArgumentException(nameof(context));

            _dbSet = _context.Set<T>();
        }
        public void Dispose()
        {
            _context?.Dispose();
        }
        public virtual async Task<T> AddAsync(T entity)
        {
            entity.CreatedOn = DateTime.UtcNow;
            entity.IsDeleted = false;
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();

            foreach (var toDetach in _context.ChangeTracker.Entries())
            {
                toDetach.State = EntityState.Detached;
            }

            return entity;
        }

        public virtual async Task RemoveByIdAsync(Guid id)
        {
            T? entity = await GetAnyEntityByIdAsync(id);

            if (entity == null)
            {
                throw new DirectoryNotFoundException();
            }

            entity.IsDeleted = true;

            _dbSet.Update(entity);

            await _context.SaveChangesAsync();

            foreach (var toDetach in _context.ChangeTracker.Entries())
            {
                toDetach.State = EntityState.Detached;
            }
        }

        public virtual async Task<T?> UpdateAsync(T entity)
        {
            _dbSet.Update(entity);

            await _context.SaveChangesAsync();

            await _context.SaveChangesAsync();

            foreach (var toDetach in _context.ChangeTracker.Entries())
            {
                toDetach.State = EntityState.Detached;
            }

            return entity;
        }

        public async Task<IEnumerable<T>?> SearchAsync(List<Expression<Func<T, bool>>> where, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy, List<Expression<Func<T, object>>> includes)
        {
            if (includes == null)
            {
                includes = new List<Expression<Func<T, object>>>();
            }

            return await SearchEntityAsync(where, orderBy, includes);
        }
        public async Task<IEnumerable<T>?> SearchAsync(Expression<Func<T, bool>> where, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy, List<Expression<Func<T, object>>> includes)
        {
            if (includes == null)
            {
                includes = new List<Expression<Func<T, object>>>();
            }

            return await SearchEntityAsync(where, orderBy, includes);

        }

        public abstract Task<T?> GetAnyEntityByIdAsync(Guid id);

        protected abstract Task<IEnumerable<T>?> SearchEntityAsync(Expression<Func<T, bool>> where, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy, List<Expression<Func<T, object>>> includes);
        protected abstract Task<IEnumerable<T>?> SearchEntityAsync(List<Expression<Func<T, bool>>> where, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy, List<Expression<Func<T, object>>> includes);
    }
}
