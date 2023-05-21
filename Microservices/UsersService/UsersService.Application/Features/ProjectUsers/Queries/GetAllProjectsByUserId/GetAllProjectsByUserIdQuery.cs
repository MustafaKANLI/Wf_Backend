namespace UsersService.Application.Features.ProjectsByUserId.Queries.GetAllProjectsByUserId;

using UsersService.Application.Interfaces.Repositories;
using UsersService.Application.Features.SharedViewModels;
using Common.Wrappers;
using MediatR;
using Mapster;
using Common.Exceptions;


public class GetAllProjectsByUserIdQuery : IRequest<ListedResponse<IEnumerable<ProjectUserViewModel>>>
{
    public int UserId { get; set; }
}

public class GetAllProjectsByUserIdQueryHandler : IRequestHandler<GetAllProjectsByUserIdQuery, ListedResponse<IEnumerable<ProjectUserViewModel>>>
{
    private readonly IProjectUserRepositoryAsync _ProjectUsersRepository;
    private readonly IUserRepositoryAsync _UserRepository;
    private readonly IProjectRepositoryAsync _ProjectRepository;

    public GetAllProjectsByUserIdQueryHandler(IProjectUserRepositoryAsync ProjectUsersRepository, IUserRepositoryAsync UserRepositoryAsync,IProjectRepositoryAsync projectRepository)
    {
        _ProjectUsersRepository = ProjectUsersRepository;
        _UserRepository = UserRepositoryAsync;
        _ProjectRepository = projectRepository;
    }

    public async Task<ListedResponse<IEnumerable<ProjectUserViewModel>>> Handle(GetAllProjectsByUserIdQuery request, CancellationToken cancellationToken)
    {
        var Projects = await _ProjectUsersRepository.GetProjectsByUserIdAsync(request.UserId);
        var dataCount = Projects.Count;

        var ProjectUserViewModels = new List<ProjectUserViewModel>();

        foreach (var p in Projects)
        {
            var result = p.Adapt<ProjectUserViewModel>();

            // TODO: Buraya eklenenler diğer ProjectUsers Query'lerine de eklenecek

            var Project = await _ProjectRepository.GetByIdAsync(p.ProjectId);
            if (Project == null)
            {
                throw new ApiException("Project cannot found!");
            }
            result.ProjectName = Project.Name;

            var User = await _UserRepository.GetByIdAsync(p.UserId);
            if (User == null)
            {
                throw new ApiException("CreateUser cannot found!");
            }
            result.UserName = User.FullName;

            ProjectUserViewModels.Add(result);
        }

        return new ListedResponse<IEnumerable<ProjectUserViewModel>>(ProjectUserViewModels, dataCount);
    }

}
