namespace UsersService.Application.Features.Projects.Queries.GetById;

using UsersService.Application.Interfaces.Repositories;
using UsersService.Application.Features.SharedViewModels;
using Common.Wrappers;
using Common.Parameters;
using MediatR;
using Mapster;
using Common.Exceptions;

public class GetByIdQuery : IRequest<Response<ProjectViewModel>>
{
  public int Id { get; set; }
  
}

public class GetByIdQueryHandler : IRequestHandler<GetByIdQuery, Response<ProjectViewModel>>
{
  private readonly IProjectRepositoryAsync _ProjectRepository;
  public GetByIdQueryHandler(IProjectRepositoryAsync ProjectRepository)
  {
    _ProjectRepository = ProjectRepository;
  }

  public async Task<Response<ProjectViewModel>> Handle(GetByIdQuery request, CancellationToken cancellationToken)
  {

    var Project = await _ProjectRepository.GetByIdAsync(request.Id);

    
        if(Project == null)
        {
            throw new ApiException("Project Not Found!");
        }
   

    return new Response<ProjectViewModel>(Project.Adapt<ProjectViewModel>());
  }
}
