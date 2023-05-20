using MediatR;

namespace CrudTestWeb.Users.Application.Commands.CreateUser
{
    public class UpdateUserCommand : IRequest<bool>
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
