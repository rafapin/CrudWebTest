using CrudTestWeb.Shared.Domain.Definitions;
using CrudTestWeb.Users.Domain.ValueObjects;

namespace CrudTestWeb.Users.Domain.DomainEvents
{
    internal class StatusChanged : DomainEvent
    {
        public StatusChanged(UserStatus status)
        {
            Status = status;
        }

        public UserStatus Status { get; set; }
    }
}
