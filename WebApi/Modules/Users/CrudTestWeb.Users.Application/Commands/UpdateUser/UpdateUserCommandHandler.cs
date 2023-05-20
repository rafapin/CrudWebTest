using CrudTestWeb.Shared.Domain.Contracts;
using CrudTestWeb.Users.Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CrudTestWeb.Users.Application.Commands.CreateUser
{
    internal class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, bool>
    {
        private readonly IRepository<UserAggregate> _repository;

        public UpdateUserCommandHandler(IRepository<UserAggregate> repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var userAggregate = await _repository.GetByIdAsync(request.Id);
            userAggregate.UpdateUser(request.UserName,request.Email,request.Password);
            await _repository.UpdateAsync(userAggregate);
            return true;
        }
    }
}
