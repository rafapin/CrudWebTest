using CrudTestWeb.Shared.Domain.Contracts;
using CrudTestWeb.Users.Application.ViewModels;
using CrudTestWeb.Users.Domain;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CrudTestWeb.Users.Application.Queries.GetAllUsers
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, List<UserVm>>
    {
        private readonly IRepository<UserAggregate> _repository;

        public GetAllUsersQueryHandler(IRepository<UserAggregate> repository)
        {
            _repository = repository;
        }
        public async Task<List<UserVm>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _repository.GetAllAsync();
            return users.Select(user => new UserVm
            {
                Id = user.AggregateId,
                Email = user.Email,
                UserName = user.UserName,
                Status = user.Status.ToString()
            }).ToList();
        }
    }
}
