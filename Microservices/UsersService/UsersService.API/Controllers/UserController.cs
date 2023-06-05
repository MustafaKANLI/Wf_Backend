namespace UsersService.API.Controllers.v1;

using UsersService.Application.Features.Users.Commands;
using UsersService.Application.Features.Users.Queries.GetAllUsers;

using Microsoft.AspNetCore.Mvc;
using Common.Parameters;
using MassTransit;
using Common.Contracts.Entities;
using UsersService.Application.Features.Users.Queries.GetById;

using UsersService.Infrastructure.RulesEngine.Interfaces;

using Common.Wrappers;


public class UserController : BaseApiController
{
    private readonly IUserRules _userRules;

    public UserController(IUserRules UserRules)
    {
        _userRules = UserRules;
    }

    // POST api/<controller>
    [HttpPost("/api/Users/add")]
    public async Task<IActionResult> Create(CreateUserCommand command)
    {
        //Verileri RulesEngine'e göndererek doğrulama yapın
        RuleResponse ruleResponse = await _userRules.ValidateCreateUser(command);

        if (!ruleResponse.Succeeded)
        {
            // Doğrulama hataları var, BadRequestObjectResult döndürün
            return BadRequest(ruleResponse);
        }

        return Ok(await Mediator.Send(command));
    }

    // GET: api/<controller>
    [HttpGet("/api/Users/getall")]
    public async Task<IActionResult> Get([FromQuery] RequestParameter filter)
    {
        return Ok(await Mediator.Send(new GetAllUsersQuery() { PageSize = filter.PageSize, PageNumber = filter.PageNumber }));
    }


    // GET: api/<controller>/id
    [HttpGet("/api/Users/getbyid")]
    public async Task<IActionResult> GetById(int id)
    {
        return Ok(await Mediator.Send(new GetByIdQuery() { Id = id }));
    }

    // DELETE: api/<controller>/id
    [HttpDelete("/api/Users/delete")]
    public async Task<IActionResult> Delete(int id)
    {
        var command = new DeleteUserCommand { Id = id };
        var result = await Mediator.Send(command);

        return Ok(result);
    }

    // Put: api/<controller>
    [HttpPut("/api/Users/update")]
    public async Task<IActionResult> Update(UpdateUserCommand command)
    {
        return Ok(await Mediator.Send(command));
    }

}
