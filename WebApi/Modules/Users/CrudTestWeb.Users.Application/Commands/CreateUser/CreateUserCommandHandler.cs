using CrudTestWeb.Shared.Domain.Contracts;
using CrudTestWeb.Users.Domain;
using CrudTestWeb.Users.Domain.Contracts;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CrudTestWeb.Users.Application.Commands.CreateUser
{
    internal class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, bool>
    {
        private readonly IRepository<UserAggregate> _repository;
        private readonly IEncryptService _encryptService;

        public CreateUserCommandHandler(IRepository<UserAggregate> repository, IEncryptService encryptService)
        {
            _repository = repository;
            _encryptService = encryptService;
        }

        public async Task<bool> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var userAggregate = new UserAggregate(request.UserName, request.Email, _encryptService.Encrypt(request.Password));
            await _repository.SaveAsync(userAggregate);
            await _repository.Commit();
            return true;
        }
    }
}
