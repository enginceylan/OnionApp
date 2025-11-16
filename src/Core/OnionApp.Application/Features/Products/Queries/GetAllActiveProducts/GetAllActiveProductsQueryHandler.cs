using AutoMapper;
using MediatR;
using OnionApp.Application.Interfaces.Repositories.Products;
using OnionApp.Application.Models.Dtos.Products;
using OnionApp.Application.Models.ResponseWrappers;

namespace OnionApp.Application.Features.Products.Queries.GetAllActiveProducts
{
    public class GetAllActiveProductsQueryHandler : IRequestHandler<GetAllActiveProductsQuery, Response<List<ProductGetDto>>>
    {
        private readonly IProductQueryRepository _productQueryRepository;
        private readonly IMapper _mapper;
        public GetAllActiveProductsQueryHandler(IProductQueryRepository productQueryRepository, IMapper mapper)
        {
            _productQueryRepository = productQueryRepository;
            _mapper = mapper;
        }

        public async Task<Response<List<ProductGetDto>>> Handle(GetAllActiveProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _productQueryRepository.GetListAsync(includes: "Category");

            var mapped = _mapper.Map<List<ProductGetDto>>(products);

            var response = new Response<List<ProductGetDto>>(mapped,200);

            return response;
        }
    }
}
