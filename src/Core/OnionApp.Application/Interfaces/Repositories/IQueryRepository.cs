using OnionApp.Domain.Common;
using OnionApp.Domain.Entities.Abstraction;
using System.Linq.Expressions;

namespace OnionApp.Application.Interfaces.Repositories
{
    public interface IQueryRepository<TEntity,TId>
        where TEntity : BaseEntity<TId>, new()
    {
        Task<PagedList<TEntity,TId>> GetPagedListAsync(
                Expression<Func<TEntity, bool>> filter = null,
                string includes = null,
                bool tracking = false,
                int? pageNumber = null,
                int? pageSize = null
            );
        Task<IQueryable<TEntity>> GetListAsync(
                Expression<Func<TEntity,bool>> filter = null,
                string includes = null,
                bool tracking = false
            );

        Task<TEntity> GetAsync(
               Expression<Func<TEntity, bool>> filter,
               string includes = null,
                bool tracking = false
            );
    }
}
