using AutoMapper;
using ECommerce.API.DTOs;
using ECommerce.Core.Entities;

namespace ECommerce.API.Helpers
{
    public class ProductUrlResolver : IValueResolver<Product, ProductToReturnDTO, string>
    {
        private readonly IConfiguration _config;
        public ProductUrlResolver(IConfiguration config) =>
            _config = config;

        public string Resolve(Product source, ProductToReturnDTO destination,string destMember,
            ResolutionContext context) =>
         !string.IsNullOrEmpty(source.PictureUrl) ? (_config["ApiUrl"] + source.PictureUrl) : null;
    }
}
