using Application.Features.ProductBrand_F.Query.GetAll;
using Application.Features.ProductBrand_F.Query.GetById;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Web_shop.Common;

namespace Web_shop.Controllers
{
    public class ProductBrandController : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductBrand>>> GetAll(CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetAllBrandQuery(), cancellationToken));
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProductBrand>> GetByIdBrands(int id,CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetByIdBrandQuery() { Id = id }, cancellationToken));
        }
    }
}
