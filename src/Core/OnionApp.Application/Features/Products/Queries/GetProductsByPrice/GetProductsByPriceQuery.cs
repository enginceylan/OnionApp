using MediatR;
using OnionApp.Application.Interfaces.InMemoryCache;
using OnionApp.Application.Interfaces.Validation;
using OnionApp.Application.Models.Dtos.Products;
using OnionApp.Application.Models.Parameters;
using OnionApp.Application.Models.ResponseWrappers;

namespace OnionApp.Application.Features.Products.Queries.GetProductsByPrice
{
    public class GetProductsByPriceQuery : QueryParameters, IRequest<PagedResponse<List<ProductGetDto>>>, ICachableQuery, IValidatable
    {
        public decimal Min { get; set; }
        public decimal Max { get; set; }

        public string CacheKey
        {
            get
            {
                return $"GetProductsByPrice&Min:{Min}&Max:{Max}&PageNumber{PageNumber}&PageSize{PageSize}";
            }
        }

        public double CacheTime
        {
            get
            {
                return 60;
            }
        }
    }
}
