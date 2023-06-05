namespace UsersService.API.Controllers.v1;

using UsersService.Application.Features.Projects.Commands;
using UsersService.Application.Features.Projects.Queries.GetAllProjects;

using Microsoft.AspNetCore.Mvc;
using Common.Parameters;

using UsersService.Application.Features.Projects.Queries.GetById;
using UsersService.Application.Features.ProjectsByUserId.Queries.GetProjectsByUserId;

public class ProjectController : BaseApiController
{

    // POST api/<controller>
    [HttpPost("/api/Projects/add")]
    public async Task<IActionResult> Create(CreateProjectCommand command)
    {
        return Ok(await Mediator.Send(command));
    }

    // GET: api/<controller>
    [HttpGet("/api/Projects/getall")]
    public async Task<IActionResult> Get([FromQuery] RequestParameter filter)
    {
        return Ok(await Mediator.Send(new GetAllProjectsQuery() { PageSize = filter.PageSize, PageNumber = filter.PageNumber }));
    }

    // GET: api/<controller>/id
    [HttpGet("/api/Projects/getbyid")]
    public async Task<IActionResult> GetById(int id)
    {
        return Ok(await Mediator.Send(new GetByIdQuery() { Id = id }));
    }

    // GET: api/<controller>
    [HttpGet("/api/Projects/getprojectsbyuserid")]
    public async Task<IActionResult> GetProjectsByUserId([FromQuery] int UserId)
    {
        return Ok(await Mediator.Send(new GetProjectsByUserIdQuery() { UserId = UserId }));
    }

    // DELETE: api/<controller>/id
    [HttpDelete("/api/Projects/delete")]
    public async Task<IActionResult> Delete(int id)
    {
        var command = new DeleteProjectCommand { Id = id };
        var result = await Mediator.Send(command);

        return Ok(result);
    }

    // Put: api/<controller>
    [HttpPut("/api/Project/update")]
    public async Task<IActionResult> Update(UpdateProjectCommand command)
    {
        return Ok(await Mediator.Send(command));
    }

}
