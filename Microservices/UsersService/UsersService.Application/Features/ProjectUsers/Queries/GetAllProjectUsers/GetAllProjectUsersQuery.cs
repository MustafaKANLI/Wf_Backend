namespace UsersService.Application.Features.ProjectUsers.Queries.GetAllProjectUsers;

using UsersService.Application.Interfaces.Repositories;
using UsersService.Application.Features.SharedViewModels;
using Common.Wrappers;
using Common.Parameters;
using MediatR;
using Mapster;
using Common.Exceptions;

public class GetAllProjectUsersQuery : IRequest<PagedResponse<IEnumerable<ProjectUserViewModel>>>
{
  public int PageNumber { get; set; }
  public int PageSize { get; set; }
}

public class GetAllProjectUsersQueryHandler : IRequestHandler<GetAllProjectUsersQuery, PagedResponse<IEnumerable<ProjectUserViewModel>>>
{
    private readonly IProjectUserRepositoryAsync _ProjectUsersRepository;
    private readonly IUserRepositoryAsync _UsersRepository;
  public GetAllProjectUsersQueryHandler(IProjectUserRepositoryAsync ProjectUsersRepository, IUserRepositoryAsync usersRepository)
    {
        _ProjectUsersRepository = ProjectUsersRepository;
        _UsersRepository = usersRepository;
    }

    public async Task<PagedResponse<IEnumerable<ProjectUserViewModel>>> Handle(GetAllProjectUsersQuery request, CancellationToken cancellationToken)
  {
    var dataCount = await _ProjectUsersRepository.GetDataCount();
    var ProjectUsers = await _ProjectUsersRepository.GetPagedReponseAsync(request.PageNumber, request.PageSize);

    var ProjectUsersViewModels = new List<ProjectUserViewModel>();

    foreach (var p in ProjectUsers)
    {
        var ProjectUser = p.Adapt<ProjectUserViewModel>();
        ProjectUsersViewModels.Add(ProjectUser);

    }

    return new PagedResponse<IEnumerable<ProjectUserViewModel>>(ProjectUsersViewModels, request.PageNumber, request.PageSize, dataCount);
  }
}
