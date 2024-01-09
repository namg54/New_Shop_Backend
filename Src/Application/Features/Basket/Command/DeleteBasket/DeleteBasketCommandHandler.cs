using Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Basket.Command.DeleteBasket
{
    public class DeleteBasketCommandHandler : IRequestHandler<DeleteBasketCommand, bool>
    {
        private readonly IBasketRepository _basket;

        public DeleteBasketCommandHandler(IBasketRepository basket)
        {
            _basket = basket;
        }

        public async Task<bool> Handle(DeleteBasketCommand request, CancellationToken cancellationToken)
        {
            return await _basket.DeleteBasketAsync(request.Id);
        }
    }
}
