using Common.Exceptions;
using Common.Wrappers;
using Mapster;
using MediatR;
using UsersService.Application.Interfaces.Repositories;
using UsersService.Domain.Entities;

namespace UsersService.Application.Features.JobTasks.Commands;

public class DeleteJobTaskCommand : IRequest<Response<string>>
{
    public int Id { get; set; }

}

public class DeleteJobTaskCommandHandler : IRequestHandler<DeleteJobTaskCommand, Response<string>>
{
    private readonly IJobTaskRepositoryAsync _JobTaskRepository;
    public DeleteJobTaskCommandHandler(IJobTaskRepositoryAsync JobTaskRepository)
    {
        _JobTaskRepository = JobTaskRepository;
    }

    public async Task<Response<string>> Handle(DeleteJobTaskCommand request, CancellationToken cancellationToken)
    {
        await _JobTaskRepository.DeleteAsync(request.Id);
        return new Response<string>(request.Id + " JobTask deleted");
    }
}