namespace UsersService.API.Controllers.v1;

using UsersService.Application.Features.JobQAs.Commands;
using UsersService.Application.Features.JobQAs.Queries.GetAllJobQAs;

using Microsoft.AspNetCore.Mvc;
using Common.Parameters;
using MassTransit;
using Common.Contracts.Entities;
using UsersService.Application.Features.JobQAs.Queries.GetById;
using UsersService.Application.Features.JobQAsByJobId.Queries.GetAllJobQAsByJobId;

public class JobQAController : BaseApiController
{

    // POST api/<controller>
    [HttpPost("/api/JobQAs/add")]
    public async Task<IActionResult> Create(CreateJobQACommand command)
    {
        return Ok(await Mediator.Send(command));
    }

    // GET: api/<controller>
    [HttpGet("/api/JobQAs/getall")]
    public async Task<IActionResult> Get([FromQuery] RequestParameter filter)
    {
        return Ok(await Mediator.Send(new GetAllJobQAsQuery() { PageSize = filter.PageSize, PageNumber = filter.PageNumber }));
    }

    // GET: api/<controller>/id
    [HttpGet("/api/JobQAs/getbyid")]
    public async Task<IActionResult> GetById(int id)
    {
        return Ok(await Mediator.Send(new GetByIdQuery() { Id = id }));
    }

    // GET: api/<controller>
    [HttpGet("/api/JobQAs/getlistbyjobid")]
    public async Task<IActionResult> GetListByJobId(int JobId)
    {
        var query = new GetAllJobQAsByJobIdQuery { JobId = JobId };
        var result = await Mediator.Send(query);

        return Ok(result);
    }

    // DELETE: api/<controller>/id
    [HttpDelete("/api/JobQAs/delete")]
    public async Task<IActionResult> Delete(int id)
    {
        var command = new DeleteJobQACommand { Id = id };
        var result = await Mediator.Send(command);

        return Ok(result);
    }

    // Put: api/<controller>
    [HttpPut("/api/JobQAs/update")]
    public async Task<IActionResult> Update(UpdateJobQACommand command)
    {
        return Ok(await Mediator.Send(command));
    }

}
