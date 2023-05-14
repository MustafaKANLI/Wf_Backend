namespace UsersService.Application.Features.JobFiles.Queries.GetById;

using UsersService.Application.Interfaces.Repositories;
using UsersService.Application.Features.SharedViewModels;
using Common.Wrappers;
using Common.Parameters;
using MediatR;
using Mapster;
using Common.Exceptions;

public class GetByIdQuery : IRequest<Response<JobFileViewModel>>
{
  public int Id { get; set; }
  
}

public class GetByIdQueryHandler : IRequestHandler<GetByIdQuery, Response<JobFileViewModel>>
{
  private readonly IJobFileRepositoryAsync _JobFileRepository;
  public GetByIdQueryHandler(IJobFileRepositoryAsync JobFileRepository)
  {
    _JobFileRepository = JobFileRepository;
  }

  public async Task<Response<JobFileViewModel>> Handle(GetByIdQuery request, CancellationToken cancellationToken)
  {

    var JobFile = await _JobFileRepository.GetByIdAsync(request.Id);

    
        if(JobFile == null)
        {
            throw new ApiException("JobFile Not Found!");
        }
   

    return new Response<JobFileViewModel>(JobFile.Adapt<JobFileViewModel>());
  }
}
