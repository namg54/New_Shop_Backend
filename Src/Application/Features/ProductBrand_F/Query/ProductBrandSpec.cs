using Application.Contracts.Specification;
using Application.Features.Product_F.Query.GetAll;
using Application.Features.ProductBrand_F.Query.GetAll;
using Domain.Entities.ProductEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProductBrand_F.Query
{
    public class ProductBrandSpec : BaseSpecification<ProductBrand>
    {
        public ProductBrandSpec() { IsPagingEnable = false; }
        public ProductBrandSpec(int id) : base(x => x.Id == id)
        {
            IsPagingEnable = false;
        }
    }
}
