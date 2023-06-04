using CrudTestWeb.Users.Application.Commands.CreateUser;
using CrudTestWeb.Users.Application.Queries.GetAllUsers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CrudTestWeb.WebApi.Controllers.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _mediator.Send(new GetAllUsersQuery()));
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> Add([FromBody]CreateUserCommand request)
        {
            return Ok(await _mediator.Send(request));
        }

        [HttpPost]
        [Route("update")]
        public async Task<IActionResult> Update([FromBody]UpdateUserCommand request)
        {
            return Ok(await _mediator.Send(request));
        }

        [HttpPost]
        [Route("changeStatus")]
        public async Task<IActionResult> ChangeStatus([FromBody]ChangeStatusCommand request)
        {
            return Ok(await _mediator.Send(request));
        }
    }
}
