using Common.Exceptions;
using Common.Wrappers;
using Mapster;
using MediatR;
using UsersService.Application.Interfaces.Repositories;
using UsersService.Domain.Entities;

namespace UsersService.Application.Features.JobStatuses.Commands;

public class UpdateJobStatusCommand : IRequest<Response<string>>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int? PreviousStatus { get; set; }
    public int? NextStatus { get; set; }
    public string? Description { get; set; }

}

public class UpdateJobStatusCommandHandler : IRequestHandler<UpdateJobStatusCommand, Response<string>>
{
    private readonly IJobStatusRepositoryAsync _JobStatusRepository;
    public UpdateJobStatusCommandHandler(IJobStatusRepositoryAsync JobStatusRepository)
    {
        _JobStatusRepository = JobStatusRepository;
    }

    public async Task<Response<string>> Handle(UpdateJobStatusCommand request, CancellationToken cancellationToken)
    {
        var JobStatus = await _JobStatusRepository.GetByIdAsync(request.Id);
        if (JobStatus == null)
        {
            throw new ApiException("JobStatus not found");
        }

        JobStatus = request.Adapt<JobStatus>();

        await _JobStatusRepository.UpdateAsync(JobStatus);

        return new Response<string>(JobStatus.Id.ToString(), "JobStatus Updated");
    }
}