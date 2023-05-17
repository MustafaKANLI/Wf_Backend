using Common.Wrappers;
using Mapster;
using MediatR;
using UsersService.Application.Interfaces.Repositories;
using UsersService.Domain.Entities;

namespace UsersService.Application.Features.ProjectUsers.Commands;

public class CreateProjectUserCommand : IRequest<Response<string>>
{

    public int ProjectId { get; set; }
    public int UserId { get; set; }

}

public class CreateProjectUsersCommandHandler : IRequestHandler<CreateProjectUserCommand, Response<string>>
{
  private readonly IProjectUserRepositoryAsync _ProjectUsersRepository;
  public CreateProjectUsersCommandHandler(IProjectUserRepositoryAsync ProjectUsersRepository)
  {
        _ProjectUsersRepository = ProjectUsersRepository;
  }

  public async Task<Response<string>> Handle(CreateProjectUserCommand request, CancellationToken cancellationToken)
  {
    var ProjectUsers = request.Adapt<ProjectUser>();

    await _ProjectUsersRepository.AddAsync(ProjectUsers);

    return new Response<string>(ProjectUsers.Id.ToString(), "ProjectUser created");
  }
}