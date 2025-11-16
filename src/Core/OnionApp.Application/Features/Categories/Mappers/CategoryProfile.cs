using AutoMapper;
using OnionApp.Application.Models.Dtos.Categories;
using OnionApp.Domain.Entities;

namespace OnionApp.Application.Features.Categories.Mappers
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryGetDto>();
        }
    }
}
