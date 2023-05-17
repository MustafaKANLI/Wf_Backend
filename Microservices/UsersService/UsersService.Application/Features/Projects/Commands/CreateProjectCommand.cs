using Common.Wrappers;
using Mapster;
using MediatR;
using UsersService.Application.Interfaces.Repositories;
using UsersService.Domain.Entities;

namespace UsersService.Application.Features.Projects.Commands;

public class CreateProjectCommand : IRequest<Response<string>>
{

    public string Name { get; set; }
    public int CustomerId { get; set; }
    public string Code { get; set; }
    public int ManagerUserId { get; set; }
    public int AnalysisApproverUserId { get; set; }
    public int DayApproverUserId { get; set; }
    public bool? IsActive { get; set; }

}

public class CreateProjectsCommandHandler : IRequestHandler<CreateProjectCommand, Response<string>>
{
  private readonly IProjectRepositoryAsync _ProjectsRepository;
  public CreateProjectsCommandHandler(IProjectRepositoryAsync ProjectsRepository)
  {
        _ProjectsRepository = ProjectsRepository;
  }

  public async Task<Response<string>> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
  {
    var Projects = request.Adapt<Project>();

    await _ProjectsRepository.AddAsync(Projects);

    return new Response<string>(Projects.Id.ToString(), "Project created");
  }
}