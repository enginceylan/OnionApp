using OnionApp.Application.Exceptions;

namespace OnionApp.Application.Features.Products.Exceptions
{
    public class PricesCannotBeEqualException:BadRequestException
    {
        public PricesCannotBeEqualException():base("Min ve max fiyatlar eşit olamaz")
        {
                
        }
    }
}
