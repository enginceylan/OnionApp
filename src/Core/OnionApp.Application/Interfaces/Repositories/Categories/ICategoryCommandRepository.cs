using OnionApp.Domain.Entities;

namespace OnionApp.Application.Interfaces.Repositories.Categories
{
    public interface ICategoryCommandRepository:ICommandRepository<Category,int>
    {
        // Buraya Category tipine özel command metodları TANIMI yazabiliriz.
    }
}
