using Common.Wrappers;
using Mapster;
using MediatR;
using UsersService.Application.Interfaces.Repositories;
using UsersService.Domain.Entities;

namespace UsersService.Application.Features.JobTasks.Commands;

public class CreateJobTaskCommand : IRequest<Response<string>>
{

    public int JobId { get; set; }
    public int AssignedUserId { get; set; }
    public string Details { get; set; }
    public double EstimatedHour { get; set; }
    public double? EstimatedDay { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public double? ActualHour { get; set; }
    public double? ActualDay { get; set; }

}

public class CreateJobTasksCommandHandler : IRequestHandler<CreateJobTaskCommand, Response<string>>
{
  private readonly IJobTaskRepositoryAsync _JobTasksRepository;
  public CreateJobTasksCommandHandler(IJobTaskRepositoryAsync JobTasksRepository)
  {
        _JobTasksRepository = JobTasksRepository;
  }

  public async Task<Response<string>> Handle(CreateJobTaskCommand request, CancellationToken cancellationToken)
  {
    var JobTasks = request.Adapt<JobTask>();

    await _JobTasksRepository.AddAsync(JobTasks);

    return new Response<string>(JobTasks.Id.ToString(), "JobTasks created");
  }
}