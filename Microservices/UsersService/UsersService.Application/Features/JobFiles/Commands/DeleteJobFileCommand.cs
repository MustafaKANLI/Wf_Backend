using Common.Wrappers;
using MediatR;
using UsersService.Application.Interfaces.Repositories;


namespace UsersService.Application.Features.JobFiles.Commands;

public class DeleteJobFileCommand : IRequest<Response<string>>
{
    public int Id { get; set; }

}

public class DeleteJobFileCommandHandler : IRequestHandler<DeleteJobFileCommand, Response<string>>
{
    private readonly IJobFileRepositoryAsync _JobFileRepository;
    public DeleteJobFileCommandHandler(IJobFileRepositoryAsync JobFileRepository)
    {
        _JobFileRepository = JobFileRepository;
    }

    public async Task<Response<string>> Handle(DeleteJobFileCommand request, CancellationToken cancellationToken)
    {
        await _JobFileRepository.DeleteAsync(request.Id);
        return new Response<string>(request.Id + " JobFile deleted");
    }
}