using Common.Exceptions;
using Common.Wrappers;
using Mapster;
using MediatR;
using UsersService.Application.Interfaces.Repositories;
using UsersService.Domain.Entities;

namespace UsersService.Application.Features.Projects.Commands;

public class DeleteProjectCommand : IRequest<Response<string>>
{
    public int Id { get; set; }

}

public class DeleteProjectCommandHandler : IRequestHandler<DeleteProjectCommand, Response<string>>
{
    private readonly IProjectRepositoryAsync _ProjectRepository;
    public DeleteProjectCommandHandler(IProjectRepositoryAsync ProjectRepository)
    {
        _ProjectRepository = ProjectRepository;
    }

    public async Task<Response<string>> Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
    {
        await _ProjectRepository.DeleteAsync(request.Id);
        return new Response<string>(request.Id + " Project deleted");
    }
}