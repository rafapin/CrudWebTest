using CrudTestWeb.Shared.Domain.Definitions;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CrudTestWeb.Shared.Domain.Contracts
{
    public interface IRepository<TAggregate> where TAggregate : Aggregate
    {
        Task Commit();
        Task AddAsync(TAggregate aggregate);
        Task UpdateAsync(TAggregate aggregate);
        Task SaveAsync(TAggregate aggregate);
        Task DeleteAsync(TAggregate aggregate);
        Task<TAggregate> GetByIdAsync(string id);
        Task<IEnumerable<TAggregate>> GetAllAsync();
        Task<IEnumerable<TAggregate>> GetAsync(Expression<Func<TAggregate, bool>> predicate);
    }
}
