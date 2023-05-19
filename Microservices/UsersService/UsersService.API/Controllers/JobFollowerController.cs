namespace UsersService.API.Controllers.v1;

using UsersService.Application.Features.JobFollowers.Commands;
using UsersService.Application.Features.JobFollowers.Queries.GetAllJobFollowers;

using Microsoft.AspNetCore.Mvc;
using Common.Parameters;
using MassTransit;
using Common.Contracts.Entities;
using UsersService.Application.Features.JobFollowers.Queries.GetById;
using UsersService.Application.Features.JobFollowersByJobId.Queries.GetAllJobFollowersByJobId;

public class JobFollowerController : BaseApiController
{

    // POST api/<controller>
    [HttpPost("/api/JobFollowers/add")]
    public async Task<IActionResult> Create(CreateJobFollowerCommand command)
    {
        return Ok(await Mediator.Send(command));
    }

    // GET: api/<controller>
    [HttpGet("/api/JobFollowers/getall")]
    public async Task<IActionResult> Get([FromQuery] RequestParameter filter)
    {
        return Ok(await Mediator.Send(new GetAllJobFollowersQuery() { PageSize = filter.PageSize, PageNumber = filter.PageNumber }));
    }

    // GET: api/<controller>/id
    [HttpGet("/api/JobFollowers/getbyid")]
    public async Task<IActionResult> GetById(int id)
    {
        return Ok(await Mediator.Send(new GetByIdQuery() { Id = id }));
    }

    // GET: api/<controller>
    [HttpGet("/api/JobFollowers/getlistbyjobid")]
    public async Task<IActionResult> GetListByJobId(int JobId)
    {
        var query = new GetAllJobFollowersByJobIdQuery { JobId = JobId };
        var result = await Mediator.Send(query);

        return Ok(result);
    }

    // DELETE: api/<controller>/id
    [HttpDelete("/api/JobFollowers/delete")]
    public async Task<IActionResult> Delete(int id)
    {
        var command = new DeleteJobFollowerCommand { Id = id };
        var result = await Mediator.Send(command);

        return Ok(result);
    }

    // Put: api/<controller>
    [HttpPut("/api/JobFollowers/update")]
    public async Task<IActionResult> Update(UpdateJobFollowerCommand command)
    {
        return Ok(await Mediator.Send(command));
    }

}
