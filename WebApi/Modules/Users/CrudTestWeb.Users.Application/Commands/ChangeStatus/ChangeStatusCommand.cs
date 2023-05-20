using CrudTestWeb.Users.Domain.ValueObjects;
using MediatR;

namespace CrudTestWeb.Users.Application.Commands.CreateUser
{
    public class ChangeStatusCommand : IRequest<bool>
    {
        public string Id { get; set; }
        public UserStatus Status { get; set; }
    }
}
