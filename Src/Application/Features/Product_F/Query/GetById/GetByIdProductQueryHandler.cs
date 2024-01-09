using Application.Contracts;
using Application.Dtos.Products;
using Application.Features.Product_F.Query.GetAll;
using AutoMapper;
using Domain.Entities.ProductEntity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Product_F.Query.GetById
{
    public class GetByIdProductQueryHandler : IRequestHandler<GetByIdProductQuery, ProductDto>
    {
        private IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public GetByIdProductQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<ProductDto> Handle(GetByIdProductQuery request, CancellationToken cancellationToken)
        {
            var spec = new GetProductsSpec(request.Id);
            var result= await _uow.GenericRepository<Product>().GetEntityWithSpec(spec, cancellationToken);
            return _mapper.Map<ProductDto>(result);
            //var entity= await _uow.GenericRepository<Product>().GetByIdAsync(request.Id,cancellationToken);
            //TODO Handle Exception
            //if (entity == null) throw new Exception("error message with id");
            //return entity;
        }
    }
}
