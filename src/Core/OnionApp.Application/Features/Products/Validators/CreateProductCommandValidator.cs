using FluentValidation;
using OnionApp.Application.Features.Products.Commands.CreateProduct;

namespace OnionApp.Application.Features.Products.Validators
{
    public class CreateProductCommandValidator: AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(x => x.ProductName)
                .NotEmpty()
                .WithMessage("Ürün Adı Boş Bırakılamaz")
                .MinimumLength(2)
                .WithMessage("Ürün adı en az 2 karakterden oluşmalıdır");

            RuleFor(x => x.UnitPrice)
                .GreaterThan(0)
                .WithMessage("Ürün fiyatı 0 dan büyük olmalıdır");

            RuleFor(x => x.UnitsInStock)
                .GreaterThan((short)0)
                .WithMessage("Ürün stoğu 0 dan büyük olmalıdır");

            RuleFor(x => x.CategoryId)
                .GreaterThan(0)
                .WithMessage("CategoryId 0 dan büyük olmalıdır");
        }
    }
}
