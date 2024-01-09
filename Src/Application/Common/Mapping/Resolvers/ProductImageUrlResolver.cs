using Application.Dtos.Products;
using AutoMapper;
using AutoMapper.Execution;
using Domain.Entities.ProductEntity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Mapping.Resolvers
{
    public class ProductImageUrlResolver : IValueResolver<Product, ProductDto, string>
    {
        private readonly IConfiguration _configuration;

        public ProductImageUrlResolver(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string Resolve(Product source, ProductDto destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.PictureUrl))
                return _configuration["BackendUrl"]+ _configuration["LocationImages:ProductImageLocation"] + source.PictureUrl;
            return null;
        }
    }
}
