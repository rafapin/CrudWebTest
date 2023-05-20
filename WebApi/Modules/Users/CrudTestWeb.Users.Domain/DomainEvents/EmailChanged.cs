using CrudTestWeb.Shared.Domain.Definitions;

namespace CrudTestWeb.Users.Domain.DomainEvents
{
    internal class EmailChanged: DomainEvent
    {
        public EmailChanged(string email)
        {
            Email = email;
        }

        public string Email { get; set; }
    }
}
