using MediatR;
using OnionApp.Application.Interfaces.InMemoryCache;
using OnionApp.Application.Models.Dtos.Categories;
using OnionApp.Application.Models.ResponseWrappers;

namespace OnionApp.Application.Features.Categories.Queries.GetAllActiveCategories
{
    public class GetAllActiveCategoriesQuery : IRequest<Response<List<CategoryGetDto>>>, ICachableQuery
    {
        public string CacheKey
        {
            get
            {
                return "GetAllActiveCategories";
            }
        }

        public double CacheTime
        {
            get
            {
                return 5;
            }
        }
    }
}
