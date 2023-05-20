using CrudTestWeb.Shared.Domain.Definitions;
using CrudTestWeb.Users.Domain.DomainEvents;
using System;

namespace CrudTestWeb.Users.Domain
{
    public class UserAggregate: Aggregate
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public UserAggregate(string userName, string email, string password)
        {
            AggregateId = Guid.NewGuid().ToString();
            UserName = userName;
            Email = email;
            Password = password;
            CreateDate = LastUpdateDate = DateTime.UtcNow;
            DomainEvents.Add(new UserCreated(this));
        }
    }
}
