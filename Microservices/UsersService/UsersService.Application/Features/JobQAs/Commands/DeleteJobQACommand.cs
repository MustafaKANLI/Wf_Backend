using Common.Exceptions;
using Common.Wrappers;
using Mapster;
using MediatR;
using UsersService.Application.Interfaces.Repositories;
using UsersService.Domain.Entities;

namespace UsersService.Application.Features.JobQAs.Commands;

public class DeleteJobQACommand : IRequest<Response<string>>
{
    public int Id { get; set; }

}

public class DeleteJobQACommandHandler : IRequestHandler<DeleteJobQACommand, Response<string>>
{
    private readonly IJobQARepositoryAsync _JobQARepository;
    public DeleteJobQACommandHandler(IJobQARepositoryAsync JobQARepository)
    {
        _JobQARepository = JobQARepository;
    }

    public async Task<Response<string>> Handle(DeleteJobQACommand request, CancellationToken cancellationToken)
    {
        await _JobQARepository.DeleteAsync(request.Id);
        return new Response<string>(request.Id + " JobQA deleted");
    }
}