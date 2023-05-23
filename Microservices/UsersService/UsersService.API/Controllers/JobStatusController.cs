namespace UsersService.API.Controllers.v1;

using UsersService.Application.Features.JobStatuses.Commands;
using UsersService.Application.Features.JobStatuses.Queries.GetAllJobStatuses;

using Microsoft.AspNetCore.Mvc;
using Common.Parameters;
using MassTransit;
using Common.Contracts.Entities;
using UsersService.Application.Features.JobStatuses.Queries.GetById;


public class JobStatusController : BaseApiController
{

    // POST api/<controller>
    [HttpPost("/api/JobStatuses/add")]
    public async Task<IActionResult> Create(CreateJobStatusCommand command)
    {
        return Ok(await Mediator.Send(command));
    }

    // GET: api/<controller>
    [HttpGet("/api/JobStatuses/getall")]
    public async Task<IActionResult> Get([FromQuery] RequestParameter filter)
    {
        return Ok(await Mediator.Send(new GetAllJobStatusesQuery() { PageSize = filter.PageSize, PageNumber = filter.PageNumber }));
    }

    // GET: api/<controller>
    [HttpGet("/api/JobStatuses/getbyid")]
    public async Task<IActionResult> GetById(int Id)
    {
        return Ok(await Mediator.Send(new GetByIdQuery() { Id = Id }));
    }

    // DELETE: api/<controller>/id
    [HttpDelete("/api/JobStatuses/delete")]
    public async Task<IActionResult> Delete(int Id)
    {
        var command = new DeleteJobStatusCommand { Id = Id };
        var result = await Mediator.Send(command);

        return Ok(result);
    }

}
