namespace UsersService.API.Controllers.v1;

using UsersService.Application.Features.JobComments.Commands;
using UsersService.Application.Features.JobComments.Queries.GetAllJobComments;

using Microsoft.AspNetCore.Mvc;
using Common.Parameters;
using MassTransit;
using Common.Contracts.Entities;
using UsersService.Application.Features.JobComments.Queries.GetById;

public class JobCommentController : BaseApiController
{

    // POST api/<controller>
    [HttpPost("/api/JobComments/add")]
    public async Task<IActionResult> Create(CreateJobCommentCommand command)
    {
        return Ok(await Mediator.Send(command));
    }

    // GET: api/<controller>
    [HttpGet("/api/JobComments/getall")]
    public async Task<IActionResult> Get([FromQuery] RequestParameter filter)
    {
        return Ok(await Mediator.Send(new GetAllJobCommentsQuery() { PageSize = filter.PageSize, PageNumber = filter.PageNumber }));
    }

    // GET: api/<controller>/id
    [HttpGet("/api/JobComments/getbyid")]
    public async Task<IActionResult> GetById(int id)
    {
        return Ok(await Mediator.Send(new GetByIdQuery() { Id = id }));
    }

    // DELETE: api/<controller>/id
    [HttpDelete("/api/JobComments/delete")]
    public async Task<IActionResult> Delete(int id)
    {
        var command = new DeleteJobCommentCommand { Id = id };
        var result = await Mediator.Send(command);

        return Ok(result);
    }

    // Put: api/<controller>
    [HttpPut("/api/JobComments/update")]
    public async Task<IActionResult> Update(UpdateJobCommentCommand command)
    {
        return Ok(await Mediator.Send(command));
    }

}
