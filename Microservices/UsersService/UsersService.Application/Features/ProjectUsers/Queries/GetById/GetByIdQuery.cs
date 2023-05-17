namespace UsersService.Application.Features.ProjectUsers.Queries.GetById;

using UsersService.Application.Interfaces.Repositories;
using UsersService.Application.Features.SharedViewModels;
using Common.Wrappers;
using Common.Parameters;
using MediatR;
using Mapster;
using Common.Exceptions;

public class GetByIdQuery : IRequest<Response<ProjectUserViewModel>>
{
  public int Id { get; set; }
  
}

public class GetByIdQueryHandler : IRequestHandler<GetByIdQuery, Response<ProjectUserViewModel>>
{
  private readonly IProjectUserRepositoryAsync _ProjectUserRepository;
  public GetByIdQueryHandler(IProjectUserRepositoryAsync ProjectUserRepository)
  {
    _ProjectUserRepository = ProjectUserRepository;
  }

  public async Task<Response<ProjectUserViewModel>> Handle(GetByIdQuery request, CancellationToken cancellationToken)
  {

    var ProjectUser = await _ProjectUserRepository.GetByIdAsync(request.Id);

    
        if(ProjectUser == null)
        {
            throw new ApiException("ProjectUser Not Found!");
        }
   

    return new Response<ProjectUserViewModel>(ProjectUser.Adapt<ProjectUserViewModel>());
  }
}
