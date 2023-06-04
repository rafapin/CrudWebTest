using CrudTestWeb.Users.Domain;
using Microsoft.EntityFrameworkCore;

namespace CrudTestWeb.Users.Infrastructure.Implementations.Repository
{
    public class CrudTestWebContext : DbContext
    {
        private static long InstanceCount;
        public CrudTestWebContext(DbContextOptions<CrudTestWebContext> options) : base(options)
         => Interlocked.Increment(ref InstanceCount);
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<UserAggregate>()
                .Ignore(x => x.DomainEvents);
        }

        public DbSet<UserAggregate> Users { get; set; }
        public DbSet<Event> Events { get; set; }
    }

    public class Event
    {
        public string Id { get; set; }
        public string AggregateId { get; set; }
        public string EventName { get; set; }
        public string EventSerialize { get; set; }
        public DateTime DateOcurred { get; set; }
    }
}
