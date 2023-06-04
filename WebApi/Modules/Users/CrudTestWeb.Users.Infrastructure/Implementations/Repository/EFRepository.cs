using CrudTestWeb.Shared.Domain.Contracts;
using CrudTestWeb.Shared.Domain.Definitions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;
using System.Text.Json;

namespace CrudTestWeb.Users.Infrastructure.Implementations.Repository
{
    public class EFRepository<TAggregate> : IRepository<TAggregate> where TAggregate : Aggregate
    {
        protected readonly CrudTestWebContext _context;
        public EFRepository(CrudTestWebContext context) => _context = context;


        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }


        public async Task AddAsync(TAggregate aggregate)
        {
            aggregate.CreateDate = aggregate.LastUpdateDate = DateTime.UtcNow;
            await _context.Set<TAggregate>().AddAsync(aggregate);
        }

        public Task UpdateAsync(TAggregate aggregate)
        {
            aggregate.CreateDate = aggregate.LastUpdateDate = DateTime.UtcNow;
            _context.Set<TAggregate>().Update(aggregate);
            return Task.CompletedTask;
        }

        public async Task SaveAsync(TAggregate aggregate)
        {
            if (string.IsNullOrEmpty(aggregate.Id))
            {
                aggregate.Id = Guid.NewGuid().ToString();
                await AddAsync(aggregate);
            }
            else
                await UpdateAsync(aggregate);
            var events = new List<Event>();
            foreach(var @event in aggregate.DomainEvents)
            {
                events.Add(new Event
                {
                    Id = @event.id,
                    AggregateId = aggregate.Id,
                    EventName = @event.GetType().FullName,
                    EventSerialize = JsonSerializer.Serialize(@event, @event.GetType()),
                    DateOcurred = DateTime.UtcNow,
                });
            }
            await _context.Events.AddRangeAsync(events);
        }

        public Task DeleteAsync(TAggregate aggregate)
        {
            _context.Set<TAggregate>().Remove(aggregate);
            return Task.CompletedTask;
        }

        public async Task<TAggregate> GetByIdAsync(string id)
        {
            return await _context.Set<TAggregate>()
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync() ?? throw new NullReferenceException();
        }

        public async Task<IEnumerable<TAggregate>> GetAllAsync()
        {
            return await _context.Set<TAggregate>().ToListAsync() ?? throw new NullReferenceException();
        }

        public async Task<IEnumerable<TAggregate>> GetAsync(Expression<Func<TAggregate, bool>> predicate)
        {
            IQueryable<TAggregate> query = _context.Set<TAggregate>();

            query = query.AsNoTracking();
            ;

            if (predicate != null) query = query.Where(predicate);

            return await query.ToListAsync();
        }
    }
}
