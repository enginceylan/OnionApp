using FluentValidation;
using OnionApp.Application.Features.Auth.Commands.GetAccessToken;

namespace OnionApp.Application.Features.Auth.Validators
{
    public class AccessTokenCommandValidator : AbstractValidator<AccessTokenCommand>
    {
        public AccessTokenCommandValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("Email Boş Bırakılamaz")
                .EmailAddress()
                .WithMessage("Email geçerli formata sahip olamlıdır");

            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("Şifre Boş Bırakılamaz");
        }
    }
}
