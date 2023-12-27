using Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.Specification
{
    public interface ISpecification<T> where T:BaseEntity
    {
        Expression<Func<T,bool>> Predicate { get; }

        List<Expression<Func<T,object>>> Include { get; }

    }
}
