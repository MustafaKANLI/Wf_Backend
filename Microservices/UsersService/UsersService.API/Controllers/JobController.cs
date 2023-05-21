namespace UsersService.API.Controllers.v1;

using UsersService.Application.Features.Jobs.Commands;
using UsersService.Application.Features.Jobs.Queries.GetAllJobs;

using Microsoft.AspNetCore.Mvc;
using Common.Parameters;
using MassTransit;
using Common.Contracts.Entities;
using UsersService.Application.Features.Jobs.Queries.GetById;
using UsersService.Application.Features.JobsByAssignedUserId.Queries.GetAllJobsByAssignedUserId;

public class JobController : BaseApiController
{

    // POST api/<controller>
    [HttpPost("/api/Jobs/add")]
    public async Task<IActionResult> Create(CreateJobCommand command)
    {
        return Ok(await Mediator.Send(command));
    }

    // GET: api/<controller>
    [HttpGet("/api/Jobs/getall")]
    public async Task<IActionResult> GetAll([FromQuery] RequestParameter filter)
    {
        return Ok(await Mediator.Send(new GetAllJobsQuery() { PageSize = filter.PageSize, PageNumber = filter.PageNumber }));
    }

    // GET: api/<controller>/id
    [HttpGet("/api/Jobs/getbyid")]
    public async Task<IActionResult> GetById(int id)
    {
        return Ok(await Mediator.Send(new GetByIdQuery() { Id = id }));
    }

    // GET: api/<controller>
    [HttpGet("/api/Jobs/getjobsbyassigneduserid")]
    public async Task<IActionResult> GetJobsByAssignedUserId([FromQuery] int AssignedUserId)
    {
        return Ok(await Mediator.Send(new GetAllJobsByAssignedUserIdQuery() { AssignedUserId = AssignedUserId }));
    }



    // DELETE: api/<controller>/id
    [HttpDelete("/api/Jobs/delete")]
    public async Task<IActionResult> Delete(int id)
    {
        var command = new DeleteJobCommand { Id = id };
        var result = await Mediator.Send(command);

        return Ok(result);
    }

    // Put: api/<controller>
    [HttpPut("/api/Jobs/update")]
    public async Task<IActionResult> Update(UpdateJobCommand command)
    {
        return Ok(await Mediator.Send(command));
    }

}
