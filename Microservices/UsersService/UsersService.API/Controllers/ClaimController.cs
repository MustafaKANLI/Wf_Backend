namespace UsersService.API.Controllers.v1;

using UsersService.Application.Features.Claims.Commands;
using UsersService.Application.Features.Claims.Queries.GetAllClaims;

using Microsoft.AspNetCore.Mvc;
using Common.Parameters;
using MassTransit;
using Common.Contracts.Entities;
using UsersService.Application.Features.Claims.Queries.GetById;

public class ClaimController : BaseApiController
{

    // POST api/<controller>
    [HttpPost("/api/Claims/add")]
    public async Task<IActionResult> Create(CreateClaimCommand command)
    {
        return Ok(await Mediator.Send(command));
    }

    // GET: api/<controller>
    [HttpGet("/api/Claims/getall")]
    public async Task<IActionResult> Get([FromQuery] RequestParameter filter)
    {
        return Ok(await Mediator.Send(new GetAllClaimsQuery() { PageSize = filter.PageSize, PageNumber = filter.PageNumber }));
    }

    // GET: api/<controller>/id
    [HttpGet("/api/Claims/getbyid")]
    public async Task<IActionResult> GetById(int id)
    {
        return Ok(await Mediator.Send(new GetByIdQuery() { Id = id }));
    }

    // DELETE: api/<controller>/id
    [HttpDelete("/api/Claims/delete")]
    public async Task<IActionResult> Delete(int id)
    {
        var command = new DeleteClaimCommand { Id = id };
        var result = await Mediator.Send(command);

        return Ok(result);
    }

    // Put: api/<controller>
    [HttpPut("/api/Claims/update")]
    public async Task<IActionResult> Update(UpdateClaimCommand command)
    {
        return Ok(await Mediator.Send(command));
    }

}
