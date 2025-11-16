using AutoMapper;
using MediatR;
using OnionApp.Application.Interfaces.Repositories.Categories;
using OnionApp.Application.Models.Dtos.Categories;
using OnionApp.Application.Models.ResponseWrappers;

namespace OnionApp.Application.Features.Categories.Queries.GetAllActiveCategories
{
    public class GetAllActiveCategoriesQueryHandler : IRequestHandler<GetAllActiveCategoriesQuery, Response<List<CategoryGetDto>>>
    {
        private readonly ICategoryQueryRepository _categoryQueryRepository;
        private readonly IMapper _mapper;
        public GetAllActiveCategoriesQueryHandler(ICategoryQueryRepository categoryQueryRepository, IMapper mapper)
        {
            _categoryQueryRepository = categoryQueryRepository;
            _mapper = mapper;
        }

        public async Task<Response<List<CategoryGetDto>>> Handle(GetAllActiveCategoriesQuery request, CancellationToken cancellationToken)
        {
            var categories = await _categoryQueryRepository.GetListAsync();

            var mapped = _mapper.Map<List<CategoryGetDto>>(categories);

            var response = new Response<List<CategoryGetDto>>(mapped, 200);

            return response;
        }
    }
}
