using AutoMapper;
using OnionApp.Application.Models.Dtos.Products;
using OnionApp.Domain.Entities;

namespace OnionApp.Application.Features.Products.Mappers
{
    public class ProductProfile:Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductGetDto>().ForMember(x => x.CategoryName, opt => opt.MapFrom(src => src.Category.CategoryName));
        }
    }
}
