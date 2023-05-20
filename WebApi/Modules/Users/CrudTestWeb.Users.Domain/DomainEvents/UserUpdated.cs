using CrudTestWeb.Shared.Domain.Definitions;

namespace CrudTestWeb.Users.Domain.DomainEvents
{
    internal class UserUpdated : DomainEvent
    {
        public UserUpdated(string userName)
        {
            UserName = userName;
        }
        public string UserName { get; set; }
    }
}
