using Application.Contracts.Specification;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Product_F.Query
{
    public class GetProductsSpec : BaseSpecification<Product>
    {
        public GetProductsSpec() : base()
        {
            AddInclude();
        }
        public GetProductsSpec(int id) : base(x => x.Id == id)
        {
            AddInclude();
        }

        private void AddInclude()
        {
            AddInclude(x => x.productBrand);
            AddInclude(x => x.productType);
        }
    }
}
