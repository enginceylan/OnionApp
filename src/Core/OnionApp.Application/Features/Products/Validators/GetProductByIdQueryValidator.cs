using FluentValidation;
using OnionApp.Application.Features.Products.Queries.GetProductById;

namespace OnionApp.Application.Features.Products.Validators
{
    public class GetProductByIdQueryValidator : AbstractValidator<GetProductByIdQuery>
    {
        public GetProductByIdQueryValidator()
        {

        }
    }
}
