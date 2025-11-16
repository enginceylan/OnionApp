using OnionApp.Domain.Entities.Abstraction;

namespace OnionApp.Application.Interfaces.Repositories
{
    public interface ICommandRepository<TEntity,TId>
        where TEntity : BaseEntity<TId>,new()
    {
        Task<TEntity> AddAsync(TEntity entity);
        Task AddRangeAsync(IEnumerable<TEntity> entities); // Bulk Insert

        void Update(TEntity entity);
        void UpdateRange(IEnumerable<TEntity> entities);

        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
    }
}
