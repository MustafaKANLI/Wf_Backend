namespace UsersService.API.Controllers.v1;

using UsersService.Application.Features.ProjectUsers.Commands;
using UsersService.Application.Features.ProjectUsers.Queries.GetAllProjectUsers;

using Microsoft.AspNetCore.Mvc;
using Common.Parameters;
using MassTransit;
using Common.Contracts.Entities;
using UsersService.Application.Features.ProjectUsers.Queries.GetById;
using UsersService.Application.Features.ProjectsByUserId.Queries.GetAllProjectsByUserId;


public class ProjectUserController : BaseApiController
{

    // POST api/<controller>
    [HttpPost("/api/ProjectUsers/add")]
    public async Task<IActionResult> Create(CreateProjectUserCommand command)
    {
        return Ok(await Mediator.Send(command));
    }

    // GET: api/<controller>
    [HttpGet("/api/ProjectUsers/getall")]
    public async Task<IActionResult> Get([FromQuery] RequestParameter filter)
    {
        return Ok(await Mediator.Send(new GetAllProjectUsersQuery() { PageSize = filter.PageSize, PageNumber = filter.PageNumber }));
    }

    // GET: api/<controller>
    [HttpGet("/api/ProjectUsers/getbyid")]
    public async Task<IActionResult> GetById(int id)
    {
        return Ok(await Mediator.Send(new GetByIdQuery() { Id = id }));
    }

    // GET: api/<controller>
    [HttpGet("/api/ProjectUsers/getprojectsbyuserid")]
    public async Task<IActionResult> GetProjectsByUserId([FromQuery] int UserId)
    {
        return Ok(await Mediator.Send(new GetAllProjectsByUserIdQuery() { UserId = UserId }));
    }

    // DELETE: api/<controller>/id
    [HttpDelete("/api/ProjectUsers/delete")]
    public async Task<IActionResult> Delete(int id)
    {
        var command = new DeleteProjectUserCommand { Id = id };
        var result = await Mediator.Send(command);

        return Ok(result);
    }

    // Put: api/<controller>
    [HttpPut("/api/ProjectUsers/update")]
    public async Task<IActionResult> Update(UpdateProjectUserCommand command)
    {
        return Ok(await Mediator.Send(command));
    }

}
