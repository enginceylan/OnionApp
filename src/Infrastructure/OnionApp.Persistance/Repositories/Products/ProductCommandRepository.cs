using OnionApp.Application.Interfaces.Repositories.Products;
using OnionApp.Domain.Entities;
using OnionApp.Persistance.Contexts;

namespace OnionApp.Persistance.Repositories.Products
{
    public class ProductCommandRepository : CommandRepositoryBase<Product, int>, IProductCommandRepository
    {
        public ProductCommandRepository(AppDbContext dbContext):base(dbContext)
        {
            
        }
    }
}
