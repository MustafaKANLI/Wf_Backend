namespace UsersService.Application.Features.ProjectsByUserId.Queries.GetProjectsByUserId;

using UsersService.Application.Interfaces.Repositories;
using UsersService.Application.Features.SharedViewModels;
using Common.Wrappers;
using MediatR;
using Mapster;
using Common.Exceptions;


public class GetProjectsByUserIdQuery : IRequest<ListedResponse<IEnumerable<ProjectViewModel>>>
{
    public int UserId { get; set; }
}

public class GetProjectsByUserIdQueryHandler : IRequestHandler<GetProjectsByUserIdQuery, ListedResponse<IEnumerable<ProjectViewModel>>>
{
    private readonly IProjectRepositoryAsync _ProjectRepository;
    private readonly IUserRepositoryAsync _UserRepository;
    private readonly ICustomerRepositoryAsync _CustomerRepository;

    public GetProjectsByUserIdQueryHandler(IProjectRepositoryAsync ProjectRepository, IUserRepositoryAsync UserRepository, ICustomerRepositoryAsync customerRepository)
    {
        _ProjectRepository = ProjectRepository;
        _UserRepository = UserRepository;
        _CustomerRepository = customerRepository;
    }

    public async Task<ListedResponse<IEnumerable<ProjectViewModel>>> Handle(GetProjectsByUserIdQuery request, CancellationToken cancellationToken)
    {
        var Projects = await _ProjectRepository.GetProjectsByUserIdAsync(request.UserId);
        var dataCount = Projects.Count;

        var ProjectViewModels = new List<ProjectViewModel>();

        foreach (var p in Projects)
        {
            var Project = p.Adapt<ProjectViewModel>();


            var Customer = await _CustomerRepository.GetByIdAsync(p.CustomerId);
            Project.CustomerName = Customer.Name;

            var Manager = await _UserRepository.GetByIdAsync(p.ManagerUserId);
            Project.ManagerUserName = Manager.FullName;

            var DayApprover = await _UserRepository.GetByIdAsync(p.DayApproverUserId);
            Project.DayApproverUserName = DayApprover.FullName;

            var AnalysisApprover = await _UserRepository.GetByIdAsync(p.AnalysisApproverUserId);
            Project.AnalysisApproverUserName = AnalysisApprover.FullName;

            if (Project.IsActive == true)
            {

                ProjectViewModels.Add(Project);
            }
        }

        return new ListedResponse<IEnumerable<ProjectViewModel>>(ProjectViewModels, dataCount);
    }

}
