using OnionApp.Domain.Common;
using OnionApp.Domain.Entities;

namespace OnionApp.Application.Interfaces.Repositories.Products
{
    public interface IProductQueryRepository : IQueryRepository<Product,int>
    {
        Task<IQueryable<Product>> GetByPriceAsync(
            decimal min,
            decimal max,
            string includes = null,
            bool tracking = false);

        Task<PagedList<Product,int>> GetByPricePagedAsync(
            decimal min,
            decimal max,
            string includes = null,
            bool tracking = false,
            int? pageNumber = null,
            int? pageSize = null);
    }
}
