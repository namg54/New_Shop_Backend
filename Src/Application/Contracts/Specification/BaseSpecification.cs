using Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.Specification
{
    public class BaseSpecification<T> : ISpecification<T> where T : BaseEntity
    {
        public Expression<Func<T, bool>> Predicate { get; }

        public List<Expression<Func<T, object>>> Include { get; } = new();

        public Expression<Func<T, object>> OrderBy { get; private set; }

        public Expression<Func<T, object>> OrderByDesc { get; private set; }

        public int Take { get; set; }

        public int Skip{ get; set; }

        public bool IsPagingEnable { get; set; } = true;

        public BaseSpecification()
        {

        }
        public BaseSpecification(Expression<Func<T, bool>> predicate)
        {
            Predicate = predicate;
        }
        protected void AddInclude(Expression<Func<T, object>> include)
        {
            Include.Add(include);
        }

        protected void AddOrderBy(Expression<Func<T, object>> OrderByExprssion)
        {
            OrderBy = OrderByExprssion;
        }
        protected void AddOrderByDesc(Expression<Func<T, object>> OrderByDescExprssion)
        {
            OrderByDesc = OrderByDescExprssion;
        }

        protected void ApplyPagin(int skip,int take,bool ispagingEnable)
        {
            Skip = skip;
            Take = take;
            IsPagingEnable = ispagingEnable;
        }
    }
}
