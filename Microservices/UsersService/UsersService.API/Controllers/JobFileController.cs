namespace UsersService.API.Controllers.v1;

using UsersService.Application.Features.JobFiles.Commands;
using UsersService.Application.Features.JobFiles.Queries.GetAllJobFiles;

using Microsoft.AspNetCore.Mvc;
using Common.Parameters;
using MassTransit;
using Common.Contracts.Entities;
using UsersService.Application.Features.JobFiles.Queries.GetById;

public class JobFileController : BaseApiController
{

    // POST api/<controller>
    [HttpPost("/api/JobFiles/Add")]
    public async Task<IActionResult> Create(int JobId, int UserId, IFormFile file)
    {
        return Ok(await Mediator.Send(new CreateJobFileCommand() { JobId = JobId, UserId = UserId, File = file }));
    }

    // GET: api/<controller>
    [HttpGet("/api/JobFiles/getall")]
    public async Task<IActionResult> Get([FromQuery] RequestParameter filter)
    {
        return Ok(await Mediator.Send(new GetAllJobFilesQuery() { PageSize = filter.PageSize, PageNumber = filter.PageNumber }));
    }

    // GET: api/<controller>/id
    [HttpGet("/api/JobFiles/getbyid")]
    public async Task<IActionResult> GetById(int id)
    {
        return Ok(await Mediator.Send(new GetByIdQuery() { Id = id }));
    }

}
