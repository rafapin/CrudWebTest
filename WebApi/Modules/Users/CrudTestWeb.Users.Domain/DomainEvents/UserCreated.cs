using CrudTestWeb.Shared.Domain.Definitions;
using CrudTestWeb.Users.Domain.ValueObjects;

namespace CrudTestWeb.Users.Domain.DomainEvents
{
    internal class UserCreated: DomainEvent
    {
        public UserCreated(string email, string userName, UserStatus state)
        {
            Email = email;
            UserName = userName;
            State = state;
        }

        public string Email { get; set; }
        public string UserName { get; set; }
        public UserStatus State { get; set; }
    }
}
