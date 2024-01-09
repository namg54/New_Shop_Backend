using Application.Features.Basket.Command.DeleteBasket;
using Application.Features.Basket.Command.UpdateBasket;
using Application.Features.Basket.Query.GetBasketById;
using Domain.Entities.BasketEntity;
using Microsoft.AspNetCore.Mvc;
using Web_shop.Common;

namespace Web_shop.Controllers
{
    public class BasketController : BaseApiController
    {
        [HttpGet("{basketId:string}")]
        public async Task<ActionResult<CustomerBasket>> GetBasketById([FromRoute] string basketId,CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetBasketByIdQuery(basketId),cancellationToken));
        }
        [HttpPost]
        public async Task<ActionResult<CustomerBasket>> UpdateBasket([FromBody] CustomerBasket basket,CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new UpdateBasketCommand(basket),cancellationToken));
        }

        [HttpDelete("basketId:int")]
        public async Task<ActionResult<bool>> DeleteBasket([FromRoute] string basketId,CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new DeleteBasketCommand(basketId),cancellationToken));
        }
    }
}
