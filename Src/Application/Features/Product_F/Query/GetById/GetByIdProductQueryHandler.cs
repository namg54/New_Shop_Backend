using Application.Contracts;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Product_F.Query.GetById
{
    public class GetByIdProductQueryHandler : IRequestHandler<GetByIdProductQuery, Product>
    {
        private IUnitOfWork _uow;
        public GetByIdProductQueryHandler(IUnitOfWork uow)
        {
            _uow=uow;
        }

        public async Task<Product> Handle(GetByIdProductQuery request, CancellationToken cancellationToken)
        {
            var entity= await _uow.GenericRepository<Product>().GetByIdAsync(request.Id,cancellationToken);
            //TODO Handle Exception
            if (entity == null) throw new Exception("error message with id");
            return entity;
        }
    }
}
