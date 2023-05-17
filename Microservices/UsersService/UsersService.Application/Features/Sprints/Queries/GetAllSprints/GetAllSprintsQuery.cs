namespace UsersService.Application.Features.Sprints.Queries.GetAllSprints;

using UsersService.Application.Interfaces.Repositories;
using UsersService.Application.Features.SharedViewModels;
using Common.Wrappers;
using Common.Parameters;
using MediatR;
using Mapster;
using Common.Exceptions;

public class GetAllSprintsQuery : IRequest<PagedResponse<IEnumerable<SprintViewModel>>>
{
  public int PageNumber { get; set; }
  public int PageSize { get; set; }
}

public class GetAllSprintsQueryHandler : IRequestHandler<GetAllSprintsQuery, PagedResponse<IEnumerable<SprintViewModel>>>
{
    private readonly ISprintRepositoryAsync _SprintsRepository;
    
  public GetAllSprintsQueryHandler(ISprintRepositoryAsync SprintsRepository, IUserRepositoryAsync usersRepository)
    {
        _SprintsRepository = SprintsRepository;
       
    }

    public async Task<PagedResponse<IEnumerable<SprintViewModel>>> Handle(GetAllSprintsQuery request, CancellationToken cancellationToken)
  {
    var dataCount = await _SprintsRepository.GetDataCount();
    var Sprints = await _SprintsRepository.GetPagedReponseAsync(request.PageNumber, request.PageSize);

    var SprintsViewModels = new List<SprintViewModel>();

    foreach (var p in Sprints)
    {
        var Sprint = p.Adapt<SprintViewModel>();
        SprintsViewModels.Add(Sprint);

    }

    return new PagedResponse<IEnumerable<SprintViewModel>>(SprintsViewModels, request.PageNumber, request.PageSize, dataCount);
  }
}
