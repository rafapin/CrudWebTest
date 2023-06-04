using CrudTestWeb.Shared.Domain.Contracts;
using CrudTestWeb.Users.Domain;
using CrudTestWeb.Users.Domain.Contracts;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CrudTestWeb.Users.Application.Commands.CreateUser
{
    internal class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, bool>
    {
        private readonly IRepository<UserAggregate> _repository;
        private readonly IEncryptService _encryptService;

        public UpdateUserCommandHandler(IRepository<UserAggregate> repository, IEncryptService encryptService)
        {
            _repository = repository;
            _encryptService = encryptService;
        }

        public async Task<bool> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            if (!string.IsNullOrEmpty(request.Password))
                request.Password = _encryptService.Encrypt(request.Password);
            var userAggregate = await _repository.GetByIdAsync(request.Id);
            userAggregate.UpdateUser(request.UserName,request.Email,request.Password);
            await _repository.SaveAsync(userAggregate);
            await _repository.Commit();
            return true;
        }
    }
}
