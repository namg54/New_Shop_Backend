using Domain.Entities.BasketEntity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Basket.Query.GetBasketById
{
    public class GetBasketByIdQuery: IRequest<CustomerBasket>
    {
        public GetBasketByIdQuery(string id)
        {
            Id = id;
        }
        public string Id { get; set; }
    }
}
