using Application.Interfaces;
using Domain.Entities.BasketEntity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Basket.Command.UpdateBasket
{
    public class UpdateBasketCommandHandler : IRequestHandler<UpdateBasketCommand, CustomerBasket>
    {
        private readonly IBasketRepository _basket;

        public UpdateBasketCommandHandler(IBasketRepository basket)
        {
            _basket = basket;
        }

        public async Task<CustomerBasket> Handle(UpdateBasketCommand request, CancellationToken cancellationToken)
        {
            return await _basket.UpdateBasketAsync(request.customerBasket);
        }
    }
}
