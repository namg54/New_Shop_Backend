using Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts
{
    public interface IGenericRepository<T> where T:BaseEntity
    {
        Task<T> GetByIdAsync(int id,CancellationToken cancellationToken);
        Task<IReadOnlyList<T>> GetAllAsync(CancellationToken cancellationToken);
        Task<T> AddAsync(T entity, CancellationToken cancellationToken);
        Task<T> UpdateAsync(T entity);
        void DeleteAsync(T entity, CancellationToken cancellationToken);
        Task<bool> AnyAsync(Expression<Func<T,bool>> expression,CancellationToken cancellationToken);
        Task<bool> AnyAsync(CancellationToken cancellationToken);
    }
}
