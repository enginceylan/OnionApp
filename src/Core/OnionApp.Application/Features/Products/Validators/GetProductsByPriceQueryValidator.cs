using FluentValidation;
using OnionApp.Application.Features.Products.Queries.GetProductsByPrice;

namespace OnionApp.Application.Features.Products.Validators
{
    public class GetProductsByPriceQueryValidator:AbstractValidator<GetProductsByPriceQuery>
    {
        public GetProductsByPriceQueryValidator()
        {
            RuleFor(x => x.Min)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Min değer 0 ya da 0 dan büyük olmalıdır")
                .LessThan(x => x.Max)
                .WithMessage("Min değeri Max değerinden küçük olmalıdır");

            RuleFor(x => x.Max)
                .GreaterThan(0)
                .WithMessage("Max değer 0 dan büyük olmalıdır")
                .GreaterThan(x => x.Min)
                .WithMessage("Max değeri, Min değerinden büyük olmalıdır");

            RuleFor(x => x.PageNumber)
                .GreaterThan(0)
                .WithMessage("PageNumber 0 dan büyük olmalıdır");

        }
    }
}
