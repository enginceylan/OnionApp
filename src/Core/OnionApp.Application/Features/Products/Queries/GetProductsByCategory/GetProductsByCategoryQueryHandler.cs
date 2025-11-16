using AutoMapper;
using MediatR;
using OnionApp.Application.Exceptions;
using OnionApp.Application.Interfaces.Repositories.Products;
using OnionApp.Application.Models.Dtos.Products;
using OnionApp.Application.Models.ResponseWrappers;

namespace OnionApp.Application.Features.Products.Queries.GetProductsByCategory
{
    public class GetProductsByCategoryQueryHandler : IRequestHandler<GetProductsByCategoryQuery, PagedResponse<List<ProductGetDto>>>
    {
        private readonly IProductQueryRepository _productQueryRepository;
        private readonly IMapper _mapper;
        public GetProductsByCategoryQueryHandler(IProductQueryRepository productQueryRepository, IMapper mapper)
        {
            _productQueryRepository = productQueryRepository;
            _mapper = mapper;
        }
        public async Task<PagedResponse<List<ProductGetDto>>> Handle(GetProductsByCategoryQuery request, CancellationToken cancellationToken)
        {
            #region GetListAsync
            //try
            //{
            //    var query = await
            //            _productQueryRepository.GetListAsync(
            //                 filter: x => x.CategoryId == request.CategoryId,
            //                 includes: "Category"
            //            );

            //    var mapped = _mapper.Map<List<ProductGetDto>>(query);

            //    var response = new Response<List<ProductGetDto>>(mapped.ToList(), 200);

            //    return response;
            //}
            //catch (Exception ex)
            //{
            //    return new Response<List<ProductGetDto>>(ex.Message, 500);
            //} 
            #endregion

            if (request.CategoryId <= 0)
                throw new BadRequestException("CategoryId'si 0'dan büyük olmalıdır");
           
                var query = await
                        _productQueryRepository.GetPagedListAsync(
                             filter: x => x.CategoryId == request.CategoryId,
                             includes: "Category",
                             pageNumber:request.PageNumber,
                             pageSize:request.PageSize
                        );

                var mapped = _mapper.Map<List<ProductGetDto>>(query.Items);

                var response = new PagedResponse<List<ProductGetDto>>(
                    data:mapped.ToList(),
                    count: query.TotalCount,
                    pageNumber: request.PageNumber,
                    pageSize: request.PageSize);

                return response;
           
        }
    }
}
