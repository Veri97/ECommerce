﻿using ECommerce.Core.Entities;

namespace ECommerce.Core.Specifications;

public class ProductsWithTypesAndBrandsSpecification : BaseSpecification<Product>
{
    public ProductsWithTypesAndBrandsSpecification(ProductSpecParams productParams)
        : base(criteria: x =>
             (string.IsNullOrEmpty(productParams.Name) || x.Name.ToLower().Contains(productParams.Name)) && 
             (!productParams.BrandId.HasValue || x.ProductBrandId == productParams.BrandId) &&
             (!productParams.TypeId.HasValue || x.ProductTypeId == productParams.TypeId)
          )
    {
        AddInclude(x => x.ProductType);
        AddInclude(x => x.ProductBrand);
        ApplyPaging(productParams.PageSize * (productParams.PageIndex - 1), productParams.PageSize);

        if (!string.IsNullOrEmpty(productParams.Sort))
        {
            switch (productParams.Sort)
            {
                case "priceAsc":
                    AddOrderBy(x => x.Price);
                    break;
                case "priceDesc":
                    AddOrderByDescending(x => x.Price);
                    break;
                default:
                    AddOrderBy(x => x.Name);
                    break;
            }
        }
        else
        {
            AddOrderBy(x => x.Name);
        }
    }

    public ProductsWithTypesAndBrandsSpecification(int id)
        : base(criteria: x => x.Id == id)
    {
        AddInclude(x => x.ProductType);
        AddInclude(x => x.ProductBrand);
    }
}
