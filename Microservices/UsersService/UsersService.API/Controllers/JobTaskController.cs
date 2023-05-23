namespace UsersService.API.Controllers.v1;

using UsersService.Application.Features.JobTasks.Commands;
using UsersService.Application.Features.JobTasks.Queries.GetAllJobTasks;

using Microsoft.AspNetCore.Mvc;
using Common.Parameters;
using UsersService.Application.Features.JobTasks.Queries.GetById;
using UsersService.Application.Features.JobTasksByJobId.Queries.GetAllJobTasksByJobId;

public class JobTaskController : BaseApiController
{

    // POST api/<controller>
    [HttpPost("/api/JobTasks/add")]
    public async Task<IActionResult> Create(CreateJobTaskCommand command)
    {
        return Ok(await Mediator.Send(command));
    }

    // GET: api/<controller>
    [HttpGet("/api/JobTasks/getall")]
    public async Task<IActionResult> Get([FromQuery] RequestParameter filter)
    {
        return Ok(await Mediator.Send(new GetAllJobTasksQuery() { PageSize = filter.PageSize, PageNumber = filter.PageNumber }));
    }

    // GET: api/<controller>
    [HttpGet("/api/JobTasks/getbyid")]
    public async Task<IActionResult> GetById(int id)
    {
        return Ok(await Mediator.Send(new GetByIdQuery() { Id = id }));
    }

    // GET: api/<controller>
    [HttpGet("/api/JobTasks/getlistbyjobid")]
    public async Task<IActionResult> GetListByJobId(int JobId)
    {
        var query = new GetAllJobTasksByJobIdQuery { JobId = JobId };
        var result = await Mediator.Send(query);

        return Ok(result);
    }

    // DELETE: api/<controller>/id
    [HttpDelete("/api/JobTasks/delete")]
    public async Task<IActionResult> Delete(int id)
    {
        var command = new DeleteJobTaskCommand { Id = id };
        var result = await Mediator.Send(command);

        return Ok(result);
    }

    // Put: api/<controller>
    [HttpPut("/api/JobTasks/update")]
    public async Task<IActionResult> Update(UpdateJobTaskCommand command)
    {
        return Ok(await Mediator.Send(command));
    }

}
