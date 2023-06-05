using Common.Exceptions;
using Common.Wrappers;
using Mapster;
using MediatR;
using UsersService.Application.Interfaces.Repositories;
using UsersService.Domain.Entities;

namespace UsersService.Application.Features.ProjectUsers.Commands;

public class UpdateProjectUserCommand : IRequest<Response<string>>
{
    public int Id { get; set; }
    public int ProjectId { get; set; }
    public int UserId { get; set; }
}

public class UpdateProjectUserCommandHandler : IRequestHandler<UpdateProjectUserCommand, Response<string>>
{
    private readonly IProjectUserRepositoryAsync _ProjectUserRepository;

    public UpdateProjectUserCommandHandler(IProjectUserRepositoryAsync ProjectUserRepository)
    {
        _ProjectUserRepository = ProjectUserRepository;
    }

    public async Task<Response<string>> Handle(UpdateProjectUserCommand request, CancellationToken cancellationToken)
    {
        var ProjectUser = await _ProjectUserRepository.GetByIdAsync(request.Id);
        if (ProjectUser == null)
        {
            throw new ApiException("ProjectUser not found");
        }

        ProjectUser = request.Adapt<ProjectUser>();

        await _ProjectUserRepository.UpdateAsync(ProjectUser);

        return new Response<string>(ProjectUser.Id.ToString(), "ProjectUser Updated");
    }
}