using AutoMapper;
using ECommerce.API.DTOs;
using ECommerce.API.Exceptions;
using ECommerce.API.Helpers;
using ECommerce.Application.Services;
using ECommerce.Core.Entities;
using ECommerce.Core.Interfaces;
using ECommerce.Core.Specifications;

namespace ECommerce.API.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IGenericRepository<Product> _productRepo;
        private readonly IGenericRepository<ProductBrand> _productBrandRepo;
        private readonly IGenericRepository<ProductType> _productTypeRepo;
        private readonly IMapper _mapper;
        public ProductService(
            IGenericRepository<Product> productRepo,
            IGenericRepository<ProductBrand> productBrandRepo, 
            IGenericRepository<ProductType> productTypeRepo,
            IMapper mapper)
        {
            _productRepo = productRepo;
            _productBrandRepo = productBrandRepo;
            _productTypeRepo = productTypeRepo;
            _mapper = mapper;
        }

        public async Task<ProductToReturnDTO> GetProductByIdAsync(int id)
        {
            var spec = new ProductsWithTypesAndBrandsSpecification(id);
            
            var product = await _productRepo.GetEntityWithSpecAsync(spec);

            if (product is null)
                throw new NotFoundException("Product not found!");

            return _mapper.Map<Product, ProductToReturnDTO>(product);
        }

        public async Task<PagedResponse<ProductToReturnDTO>> GetAllProductsAsync(ProductSpecParams productParams)
        {
            var spec = new ProductsWithTypesAndBrandsSpecification(productParams);
            var countSpec = new ProductsWithFiltersForCountSpecification(productParams);

            var totalItems = await _productRepo.CountAsync(countSpec);
            var products = await _productRepo.ListAllWithSpecAsync(spec);

            var data = _mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductToReturnDTO>>(products);

            return new PagedResponse<ProductToReturnDTO>(productParams.PageIndex,productParams.PageSize,totalItems,data);
        }

        public async Task<IReadOnlyList<ProductType>> GetAllProductTypesAsync()
        {
            return await _productTypeRepo.ListAllAsync();
        }

        public async Task<IReadOnlyList<ProductBrand>> GetAllProductBrandsAsync()
        {
            return await _productBrandRepo.ListAllAsync();
        }
    }
}
