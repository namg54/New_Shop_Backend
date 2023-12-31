using Application.Contracts.Specification;
using Application.Features.Product_F.Query.GetAll;
using Application.Wrappers;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Product_F.Query
{
    public class GetProductsSpec : BaseSpecification<Product>
    {
        public GetProductsSpec(GetAllProductsQuery specParams) : base(Expression.ExpressionSpec(specParams))
        {
            AddInclude();
            if (specParams.TypeSort == TypeSort.Desc)
            {
                switch (specParams.Sort)
                {
                    case 1:
                        AddOrderByDesc(x => x.Title);
                        break;
                    case 2:
                        AddOrderByDesc(x => x.LastModified);
                        break;
                    case 3:
                        AddOrderByDesc(x => x.productType.Title);
                        break;
                    default:
                        AddOrderByDesc(x => x.Price);
                        break;
                }
            }
            else
            {
                switch (specParams.Sort)
                {
                    case 1:
                        AddOrderBy(x => x.Title);
                        break;
                    case 2:
                        AddOrderBy(x => x.LastModified);
                        break;
                    case 3:
                        AddOrderBy(x => x.productType.Title);
                        break;
                    default:
                        AddOrderBy(x => x.Price);
                        break;
                }
            }
            ApplyPagin(specParams.PageSize * (specParams.PageIndex - 1), specParams.PageSize, true);

        }
        public GetProductsSpec(int id) : base(x => x.Id == id)
        {
            AddInclude();
        }
        private void AddInclude()
        {
            AddInclude(x => x.productBrand);
            AddInclude(x => x.productType);
        }
    }
    public class ProductsCountSpec:BaseSpecification<Product>
    {
        public ProductsCountSpec(GetAllProductsQuery specParams) : base(Expression.ExpressionSpec(specParams))
        {
            IsPagingEnable = false;
        }
    }
    public static class Expression
    {
        public static Expression<Func<Product, bool>> ExpressionSpec(GetAllProductsQuery specParams)
        {
            return x =>
                        (!specParams.BrandId.HasValue || x.ProductBrandId == specParams.BrandId)
                        &&
                        (!specParams.TypeId.HasValue || x.ProductTypeId == specParams.TypeId)
                        &&
                        (string.IsNullOrEmpty(specParams.search) || x.Title.ToLower().Contains(specParams.search));
        }
    }
}
