using MediatR;
using OnionApp.Application.Interfaces.Validation;
using OnionApp.Application.Models.Dtos.Products;
using OnionApp.Application.Models.ResponseWrappers;

namespace OnionApp.Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductCommand:IRequest<Response<ProductGetDto>>, IValidatable
    {
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public short UnitsInStock { get; set; }
        public int CategoryId { get; set; }
    }
}
