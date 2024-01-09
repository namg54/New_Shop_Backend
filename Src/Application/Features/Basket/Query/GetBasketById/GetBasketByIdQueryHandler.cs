using Application.Interfaces;
using Domain.Entities.BasketEntity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Basket.Query.GetBasketById
{
    public class GetBasketByIdQueryHandler : IRequestHandler<GetBasketByIdQuery, CustomerBasket>
    {
        private readonly IBasketRepository _basketRepository;

        public GetBasketByIdQueryHandler(IBasketRepository basketRepository)
        {
            _basketRepository = basketRepository;
        }

        public async Task<CustomerBasket> Handle(GetBasketByIdQuery request, CancellationToken cancellationToken)
        {
            return await _basketRepository.GetBasketAsync(request.Id);
        }
    }
}
