using Common.Exceptions;
using Common.Wrappers;
using Mapster;
using MediatR;
using UsersService.Application.Interfaces.Repositories;
using UsersService.Domain.Entities;

namespace UsersService.Application.Features.Customers.Commands;

public class DeleteCustomerCommand : IRequest<Response<string>>
{
    public int Id { get; set; }

}

public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, Response<string>>
{
  private readonly ICustomerRepositoryAsync _customerRepository;
  public DeleteCustomerCommandHandler(ICustomerRepositoryAsync customerRepository)
  {
        _customerRepository = customerRepository;
  }

  public async Task<Response<string>> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
  {
        await _customerRepository.DeleteAsync(request.Id);
        return new Response<string>(request.Id + " Customer deleted");
  }
}