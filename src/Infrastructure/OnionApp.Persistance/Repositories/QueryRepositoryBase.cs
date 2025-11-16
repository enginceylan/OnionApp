using Microsoft.EntityFrameworkCore;
using OnionApp.Application.Interfaces.Repositories;
using OnionApp.Domain.Common;
using OnionApp.Domain.Entities.Abstraction;
using System.Linq.Expressions;

namespace OnionApp.Persistance.Repositories
{
    public class QueryRepositoryBase<TEntity, TId> : IQueryRepository<TEntity, TId>
        where TEntity : BaseEntity<TId>, new()
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<TEntity> _dbSet;

        public QueryRepositoryBase(DbContext context)
        {
            _dbContext = context;
            _dbSet = _dbContext.Set<TEntity>();
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter, string includes = null, bool tracking = false)
        {
            IQueryable<TEntity> query = _dbSet;

            if (!tracking)
                query = query.AsNoTracking();

            if (includes != null)
            {
                foreach (var item in includes.Split(',', StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(item);
                }

            }

            return await query.SingleOrDefaultAsync(filter);
        }

        public async Task<IQueryable<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> filter = null, string includes = null, bool tracking = false)
        {
            IQueryable<TEntity> query = _dbSet;

            if (!tracking)
                query = query.AsNoTracking();

            if (filter != null)
                query = query.Where(filter);

            if (!string.IsNullOrEmpty(includes))
            {
                foreach (var item in includes.Split(',', StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(item);
                }
            }

            

            return query;
        }

        public async Task<PagedList<TEntity, TId>> GetPagedListAsync(Expression<Func<TEntity, bool>> filter = null, string includes = null, bool tracking = false, int? pageNumber = null, int? pageSize = null)
        {
            IQueryable<TEntity> query = _dbSet;

            var pagedList = new PagedList<TEntity, TId>();

            if (!tracking)
                query = query.AsNoTracking();

            if (filter != null)
                query = query.Where(filter);

            foreach (var item in includes.Split(',', StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(item);
            }


            pagedList.TotalCount = query.Count();

            if (pageNumber.HasValue && pageSize.HasValue)
                query = query.Skip((pageNumber.Value - 1) * pageSize.Value)
                             .Take(pageSize.Value);

            pagedList.Items = query;

            return pagedList;
        }
    }
}
