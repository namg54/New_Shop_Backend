using Application.Contracts;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProductBrand_F.Query.GetAll
{
    public class GetAllBrandQueryHandler : IRequestHandler<GetAllBrandQuery,IEnumerable<ProductBrand>>
    {
        private readonly IUnitOfWork _uow;
        public GetAllBrandQueryHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<IEnumerable<ProductBrand>> Handle(GetAllBrandQuery request,
            CancellationToken cancellationToken)
        {
            var spec = new ProductBrandSpec();
            return await _uow.GenericRepository<ProductBrand>().ListAsyncSpec(spec, cancellationToken);
            //return await _uow.GenericRepository<ProductBrand>().GetAllAsync(cancellationToken);
        }
    }
}
