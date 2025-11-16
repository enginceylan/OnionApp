using AutoMapper;
using MediatR;
using OnionApp.Application.Interfaces.Repositories.Products;
using OnionApp.Application.Models.Dtos.Products;
using OnionApp.Application.Models.ResponseWrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApp.Application.Features.Products.Queries.GetProductById
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Response<ProductGetDto>>
    {
        private readonly IProductQueryRepository _productQueryRepository;
        private readonly IMapper _mapper;
        public GetProductByIdQueryHandler(IProductQueryRepository productQueryRepository, IMapper mapper)
        {
            _productQueryRepository = productQueryRepository;
            _mapper = mapper;
        }
        public async Task<Response<ProductGetDto>> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await _productQueryRepository.GetAsync(x => x.Id == request.Id);

            var dto = _mapper.Map<ProductGetDto>(product);

            var response = new Response<ProductGetDto>(dto,200);

            return response;
        }
    }
}
