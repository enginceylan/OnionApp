using OnionApp.Application.Interfaces.Repositories.Products;
using OnionApp.Domain.Common;
using OnionApp.Domain.Entities;
using OnionApp.Persistance.Contexts;

namespace OnionApp.Persistance.Repositories.Products
{
    public class ProductQueryRepository : QueryRepositoryBase<Product, int>, IProductQueryRepository
    {
        // AppDbContext buraya IoC tarafından inject edilecek ve aş constrcutor aracılığıyla base sınıfa context geçirilecek. 
        public ProductQueryRepository(AppDbContext dbContext) : base(dbContext)
        {

        }
        public async Task<IQueryable<Product>> GetByPriceAsync(decimal min, decimal max, string includes = null, bool tracking = false)
        {
            return await
                GetListAsync(
                    filter: x => x.UnitPrice >= min && x.UnitPrice <= max,
                    includes: includes,
                    tracking: tracking);
        }

        public async Task<PagedList<Product, int>> GetByPricePagedAsync(decimal min, decimal max, string includes = null, bool tracking = false, int? pageNumber = null, int? pageSize = null)
        {
            return await
                GetPagedListAsync(
                  filter: x => x.UnitPrice >= min && x.UnitPrice <= max,
                  includes: includes,
                  tracking: tracking,
                  pageNumber: pageNumber,
                  pageSize: pageSize
                );
        }
    }
}
