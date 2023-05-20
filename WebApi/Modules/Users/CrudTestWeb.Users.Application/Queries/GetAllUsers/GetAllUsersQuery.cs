using CrudTestWeb.Users.Application.ViewModels;
using MediatR;
using System.Collections.Generic;

namespace CrudTestWeb.Users.Application.Queries.GetAllUsers
{
    public class GetAllUsersQuery : IRequest<List<UserVm>>
    {
    }
}
