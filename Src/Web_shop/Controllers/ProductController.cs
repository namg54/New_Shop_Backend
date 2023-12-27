using Application.Dtos.Products;
using Application.Features.Product_F.Query.GetAll;
using Application.Features.Product_F.Query.GetById;
using Application.Features.ProductBrand_F.Query.GetAll;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Web_shop.Common;

namespace Web_shop.Controllers
{
    public class ProductController : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> Get(CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetAllProductsQuery(), cancellationToken));
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProductDto>> GetById([FromRoute] int id, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetByIdProductQuery(id), cancellationToken));
        }
    }
}
