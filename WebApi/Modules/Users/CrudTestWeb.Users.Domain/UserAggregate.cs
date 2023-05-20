using CrudTestWeb.Shared.Domain.Definitions;
using CrudTestWeb.Users.Domain.DomainEvents;
using CrudTestWeb.Users.Domain.ValueObjects;
using System;

namespace CrudTestWeb.Users.Domain
{
    public class UserAggregate: Aggregate
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public UserStatus Status { get; set; }
        public UserAggregate(string userName, string email, string password)
        {
            AggregateId = Guid.NewGuid().ToString();
            UserName = userName;
            Email = email;
            Password = password;
            CreateDate = LastUpdateDate = DateTime.UtcNow;
            Status = UserStatus.Active;
            DomainEvents.Add(new UserCreated(userName, email, Status));
        }

        public void UpdateUser(string userName, string email, string password)
        {
            UserName = userName;
            ChangeEmail(email);
            ChangePassword(password);
            LastUpdateDate = DateTime.UtcNow;
            DomainEvents.Add(new UserUpdated(userName));
        }

        public void ChangePassword(string password)
        {
            if(password != Password)
            {
                Password = password;
                DomainEvents.Add(new PasswordChanged());
            }
        }
        public void ChangeEmail(string email)
        {
            if(email != Email)
            {
                Email = email;
                DomainEvents.Add(new EmailChanged(email));
            }
        }

        public void ChangeStatus(UserStatus status)
        {
            if(status != Status)
            {
                Status = status;
                DomainEvents.Add(new StatusChanged(status));
            }
        }

    }
}
