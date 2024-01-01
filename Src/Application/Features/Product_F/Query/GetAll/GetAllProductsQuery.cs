using Application.Contracts;
using Application.Dtos.Products;
using Application.Wrappers;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Product_F.Query.GetAll
{
    public class GetAllProductsQuery : ReequestParametersBasic, IRequest<PaginationResponse<ProductDto>>, ICacheQuery
    {
        //public int PageId { get; set; }
        public int? BrandId { get; set; }
        public int? TypeId { get; set; }
        //TODO
        public int HoursSaveData => 48;//save cache data
        //test
    }
}
