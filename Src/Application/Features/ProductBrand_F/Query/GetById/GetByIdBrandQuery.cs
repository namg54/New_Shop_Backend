using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProductBrand_F.Query.GetById
{
    public class GetByIdBrandQuery:IRequest<ProductBrand>
    {
        public int Id { get; set; }
    }
}
