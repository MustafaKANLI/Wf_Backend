namespace UsersService.API.Controllers.v1;

using UsersService.Application.Features.Sprints.Commands;
using UsersService.Application.Features.Sprints.Queries.GetAllSprints;

using Microsoft.AspNetCore.Mvc;
using Common.Parameters;
using MassTransit;
using Common.Contracts.Entities;
using UsersService.Application.Features.Sprints.Queries.GetById;
using UsersService.Application.Features.SprintsByCustomerId.Queries.GetAllSprintsByCustomerId;


public class SprintController : BaseApiController
{

    // POST api/<controller>
    [HttpPost("/api/Sprints/add")]
    public async Task<IActionResult> Create(CreateSprintCommand command)
    {
        return Ok(await Mediator.Send(command));
    }

    // GET: api/<controller>
    [HttpGet("/api/Sprints/getall")]
    public async Task<IActionResult> Get([FromQuery] RequestParameter filter)
    {
        return Ok(await Mediator.Send(new GetAllSprintsQuery() { PageSize = filter.PageSize, PageNumber = filter.PageNumber }));
    }

    // GET: api/<controller>/id
    [HttpGet("/api/Sprints/getbyid")]
    public async Task<IActionResult> GetById(int Id)
    {
        return Ok(await Mediator.Send(new GetByIdQuery() { Id = Id }));
    }

    // GET: api/<controller>/id
    [HttpGet("/api/Sprints/getbycustomerid")]
    public async Task<IActionResult> GetByCustomerId(int CustomerId)
    {
        return Ok(await Mediator.Send(new GetAllSprintsByCustomerIdQuery() { CustomerId = CustomerId }));
    }

    // DELETE: api/<controller>/id
    [HttpDelete("/api/Sprints/delete")]
    public async Task<IActionResult> Delete(int id)
    {
        var command = new DeleteSprintCommand { Id = id };
        var result = await Mediator.Send(command);

        return Ok(result);
    }

    // Put: api/<controller>
    [HttpPut("/api/Sprints/update")]
    public async Task<IActionResult> Update(UpdateSprintCommand command)
    {
        return Ok(await Mediator.Send(command));
    }

}
