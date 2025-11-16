using AutoMapper;
using MediatR;
using OnionApp.Application.Interfaces.InMemoryCache;
using OnionApp.Application.Interfaces.Repositories.Products;
using OnionApp.Application.Models.Dtos.Products;
using OnionApp.Application.Models.ResponseWrappers;
using OnionApp.Domain.Entities;

namespace OnionApp.Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Response<ProductGetDto>>
    {
        private readonly IProductCommandRepository _productCommandRepository;
        private readonly IMapper _mapper;
        private readonly ICacheService _cacheService;
        public CreateProductCommandHandler(IProductCommandRepository productCommandRepository, IMapper mapper, ICacheService cacheService)
        {
            _productCommandRepository = productCommandRepository;
            _mapper = mapper;
            _cacheService = cacheService;
        }
        public async Task<Response<ProductGetDto>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product()
            {
                CategoryId = request.CategoryId,
                ProductName = request.ProductName,
                UnitPrice = request.UnitPrice,
                UnitsInStock = request.UnitsInStock
            };

            await _productCommandRepository.AddAsync(product);

            var mapped = _mapper.Map<ProductGetDto>(product);

            var response = new Response<ProductGetDto>(mapped, 200);

            #region GetAllActiveProducts isimli cache'in tazelenmesi

            var cachedProducts = _cacheService.Get<Response<List<ProductGetDto>>>("GetAllActiveProducts");

            if(cachedProducts != null)
            {
                cachedProducts.Data.Add(mapped);

                _cacheService.Set("GetAllActiveProducts", cachedProducts, TimeSpan.FromMinutes(5));
            }

            #endregion

            return response;
        }
    }
}
