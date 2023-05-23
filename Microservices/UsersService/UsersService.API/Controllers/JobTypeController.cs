namespace UsersService.API.Controllers.v1;

using UsersService.Application.Features.JobTypes.Commands;
using UsersService.Application.Features.JobTypes.Queries.GetAllJobTypes;

using Microsoft.AspNetCore.Mvc;
using Common.Parameters;
using UsersService.Application.Features.JobTypes.Queries.GetById;

public class JobTypeController : BaseApiController
{

    // POST api/<controller>
    [HttpPost("/api/JobTypes/add")]
    public async Task<IActionResult> Create(CreateJobTypeCommand command)
    {
        return Ok(await Mediator.Send(command));
    }

    // GET: api/<controller>
    [HttpGet("/api/JobTypes/getall")]
    public async Task<IActionResult> Get([FromQuery] RequestParameter filter)
    {
        return Ok(await Mediator.Send(new GetAllJobTypesQuery() { PageSize = filter.PageSize, PageNumber = filter.PageNumber }));
    }

    // GET: api/<controller>/id
    [HttpGet("/api/JobTypes/getbyid")]
    public async Task<IActionResult> GetById(int id)
    {
        return Ok(await Mediator.Send(new GetByIdQuery() { Id = id }));
    }

    // DELETE: api/<controller>/id
    [HttpDelete("/api/JobTypes/delete")]
    public async Task<IActionResult> Delete(int id)
    {
        var command = new DeleteJobTypeCommand { Id = id };
        var result = await Mediator.Send(command);

        return Ok(result);
    }

    // Put: api/<controller>
    [HttpPut("/api/JobTypes/update")]
    public async Task<IActionResult> Update(UpdateJobTypeCommand command)
    {
        return Ok(await Mediator.Send(command));
    }

}
