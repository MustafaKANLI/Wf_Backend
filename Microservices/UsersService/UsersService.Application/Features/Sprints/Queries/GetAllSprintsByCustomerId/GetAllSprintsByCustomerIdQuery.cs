namespace UsersService.Application.Features.SprintsByCustomerId.Queries.GetAllSprintsByCustomerId;

using UsersService.Application.Interfaces.Repositories;
using UsersService.Application.Features.SharedViewModels;
using Common.Wrappers;
using Common.Parameters;
using MediatR;
using Mapster;
using Common.Exceptions;

public class GetAllSprintsByCustomerIdQuery : IRequest<ListedResponse<IEnumerable<SprintViewModel>>>
{
    public int CustomerId { get; set; }
}

public class GetAllSprintsByCustomerIdQueryHandler : IRequestHandler<GetAllSprintsByCustomerIdQuery, ListedResponse<IEnumerable<SprintViewModel>>>
{
    private readonly ISprintRepositoryAsync _SprintsRepository;
    private readonly ICustomerRepositoryAsync _CustomerRepository;
    public GetAllSprintsByCustomerIdQueryHandler(ISprintRepositoryAsync SprintsRepository, ICustomerRepositoryAsync customerRepository)
    {
        _SprintsRepository = SprintsRepository;
        _CustomerRepository = customerRepository;
    }

    public async Task<ListedResponse<IEnumerable<SprintViewModel>>> Handle(GetAllSprintsByCustomerIdQuery request, CancellationToken cancellationToken)
    {
        var Sprints = await _SprintsRepository.GetSprintsByCustomerIdAsync(request.CustomerId);
        var dataCount = Sprints.Count;

        var SprintViewModels = new List<SprintViewModel>();

        foreach (var p in Sprints)
        {
            var Sprint = p.Adapt<SprintViewModel>();

            var Customer = await _CustomerRepository.GetByIdAsync(p.CustomerId);
            if (Customer == null)
            {
                throw new ApiException("Customer cannot found!");
            }

            Sprint.CustomerName = Customer.Name;

            SprintViewModels.Add(Sprint);
        }

        return new ListedResponse<IEnumerable<SprintViewModel>>(SprintViewModels, dataCount);
    }

}
