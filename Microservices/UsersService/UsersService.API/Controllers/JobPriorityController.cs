namespace UsersService.API.Controllers.v1;

using UsersService.Application.Features.JobPriorities.Commands;
using UsersService.Application.Features.JobPriorities.Queries.GetAllJobPriorities;

using Microsoft.AspNetCore.Mvc;
using Common.Parameters;
using UsersService.Application.Features.JobPriorities.Queries.GetById;


public class JobPriorityController : BaseApiController
{

    // POST api/<controller>
    [HttpPost("/api/JobPriorities/add")]
    public async Task<IActionResult> Create(CreateJobPriorityCommand command)
    {
        return Ok(await Mediator.Send(command));
    }

    // GET: api/<controller>
    [HttpGet("/api/JobPriorities/getall")]
    public async Task<IActionResult> Get([FromQuery] RequestParameter filter)
    {
        return Ok(await Mediator.Send(new GetAllJobPrioritiesQuery() { PageSize = filter.PageSize, PageNumber = filter.PageNumber }));
    }

    // GET: api/<controller>/id
    [HttpGet("/api/JobPriorities/getbyid")]
    public async Task<IActionResult> GetById(int id)
    {
        return Ok(await Mediator.Send(new GetByIdQuery() { Id = id }));
    }

    // Put: api/<controller>
    [HttpPut("/api/JobPriorities/update")]
    public async Task<IActionResult> Update(UpdateJobPriorityCommand command)
    {
        return Ok(await Mediator.Send(command));
    }

}
