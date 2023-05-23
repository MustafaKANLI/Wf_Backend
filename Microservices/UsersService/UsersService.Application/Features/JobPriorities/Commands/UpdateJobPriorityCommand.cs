using Common.Exceptions;
using Common.Wrappers;
using Mapster;
using MediatR;
using UsersService.Application.Interfaces.Repositories;
using UsersService.Domain.Entities;

namespace UsersService.Application.Features.JobPriorities.Commands;

public class UpdateJobPriorityCommand : IRequest<Response<string>>
{
    public int Id { get; set; }
    public string Name { get; set; }

}

public class UpdateJobPriorityCommandHandler : IRequestHandler<UpdateJobPriorityCommand, Response<string>>
{
    private readonly IJobPriorityRepositoryAsync _JobPriorityRepository;
    public UpdateJobPriorityCommandHandler(IJobPriorityRepositoryAsync JobPriorityRepository)
    {
        _JobPriorityRepository = JobPriorityRepository;
    }

    public async Task<Response<string>> Handle(UpdateJobPriorityCommand request, CancellationToken cancellationToken)
    {
        var Priority = await _JobPriorityRepository.GetByIdAsync(request.Id);
        if (Priority == null)
        {
            throw new ApiException("Priority not found");
        }

        Priority = request.Adapt<JobPriority>();

        await _JobPriorityRepository.UpdateAsync(Priority);

        return new Response<string>(Priority.Id.ToString(), "Priority Updated");
    }
}