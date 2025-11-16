using MediatR;
using OnionApp.Application.Interfaces.InMemoryCache;
using OnionApp.Application.Models.Dtos.Products;
using OnionApp.Application.Models.ResponseWrappers;

namespace OnionApp.Application.Features.Products.Queries.GetAllActiveProducts
{
    public class GetAllActiveProductsQuery : IRequest<Response<List<ProductGetDto>>>, ICachableQuery
    {
        public string CacheKey
        {
            get
            {
                return "GetAllActiveProducts";
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
