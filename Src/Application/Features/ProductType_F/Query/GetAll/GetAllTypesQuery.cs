using Domain.Entities.ProductEntity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProductType_F.Query.GetAll
{
    public class GetAllTypesQuery:IRequest<IEnumerable<ProductType>>
    {
    }
}
