using Application.Contracts;
using Application.Dtos.Products;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities.ProductEntity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Product_F.Query.GetAll
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, PaginationResponse<ProductDto>>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        public GetAllProductsQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<PaginationResponse<ProductDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var spec = new GetProductsSpec(request);
            var count = await _uow.GenericRepository<Product>().CountAsuncSpec(new ProductsCountSpec(request), cancellationToken);
            var result = await _uow.GenericRepository<Product>().ListAsyncSpec(spec, cancellationToken);
            if (result == null) throw new DllNotFoundException();
            var model=_mapper.Map<IEnumerable<ProductDto>>(result);
            return new PaginationResponse<ProductDto>(request.PageIndex, request.PageSize, count, model);
            //return _mapper.Map<IEnumerable<ProductDto>>(result);
        }
    }
}
