using FluentValidation;
using OnionApp.Application.Features.Products.Queries.GetProductsByCategory;

namespace OnionApp.Application.Features.Products.Validators
{
    public class GetProductsByCategoryQueryValidator:AbstractValidator<GetProductsByCategoryQuery>
    {
        public GetProductsByCategoryQueryValidator()
        {
                
        }
    }
}
