using Application.Contracts.Specification;
using Domain.Entities.ProductEntity;
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
            IsPagingEnable = false;
        }
        public ProductTypesSpec(int id) : base(x => x.Id == id)
        {
            IsPagingEnable = false;
        }
    }
}
