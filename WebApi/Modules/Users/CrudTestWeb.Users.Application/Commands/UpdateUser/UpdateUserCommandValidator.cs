using CrudTestWeb.Shared.Domain.Contracts;
using CrudTestWeb.Users.Domain;
using FluentValidation;
using MediatR;
using System.Linq;

namespace CrudTestWeb.Users.Application.Commands.CreateUser
{
    internal class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator(IRepository<UserAggregate> repository)
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress(FluentValidation.Validators.EmailValidationMode.Net4xRegex)
                .MaximumLength(100)
                .MustAsync(async (root, lst, ctx) =>
                    (await repository.GetAsync(it => it.Email == root.Email && it.AggregateId != root.Id)).Count() > 0)
                .WithMessage("This email is not available");

            RuleFor(x => x.UserName)
                .NotEmpty()
                .MinimumLength(5)
                .MaximumLength(30)
                .MustAsync(async (root, lst, ctx) =>
                    (await repository.GetAsync(it => it.UserName == root.UserName && it.AggregateId != root.Id)).Count() > 0)
                .WithMessage("This username is not available");

            RuleFor(x => x.Password)
                .NotEmpty()
                .MinimumLength(5)
                .MaximumLength(20)
                .Matches(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*\W).*$")
                .WithMessage("The value must contain at least one digit, one lowercase letter, one uppercase letter, and one special character.")
                .When(x => x.Password.Length > 0, ApplyConditionTo.AllValidators);
        }
    }
}
