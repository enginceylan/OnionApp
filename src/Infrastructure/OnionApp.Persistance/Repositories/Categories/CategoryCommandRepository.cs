using OnionApp.Application.Interfaces.Repositories.Categories;
using OnionApp.Domain.Entities;
using OnionApp.Persistance.Contexts;

namespace OnionApp.Persistance.Repositories.Categories
{
    public class CategoryCommandRepository:CommandRepositoryBase<Category,int>
                                           ,ICategoryCommandRepository
    {
        public CategoryCommandRepository(AppDbContext dbContext):base(dbContext)
        {
                
        }
    }
}
