using Application.Contracts.Specification;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProductBrand_F.Query
{
    public class ProductBrandSpec : BaseSpecification<ProductBrand>
    {
        public ProductBrandSpec() { }
        public ProductBrandSpec(int id) : base(x => x.Id == id)
        {

        }
    }
}
