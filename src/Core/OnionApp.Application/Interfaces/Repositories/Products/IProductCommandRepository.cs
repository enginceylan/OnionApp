using OnionApp.Domain.Entities;

namespace OnionApp.Application.Interfaces.Repositories.Products
{
    public interface IProductCommandRepository:ICommandRepository<Product,int>
    {
    }
}
