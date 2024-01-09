using Application.Features.ProductBrand_F.Query.GetById;
using Application.Features.ProductType_F.Query.GetAll;
using Application.Features.ProductType_F.Query.GetById;
using Domain.Entities.ProductEntity;
using Microsoft.AspNetCore.Mvc;
using Web_shop.Common;

namespace Web_shop.Controllers
{
    public class ProductTypesController : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductType>>> GetAllTypes(CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetAllTypesQuery()));
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProductType>> GetByIdBrand(int id,CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetByIdTypesQuery() { Id=id},cancellationToken));
        }
     
    }
}
