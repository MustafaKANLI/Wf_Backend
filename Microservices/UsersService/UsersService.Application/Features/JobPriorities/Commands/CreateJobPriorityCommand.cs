using Common.Wrappers;
using Mapster;
using MediatR;
using UsersService.Application.Interfaces.Repositories;
using UsersService.Domain.Entities;

namespace UsersService.Application.Features.JobPriorities.Commands;

public class CreateJobPriorityCommand : IRequest<Response<string>>
{
    public string Name { get; set; }


}

public class CreateJobPriorityCommandHandler : IRequestHandler<CreateJobPriorityCommand, Response<string>>
{
    private readonly IJobPriorityRepositoryAsync _JobPriorityRepository;
    public CreateJobPriorityCommandHandler(IJobPriorityRepositoryAsync JobPriorityRepository)
    {
        _JobPriorityRepository = JobPriorityRepository;
    }

    public async Task<Response<string>> Handle(CreateJobPriorityCommand request, CancellationToken cancellationToken)
    {
        var JobPriority = request.Adapt<JobPriority>();

        await _JobPriorityRepository.AddAsync(JobPriority);

        return new Response<string>(JobPriority.Id.ToString(), "JobPriority created");
    }
}