﻿namespace UsersService.API.Controllers.v1;

using UsersService.Application.Features.Customers.Commands;
using UsersService.Application.Features.Customers.Queries.GetAllCustomers;

using Microsoft.AspNetCore.Mvc;
using Common.Parameters;
using MassTransit;
using Common.Contracts.Entities;
using UsersService.Application.Features.Customers.Queries.GetById;


public class CustomerController : BaseApiController
{

    // POST api/<controller>
    [HttpPost("/api/Customers/add")]
    public async Task<IActionResult> Create(CreateCustomerCommand command)
    {
        return Ok(await Mediator.Send(command));
    }

    // GET: api/<controller>
    [HttpGet("/api/Customers/getall")]
    public async Task<IActionResult> Get([FromQuery] RequestParameter filter)
    {
        return Ok(await Mediator.Send(new GetAllCustomersQuery() { PageSize = filter.PageSize, PageNumber = filter.PageNumber }));
    }

    // GET: api/<controller>/id
    [HttpGet("/api/Customers/getbyid")]
    public async Task<IActionResult> GetById(int id)
    {
        return Ok(await Mediator.Send(new GetByIdQuery() { Id = id }));
    }

    // DELETE: api/<controller>/id
    [HttpDelete("/api/Customers/delete")]
    public async Task<IActionResult> Delete(int id)
    {
        var command = new DeleteCustomerCommand { Id = id };
        var result = await Mediator.Send(command);
       
        return Ok(result);
    }

    // Put: api/<controller>
    [HttpPut("/api/Customers/update")]
    public async Task<IActionResult> Update(UpdateCustomerCommand command)
    {
        return Ok(await Mediator.Send(command));
    }




    //// GET: api/<controller>
    //[HttpGet("Search")]
    //public async Task<IActionResult> GetBySearchFilter([FromQuery] GetCustomersBySearchFilterParameter filter)
    //{
    //  return Ok(await Mediator.Send(new GetCustomersBySearchFilterQuery() { FilterString = filter.FilterString, PageSize = filter.PageSize, PageNumber = filter.PageNumber }));
    //}

    //// GET: api/<controller>/id
    //[HttpGet("{id}")]
    //public async Task<IActionResult> GetById(int id)
    //{
    //  return Ok(await Mediator.Send(new GetCustomerByIdQuery() { Id = id }));
    //}

    //// PATCH: api/<controller>
    //[HttpPatch]
    //public async Task<IActionResult> Patch(UpdateCustomerCommand command)
    //{
    //  return Ok(await Mediator.Send(command));
    //}

    //// POST: api/<controller>/deactivate
    //[HttpPost("deactivate")]
    //public async Task<IActionResult> Deactivate(DeactivateCustomerCommand command)
    //{
    //  return Ok(await Mediator.Send(command));
    //}

    //// POST: api/<controller>/activate
    //[HttpPost("activate")]
    //public async Task<IActionResult> Activate(ActivateCustomerCommand command)
    //{
    //  return Ok(await Mediator.Send(command));
    //}
}
