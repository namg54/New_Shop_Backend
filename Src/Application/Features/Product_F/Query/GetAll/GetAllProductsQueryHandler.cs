using Application.Contracts;
using Application.Dtos.Products;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Product_F.Query.GetAll
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<ProductDto>>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        public GetAllProductsQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            //LOGIC
            var spec = new GetProductsSpec();
            var result= await _uow.GenericRepository<Product>().ListAsyncSpec(spec, cancellationToken);
            return _mapper.Map<IEnumerable<ProductDto>>(result);
            //return await _uow.GenericRepository<Product>().GetAllAsync(cancellationToken);
        }
    }
}
