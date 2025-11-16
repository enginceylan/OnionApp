using OnionApp.Domain.Entities;

namespace OnionApp.Application.Interfaces.Repositories.Categories
{
    public interface ICategoryQueryRepository:IQueryRepository<Category,int>
    {
        // Buraya Category tipine özel query metodları TANIMI yazabiliriz.
    }
}
