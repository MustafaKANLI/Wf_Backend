using Common.Wrappers;
using Mapster;
using MediatR;
using UsersService.Application.Interfaces.Repositories;
using UsersService.Domain.Entities;

namespace UsersService.Application.Features.Customers.Commands;

public class CreateCustomerCommand : IRequest<Response<string>>
{
    public string Email { get; set; }
    public string Password { get; set; }
    public string UserName { get; set; }
    public string FullName { get; set; }
    public int CustomerId { get; set; }
    public int ClaimId { get; set; }
    public string Phone { get; set; }

}

public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, Response<string>>
{
  private readonly ICustomerRepositoryAsync _customerRepository;
  public CreateCustomerCommandHandler(ICustomerRepositoryAsync customerRepository)
  {
        _customerRepository = customerRepository;
  }

  public async Task<Response<string>> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
  {
    var customer = request.Adapt<Customer>();

    await _customerRepository.AddAsync(customer);

    return new Response<string>(customer.Id.ToString(), "Customer created");
  }
}