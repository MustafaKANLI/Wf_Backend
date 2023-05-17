namespace UsersService.API.Controllers.v1;

using UsersService.Application.Features.ProjectUsers.Commands;
using UsersService.Application.Features.ProjectUsers.Queries.GetAllProjectUsers;

using Microsoft.AspNetCore.Mvc;
using Common.Parameters;
using MassTransit;
using Common.Contracts.Entities;
using UsersService.Application.Features.ProjectUsers.Queries.GetById;

public class ProjectUserController : BaseApiController
{

  // POST api/<controller>
  [HttpPost]
  public async Task<IActionResult> Create(CreateProjectUserCommand command)
  {
    return Ok(await Mediator.Send(command));
  }

  // GET: api/<controller>
  [HttpGet]
  public async Task<IActionResult> Get([FromQuery] RequestParameter filter)
  {
    return Ok(await Mediator.Send(new GetAllProjectUsersQuery() { PageSize = filter.PageSize, PageNumber = filter.PageNumber }));
  }

    // GET: api/<controller>/id
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        return Ok(await Mediator.Send(new GetByIdQuery() { Id = id }));
    }

}
