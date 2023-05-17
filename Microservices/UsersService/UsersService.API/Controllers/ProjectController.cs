namespace UsersService.API.Controllers.v1;

using UsersService.Application.Features.Projects.Commands;
using UsersService.Application.Features.Projects.Queries.GetAllProjects;

using Microsoft.AspNetCore.Mvc;
using Common.Parameters;
using MassTransit;
using Common.Contracts.Entities;
using UsersService.Application.Features.Projects.Queries.GetById;

public class ProjectController : BaseApiController
{

  // POST api/<controller>
  [HttpPost]
  public async Task<IActionResult> Create(CreateProjectCommand command)
  {
    return Ok(await Mediator.Send(command));
  }

  // GET: api/<controller>
  [HttpGet]
  public async Task<IActionResult> Get([FromQuery] RequestParameter filter)
  {
    return Ok(await Mediator.Send(new GetAllProjectsQuery() { PageSize = filter.PageSize, PageNumber = filter.PageNumber }));
  }

    // GET: api/<controller>/id
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        return Ok(await Mediator.Send(new GetByIdQuery() { Id = id }));
    }

}
