namespace UsersService.Application.Features.Projects.Queries.GetAllProjects;

using UsersService.Application.Interfaces.Repositories;
using UsersService.Application.Features.SharedViewModels;
using Common.Wrappers;
using Common.Parameters;
using MediatR;
using Mapster;
using Common.Exceptions;

public class GetAllProjectsQuery : IRequest<PagedResponse<IEnumerable<ProjectViewModel>>>
{
  public int PageNumber { get; set; }
  public int PageSize { get; set; }
}

public class GetAllProjectsQueryHandler : IRequestHandler<GetAllProjectsQuery, PagedResponse<IEnumerable<ProjectViewModel>>>
{
    private readonly IProjectRepositoryAsync _ProjectsRepository;
    private readonly IUserRepositoryAsync _UsersRepository;
  public GetAllProjectsQueryHandler(IProjectRepositoryAsync ProjectsRepository, IUserRepositoryAsync usersRepository)
    {
        _ProjectsRepository = ProjectsRepository;
        _UsersRepository = usersRepository;
    }

    public async Task<PagedResponse<IEnumerable<ProjectViewModel>>> Handle(GetAllProjectsQuery request, CancellationToken cancellationToken)
  {
    var dataCount = await _ProjectsRepository.GetDataCount();
    var Projects = await _ProjectsRepository.GetPagedReponseAsync(request.PageNumber, request.PageSize);

    var ProjectsViewModels = new List<ProjectViewModel>();

    foreach (var p in Projects)
    {
        var Project = p.Adapt<ProjectViewModel>();
        ProjectsViewModels.Add(Project);

    }

    return new PagedResponse<IEnumerable<ProjectViewModel>>(ProjectsViewModels, request.PageNumber, request.PageSize, dataCount);
  }
}
