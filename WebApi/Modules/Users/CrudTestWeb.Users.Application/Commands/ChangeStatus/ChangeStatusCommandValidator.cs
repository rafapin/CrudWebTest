using FluentValidation;

namespace CrudTestWeb.Users.Application.Commands.CreateUser
{
    internal class ChangeStatusCommandValidator : AbstractValidator<ChangeStatusCommand>
    {
        public ChangeStatusCommandValidator()
        {
        }
    }
}
