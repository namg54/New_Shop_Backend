using Domain.Entities.ProductEntity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProductBrand_F.Query.GetAll
{
    public class GetAllBrandQuery:IRequest<IEnumerable<ProductBrand>>
    {
    }
}
