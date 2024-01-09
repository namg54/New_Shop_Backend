using Domain.Entities.BasketEntity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Basket.Command.UpdateBasket
{
    public class UpdateBasketCommand : IRequest<CustomerBasket>
    {
        public UpdateBasketCommand(CustomerBasket CustomerBasket)
        {
            _customerBasket = CustomerBasket;
        }
        public CustomerBasket _customerBasket { get; set; }

    }
}
