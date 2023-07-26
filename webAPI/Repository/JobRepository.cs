using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Security.Cryptography;
using webAPI.Data;
using webAPI.Entity;
using webAPI.Repository.Base;
using webAPI.Repository.Interface;

namespace webAPI.Repository
{
    public class JobRepository : BaseRepository<Job>, IJobRepository
    {
        private new readonly ServiceDBContext _context;
        public JobRepository(ServiceDBContext context) : base(context)
        {
            _context = context;
        }
        protected async override Task<IEnumerable<Job>?> SearchEntityAsync(Expression<Func<Job, bool>> where, Func<IQueryable<Job>, IOrderedQueryable<Job>> orderBy, List<Expression<Func<Job, object>>> includes)
        {
            var qry = GetQueryable(new List<Expression<Func<Job, bool>>>() { where }, orderBy, includes);
            return await qry.ToListAsync();
        }
        protected async override Task<IEnumerable<Job>?> SearchEntityAsync(List<Expression<Func<Job, bool>>> where, Func<IQueryable<Job>, IOrderedQueryable<Job>> orderBy, List<Expression<Func<Job, object>>> includes)
        {
            var qry = GetQueryable(where, orderBy, includes);
            return await qry.ToListAsync();
        }
        public async override Task<Job?> GetAnyEntityByIdAsync(Guid id)
        {
            return await _context.Jobs
                .AsNoTracking()
                .Where(x => x.Id == id && !x.IsDeleted )
                .FirstOrDefaultAsync();
        }
        private IQueryable<Job> GetQueryable(List<Expression<Func<Job, bool>>> where, Func<IQueryable<Job>, IOrderedQueryable<Job>> orderBy, List<Expression<Func<Job, object>>> includes)
        {
            var qry = _context
            .Jobs
            .AsNoTracking()
            .AsQueryable();
            if (where != null)
            {
                where.ForEach(x =>
                {
                    qry = qry.Where(x);
                });
            }
            foreach (var include in includes)
            {
                qry = qry.Include(include);
            }

            if (orderBy != null)
            {
                return orderBy(qry);
            }
            else
            {
                return qry;
            }
        }

    }
}
