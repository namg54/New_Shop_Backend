using Application.Features.Product_F.Query.GetAll;
using Application.Features.Product_F.Query.GetById;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Web_shop.Common;

namespace Web_shop.Controllers
{
    public class ProductController : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> Get(CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetAllProductsQuery(), cancellationToken));
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Product>> GetById([FromRoute] int id, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetByIdProductQuery(id), cancellationToken));
        }
    }
}
