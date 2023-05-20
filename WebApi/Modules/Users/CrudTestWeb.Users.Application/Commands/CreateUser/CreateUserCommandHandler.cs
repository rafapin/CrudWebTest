using CrudTestWeb.Shared.Domain.Contracts;
using CrudTestWeb.Users.Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CrudTestWeb.Users.Application.Commands.CreateUser
{
    internal class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, bool>
    {
        private readonly IRepository<UserAggregate> _repository;

        public CreateUserCommandHandler(IRepository<UserAggregate> repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var userAggregate = new UserAggregate(request.UserName, request.Email,request.Password);
            await _repository.AddAsync(userAggregate);
            return true;
        }
    }
}
