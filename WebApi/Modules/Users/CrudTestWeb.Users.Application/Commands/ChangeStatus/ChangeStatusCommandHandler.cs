using CrudTestWeb.Shared.Domain.Contracts;
using CrudTestWeb.Users.Domain;
using CrudTestWeb.Users.Domain.Contracts;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CrudTestWeb.Users.Application.Commands.CreateUser
{
    internal class ChangeStatusCommandHandler : IRequestHandler<ChangeStatusCommand, bool>
    {
        private readonly IRepository<UserAggregate> _repository;

        public ChangeStatusCommandHandler(IRepository<UserAggregate> repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(ChangeStatusCommand request, CancellationToken cancellationToken)
        {
            var userAggregate = await _repository.GetByIdAsync(request.Id);
            userAggregate.ChangeStatus(request.Status);
            await _repository.SaveAsync(userAggregate);
            await _repository.Commit();
            return true;
        }
    }
}
