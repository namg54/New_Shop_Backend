using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Product_F.Query.GetById
{
    public class GetByIdProductQuery:IRequest<Product>
    {
        public int Id { get; set; }
        public GetByIdProductQuery(int id)
        {
            Id = id;            
        }
    }
}
