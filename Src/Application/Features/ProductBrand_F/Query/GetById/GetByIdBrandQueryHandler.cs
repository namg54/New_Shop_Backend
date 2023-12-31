﻿using Application.Contracts;
using Application.Dtos.Products;
using Application.Features.Product_F.Query;
using Application.Features.ProductBrand_F.Query.GetAll;
using Domain.Entities.ProductEntity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProductBrand_F.Query.GetById
{
    public class GetByIdBrandQueryHandler : IRequestHandler<GetByIdBrandQuery, ProductBrand>
    {
        private readonly IUnitOfWork _uow;
        public GetByIdBrandQueryHandler(IUnitOfWork uow)
        {
            _uow=uow;
        }

        public async Task<ProductBrand> Handle(GetByIdBrandQuery request, CancellationToken cancellationToken)
        {
            var spec = new ProductBrandSpec(request.Id);
            return await _uow.GenericRepository<ProductBrand>().GetEntityWithSpec(spec, cancellationToken);

        }
    }
}
