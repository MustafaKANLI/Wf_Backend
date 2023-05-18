using Common.Exceptions;
using Common.Wrappers;
using Mapster;
using MediatR;
using UsersService.Application.Interfaces.Repositories;
using UsersService.Domain.Entities;

namespace UsersService.Application.Features.Customers.Commands;

public class UpdateCustomerCommand : IRequest<Response<string>>
{
    public int Id { get; set; }
    public string Name { get; set; }

}

public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, Response<string>>
{
    private readonly ICustomerRepositoryAsync _customerRepository;
    public UpdateCustomerCommandHandler(ICustomerRepositoryAsync customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<Response<string>> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = await _customerRepository.GetByIdAsync(request.Id);
        if (customer == null)
        {
            throw new ApiException("Customer not found");
        }

        customer = request.Adapt<Customer>();

        await _customerRepository.UpdateAsync(customer);

        return new Response<string>(customer.Id.ToString(), "Customer Updated");
    }
}