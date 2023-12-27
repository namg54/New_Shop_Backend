using Application.Contracts.Specification;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProductType_F.Query
{
    public class ProductTypesSpec : BaseSpecification<ProductType>
    {
        public ProductTypesSpec()
        {

        }
        public ProductTypesSpec(int id) : base(x => x.Id == id)
        {

        }
    }
}
