using Application.Contracts;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProductType_F.Query.GetById
{
    public class GetByIdTypesQueryHandler : IRequestHandler<GetByIdTypesQuery, ProductType>
    {
        private readonly IUnitOfWork _uow;
        public GetByIdTypesQueryHandler(IUnitOfWork uow)
        {
            _uow=uow;
        }

        public async Task<ProductType> Handle(GetByIdTypesQuery request, CancellationToken cancellationToken)
        {
            var spec = new ProductTypesSpec(request.Id);
            return await _uow.GenericRepository<ProductType>().GetEntityWithSpec(spec, cancellationToken);
            //var entity = await _uow.GenericRepository<ProductType>().GetByIdAsync(request.Id, cancellationToken);
            //if (entity == null) throw new Exception("Entity Is Null");
            //return entity;
        }
    }
}
