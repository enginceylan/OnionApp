using Microsoft.EntityFrameworkCore;
using OnionApp.Application.Interfaces.Repositories;
using OnionApp.Domain.Entities.Abstraction;

namespace OnionApp.Persistance.Repositories
{
    public class CommandRepositoryBase<TEntity, TId> : ICommandRepository<TEntity, TId>
        where TEntity : BaseEntity<TId>, new()
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<TEntity> _dbSet;

        public CommandRepositoryBase(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<TEntity>();
        }
        public async Task<TEntity> AddAsync(TEntity entity)
        {
            var added = await _dbSet.AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return added.Entity;
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await _dbSet.AddRangeAsync(entities);
            await _dbContext.SaveChangesAsync();
        }

        public void Remove(TEntity entity)
        {
            if(_dbContext.Entry(entity).State == EntityState.Detached)
                _dbSet.Attach(entity);

            _dbContext.Remove(entity);
            _dbContext.SaveChanges();
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            _dbContext.RemoveRange(entities);
            _dbContext.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            _dbSet.Update(entity);
            _dbContext.SaveChanges();
        }

        public void UpdateRange(IEnumerable<TEntity> entities)
        {
            _dbSet.UpdateRange(entities);
            _dbContext.SaveChanges();
        }
    }
}
