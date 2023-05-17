using Common.Wrappers;
using Mapster;
using MediatR;
using UsersService.Application.Interfaces.Repositories;
using UsersService.Domain.Entities;

namespace UsersService.Application.Features.Sprints.Commands;

public class CreateSprintCommand : IRequest<Response<string>>
{

    public int CustomerId { get; set; }
    public string Name { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

}

public class CreateSprintsCommandHandler : IRequestHandler<CreateSprintCommand, Response<string>>
{
  private readonly ISprintRepositoryAsync _SprintsRepository;
  public CreateSprintsCommandHandler(ISprintRepositoryAsync SprintsRepository)
  {
        _SprintsRepository = SprintsRepository;
  }

  public async Task<Response<string>> Handle(CreateSprintCommand request, CancellationToken cancellationToken)
  {
    var Sprints = request.Adapt<Sprint>();

    await _SprintsRepository.AddAsync(Sprints);

    return new Response<string>(Sprints.Id.ToString(), "Sprint created");
  }
}