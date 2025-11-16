using OnionApp.Application.Exceptions;

namespace OnionApp.Application.Features.Products.Exceptions
{
    public class PriceCannotBeNegativeException:BadRequestException
    {
        public PriceCannotBeNegativeException():base("Ürün fiyatı 0 dan büyük olmalıdır")
        {
            
        }
    }
}
