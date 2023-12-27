using Application.Common.Mapping;
using Application.Common.Mapping.Resolvers;
using Application.Dtos.Common;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.Products
{
    public class ProductDto : CommandDto, IMapFrom<Product>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Decimal Price { get; set; }
        public string PictureUrl { get; set; }
        public int ProductTypeId { get; set; }
        public int ProductBrandId { get; set; }
        public string productBrand { get; set; }//title
        public string productType { get; set; }//title

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Product, ProductDto>()
                .ForMember(x=>x.PictureUrl,c=>c.MapFrom<ProductImageUrlResolver>())
                .ForMember(x => x.productType, c => c.MapFrom(c => c.productType.Title))
                .ForMember(x=>x.productBrand,c=>c.MapFrom(c=>c.Title));
        }
    }
}
