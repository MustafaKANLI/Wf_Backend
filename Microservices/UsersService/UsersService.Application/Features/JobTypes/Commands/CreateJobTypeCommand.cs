using Common.Wrappers;
using Mapster;
using MediatR;
using UsersService.Application.Interfaces.Repositories;
using UsersService.Domain.Entities;

namespace UsersService.Application.Features.JobTypes.Commands;

public class CreateJobTypeCommand : IRequest<Response<string>>
{

    public string Name { get; set; }
    public string? Details { get; set; }

}

public class CreateJobTypesCommandHandler : IRequestHandler<CreateJobTypeCommand, Response<string>>
{
  private readonly IJobTypeRepositoryAsync _JobTypesRepository;
  public CreateJobTypesCommandHandler(IJobTypeRepositoryAsync JobTypesRepository)
  {
        _JobTypesRepository = JobTypesRepository;
  }

  public async Task<Response<string>> Handle(CreateJobTypeCommand request, CancellationToken cancellationToken)
  {
    var JobTypes = request.Adapt<JobType>();

    await _JobTypesRepository.AddAsync(JobTypes);

    return new Response<string>(JobTypes.Id.ToString(), "JobTypes created");
  }
}