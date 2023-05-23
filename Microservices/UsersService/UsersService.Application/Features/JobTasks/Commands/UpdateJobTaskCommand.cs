using Common.Exceptions;
using Common.Wrappers;
using Mapster;
using MediatR;
using UsersService.Application.Interfaces.Repositories;
using UsersService.Domain.Entities;

namespace UsersService.Application.Features.JobTasks.Commands;

public class UpdateJobTaskCommand : IRequest<Response<string>>
{
    public int Id { get; set; }
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

public class UpdateJobTaskCommandHandler : IRequestHandler<UpdateJobTaskCommand, Response<string>>
{
    private readonly IJobTaskRepositoryAsync _JobTaskRepository;
    private readonly IJobRepositoryAsync _JobRepository;
    private readonly IUserRepositoryAsync _UserRepository;
    public UpdateJobTaskCommandHandler(IJobTaskRepositoryAsync JobTaskRepository, IJobRepositoryAsync jobRepository, IUserRepositoryAsync userRepository)
    {
        _JobTaskRepository = JobTaskRepository;
        _JobRepository = jobRepository;
        _UserRepository = userRepository;
    }

    public async Task<Response<string>> Handle(UpdateJobTaskCommand request, CancellationToken cancellationToken)
    {
        var JobTask = await _JobTaskRepository.GetByIdAsync(request.Id);
        if (JobTask == null)
        {
            throw new ApiException("JobTask not found");
        }

        var Job = await _JobRepository.GetByIdAsync(request.JobId);
        if (Job == null)
        {
            throw new ApiException("Job cannot found!");
        }

        var User = await _UserRepository.GetByIdAsync(request.AssignedUserId);
        if (User == null)
        {
            throw new ApiException("User cannot found!");
        }

        JobTask = request.Adapt<JobTask>();

        await _JobTaskRepository.UpdateAsync(JobTask);

        return new Response<string>(JobTask.Id.ToString(), "JobTask Updated");
    }
}