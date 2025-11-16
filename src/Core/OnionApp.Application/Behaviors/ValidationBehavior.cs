using FluentValidation;
using MediatR;
using OnionApp.Application.Interfaces.Validation;

namespace OnionApp.Application.Behaviors
{
    // BU sınıfın (behavior'ın) amacı, mediatr'nin tetiklediği Handle metodu içine girilmeden hemen önce burasının çalışıp, Handle ile alakalı request nesnesinin validasyonun yapılmasıdır. Validasyon fluentvalidatioın kütüophanesine yaptırılacaktır. 
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IValidatable
    {
        private readonly IValidator<TRequest> _validator;

        public ValidationBehavior(IValidator<TRequest> validator)
        {
            _validator = validator;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (_validator == null)
                return await next();
            else
            {
                var context = new ValidationContext<TRequest>(request);

                // bu request ile ilişkili tğüm validator sınıflarındaki Validate metodunu çalıştır. Bu metoda da request nesnensini barındıran context nesnesini parametre olarak ver
                var validationResult = _validator.Validate(context);

                var errorList = validationResult.Errors
                                                 .Where(x => x != null)
                                                 .ToList();

                if (errorList.Any()) // eğer en az 1 hata varsa
                    throw new ValidationException(errorList);

                return await next();
            }
        }
    }
}
