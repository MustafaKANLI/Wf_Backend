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
    private readonly IUserRepositoryAsync _UserRepository;
    private readonly IProjectRepositoryAsync _ProjectRepository;

    public GetProjectsByUserIdQueryHandler(IUserRepositoryAsync UserRepositoryAsync,IProjectRepositoryAsync projectRepository)
    {
        _UserRepository = UserRepositoryAsync;
        _ProjectRepository = projectRepository;
    }

    public async Task<ListedResponse<IEnumerable<ProjectViewModel>>> Handle(GetProjectsByUserIdQuery request, CancellationToken cancellationToken)
    {
        var Projects = await _ProjectRepository.GetProjectsByUserIdAsync(request.UserId);
        var dataCount = Projects.Count;

        var ProjectViewModels = new List<ProjectViewModel>();

        foreach (var p in Projects)
        {
            var result = p.Adapt<ProjectViewModel>();

            // TODO: Buraya eklenenler diğer ProjectUsers Query'lerine de eklenecek

            ProjectViewModels.Add(result);
        }

        return new ListedResponse<IEnumerable<ProjectViewModel>>(ProjectViewModels, dataCount);
    }

}
