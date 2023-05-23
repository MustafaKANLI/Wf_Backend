using Common.Wrappers;
using MediatR;
using UsersService.Application.Interfaces.Repositories;


namespace UsersService.Application.Features.JobPriorities.Commands;

public class DeleteJobPriorityCommand : IRequest<Response<string>>
{
    public int Id { get; set; }
}

public class DeleteJobPriorityCommandHandler : IRequestHandler<DeleteJobPriorityCommand, Response<string>>
{
    private readonly IJobPriorityRepositoryAsync _JobPriorityRepository;
    public DeleteJobPriorityCommandHandler(IJobPriorityRepositoryAsync JobPriorityRepository)
    {
        _JobPriorityRepository = JobPriorityRepository;
    }

    public async Task<Response<string>> Handle(DeleteJobPriorityCommand request, CancellationToken cancellationToken)
    {
        await _JobPriorityRepository.DeleteAsync(request.Id);
        return new Response<string>(request.Id + " JobPriority deleted");
    }
}