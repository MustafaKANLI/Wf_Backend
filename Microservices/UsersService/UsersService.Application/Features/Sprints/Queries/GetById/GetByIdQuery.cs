namespace UsersService.Application.Features.Sprints.Queries.GetById;

using UsersService.Application.Interfaces.Repositories;
using UsersService.Application.Features.SharedViewModels;
using Common.Wrappers;
using Common.Parameters;
using MediatR;
using Mapster;
using Common.Exceptions;

public class GetByIdQuery : IRequest<Response<SprintViewModel>>
{
  public int Id { get; set; }
  
}

public class GetByIdQueryHandler : IRequestHandler<GetByIdQuery, Response<SprintViewModel>>
{
  private readonly ISprintRepositoryAsync _SprintRepository;
  public GetByIdQueryHandler(ISprintRepositoryAsync SprintRepository)
  {
    _SprintRepository = SprintRepository;
  }

  public async Task<Response<SprintViewModel>> Handle(GetByIdQuery request, CancellationToken cancellationToken)
  {

    var Sprint = await _SprintRepository.GetByIdAsync(request.Id);

    
        if(Sprint == null)
        {
            throw new ApiException("Sprint Not Found!");
        }
   

    return new Response<SprintViewModel>(Sprint.Adapt<SprintViewModel>());
  }
}
