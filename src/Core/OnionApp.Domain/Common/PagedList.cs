using OnionApp.Domain.Entities.Abstraction;

namespace OnionApp.Domain.Common
{
    public class PagedList<TEntity,TId>
        where TEntity : BaseEntity<TId>,new()
    {
        public IQueryable<TEntity> Items { get; set; }
        public int TotalCount { get; set; }
    }
}
