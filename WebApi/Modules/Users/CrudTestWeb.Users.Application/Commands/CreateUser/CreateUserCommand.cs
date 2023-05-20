using MediatR;

namespace CrudTestWeb.Users.Application.Commands.CreateUser
{
    public class CreateUserCommand: IRequest<bool>
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
