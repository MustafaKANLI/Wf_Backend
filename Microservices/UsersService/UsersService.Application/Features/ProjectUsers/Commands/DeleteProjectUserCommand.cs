using Common.Exceptions;
using Common.Wrappers;
using Mapster;
using MediatR;
using UsersService.Application.Interfaces.Repositories;
using UsersService.Domain.Entities;

namespace UsersService.Application.Features.ProjectUsers.Commands;

public class DeleteProjectUserCommand : IRequest<Response<string>>
{
    public int Id { get; set; }

}

public class DeleteProjectUserCommandHandler : IRequestHandler<DeleteProjectUserCommand, Response<string>>
{
    private readonly IProjectUserRepositoryAsync _ProjectUserRepository;
    public DeleteProjectUserCommandHandler(IProjectUserRepositoryAsync ProjectUserRepository)
    {
        _ProjectUserRepository = ProjectUserRepository;
    }

    public async Task<Response<string>> Handle(DeleteProjectUserCommand request, CancellationToken cancellationToken)
    {
        await _ProjectUserRepository.DeleteAsync(request.Id);
        return new Response<string>(request.Id + " ProjectUser deleted");
    }
}