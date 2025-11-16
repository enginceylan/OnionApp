using MediatR;
using OnionApp.Application.Interfaces.Validation;
using OnionApp.Application.Models.Dtos.Products;
using OnionApp.Application.Models.Parameters;
using OnionApp.Application.Models.ResponseWrappers;

namespace OnionApp.Application.Features.Products.Queries.GetProductsByCategory
{
    public class GetProductsByCategoryQuery: QueryParameters,IRequest<PagedResponse<List<ProductGetDto>>>, IValidatable
    {
        public int CategoryId { get; set; }
        
    }
}
