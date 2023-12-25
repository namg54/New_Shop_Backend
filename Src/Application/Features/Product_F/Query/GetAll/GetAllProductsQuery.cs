using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Product_F.Query.GetAll
{
    public class GetAllProductsQuery : IRequest<IEnumerable<Product>>
    {
        public int PageId { get; set; }
    }
}
