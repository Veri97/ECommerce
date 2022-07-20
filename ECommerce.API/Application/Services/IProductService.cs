using ECommerce.API.DTOs;
using ECommerce.API.Helpers;
using ECommerce.Core.Entities;
using ECommerce.Core.Specifications;

namespace ECommerce.Application.Services;

public interface IProductService
{
    Task<PagedResponse<ProductToReturnDTO>> GetAllProductsAsync(ProductSpecParams productParams);
    Task<ProductToReturnDTO> GetProductByIdAsync(int id);
    Task<IReadOnlyList<ProductBrand>> GetAllProductBrandsAsync();
    Task<IReadOnlyList<ProductType>> GetAllProductTypesAsync();
}
