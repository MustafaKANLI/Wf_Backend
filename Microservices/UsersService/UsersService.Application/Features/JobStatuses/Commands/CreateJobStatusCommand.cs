using Common.Wrappers;
using Mapster;
using MediatR;
using UsersService.Application.Interfaces.Repositories;
using UsersService.Domain.Entities;

namespace UsersService.Application.Features.JobStatuses.Commands;

public class CreateJobStatusCommand : IRequest<Response<string>>
{

    public string Name { get; set; }
    public int? PreviousStatus { get; set; }
    public int? NextStatus { get; set; }
    public string? Description { get; set; }

}

public class CreateJobStatusesCommandHandler : IRequestHandler<CreateJobStatusCommand, Response<string>>
{
  private readonly IJobStatusRepositoryAsync _JobStatusesRepository;
  public CreateJobStatusesCommandHandler(IJobStatusRepositoryAsync JobStatusesRepository)
  {
        _JobStatusesRepository = JobStatusesRepository;
  }

  public async Task<Response<string>> Handle(CreateJobStatusCommand request, CancellationToken cancellationToken)
  {
    var JobStatuses = request.Adapt<JobStatus>();

    await _JobStatusesRepository.AddAsync(JobStatuses);

    return new Response<string>(JobStatuses.Id.ToString(), "JobStatus created");
  }
}