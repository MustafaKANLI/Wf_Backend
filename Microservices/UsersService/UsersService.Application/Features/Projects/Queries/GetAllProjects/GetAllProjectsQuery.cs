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
    private readonly ICustomerRepositoryAsync _CustomerRepository;
    private readonly IUserRepositoryAsync _UserRepository;
    public GetAllProjectsQueryHandler(IProjectRepositoryAsync ProjectsRepository, ICustomerRepositoryAsync CustomerRepository, IUserRepositoryAsync userRepository)
    {
        _ProjectsRepository = ProjectsRepository;
        _CustomerRepository = CustomerRepository;
        _UserRepository = userRepository;
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

        var Customer = await _CustomerRepository.GetByIdAsync(p.CustomerId);
        Project.CustomerName = Customer.Name;

        var Manager = await _UserRepository.GetByIdAsync(p.ManagerUserId);
        Project.ManagerUserName = Manager.FullName;

        var DayApprover = await _UserRepository.GetByIdAsync(p.DayApproverUserId);
        Project.DayApproverUserName = DayApprover.FullName;

        var AnalysisApprover = await _UserRepository.GetByIdAsync(p.AnalysisApproverUserId);
        Project.AnalysisApproverUserName = AnalysisApprover.FullName;

    }

    return new PagedResponse<IEnumerable<ProjectViewModel>>(ProjectsViewModels, request.PageNumber, request.PageSize, dataCount);
  }
}
