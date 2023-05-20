using CrudTestWeb.Shared.Domain.Definitions;

namespace CrudTestWeb.Users.Domain.DomainEvents
{
    internal class UserCreated: DomainEvent
    {
        public UserCreated(UserAggregate user)
        {
            User = user;
        }
        public UserAggregate User { get; set; }
    }
}
