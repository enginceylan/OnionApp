using AutoMapper;
using MediatR;
using OnionApp.Application.Exceptions;
using OnionApp.Application.Interfaces.Repositories.Products;
using OnionApp.Application.Models.Dtos.Products;
using OnionApp.Application.Models.ResponseWrappers;

namespace OnionApp.Application.Features.Products.Queries.GetProductsByPrice
{
    public class GetProductsByPriceQueryHandler : IRequestHandler<GetProductsByPriceQuery, PagedResponse<List<ProductGetDto>>>
    {
        private readonly IProductQueryRepository _productQueryRepository;
        private readonly IMapper _mapper;
        public GetProductsByPriceQueryHandler(IProductQueryRepository productQueryRepository, IMapper mapper)
        {
            _productQueryRepository = productQueryRepository;
            _mapper = mapper;
        }
        public async Task<PagedResponse<List<ProductGetDto>>> Handle(GetProductsByPriceQuery request, CancellationToken cancellationToken)
        {
            var query =
                    await _productQueryRepository.GetByPricePagedAsync(
                        min: request.Min,
                        max: request.Max,
                        includes: "Category",
                        pageNumber: request.PageNumber,
                        pageSize: request.PageSize);

            if (query.Items.Count() == 0)
                throw new NotFoundException("Vediğiniz değerlere uygun kayıt bulunamadı");


            var mapped = _mapper.Map<List<ProductGetDto>>(query.Items.OrderBy(x => x.UnitPrice));

            var response = new PagedResponse<List<ProductGetDto>>(
                data: mapped,
                count: query.TotalCount,
                pageNumber: request.PageNumber,
                pageSize: request.PageSize);

            return response;

        }
    }
}
