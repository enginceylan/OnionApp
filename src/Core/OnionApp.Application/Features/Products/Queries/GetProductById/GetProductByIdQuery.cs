using MediatR;
using OnionApp.Application.Interfaces.Validation;
using OnionApp.Application.Models.Dtos.Products;
using OnionApp.Application.Models.ResponseWrappers;

namespace OnionApp.Application.Features.Products.Queries.GetProductById
{
    public class GetProductByIdQuery: IRequest<Response<ProductGetDto>>, IValidatable
    {
        public int Id { get; set; }
    }
}
