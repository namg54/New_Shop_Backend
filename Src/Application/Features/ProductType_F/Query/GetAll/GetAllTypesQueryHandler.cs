using Application.Contracts;
using Domain.Entities.ProductEntity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProductType_F.Query.GetAll
{
    public class GetAllTypesQueryHandler : IRequestHandler<GetAllTypesQuery, IEnumerable<ProductType>>
    {
        private readonly IUnitOfWork _uow;
        public GetAllTypesQueryHandler(IUnitOfWork uow)
        {
            _uow=uow;
        }
        public async Task<IEnumerable<ProductType>> Handle(GetAllTypesQuery request, CancellationToken cancellationToken)
        {
            var spec = new ProductTypesSpec();
            return await _uow.GenericRepository<ProductType>().ListAsyncSpec(spec, cancellationToken);
            //return await _uow.GenericRepository<ProductType>().GetAllAsync(cancellationToken);
        }
    }
}
