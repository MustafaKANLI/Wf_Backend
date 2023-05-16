namespace UsersService.Application.Features.JobQAs.Queries.GetById;

using UsersService.Application.Interfaces.Repositories;
using UsersService.Application.Features.SharedViewModels;
using Common.Wrappers;
using Common.Parameters;
using MediatR;
using Mapster;
using Common.Exceptions;

public class GetByIdQuery : IRequest<Response<JobQAViewModel>>
{
  public int Id { get; set; }
  
}

public class GetByIdQueryHandler : IRequestHandler<GetByIdQuery, Response<JobQAViewModel>>
{
  private readonly IJobQARepositoryAsync _JobQARepository;
  public GetByIdQueryHandler(IJobQARepositoryAsync JobQARepository)
  {
    _JobQARepository = JobQARepository;
  }

  public async Task<Response<JobQAViewModel>> Handle(GetByIdQuery request, CancellationToken cancellationToken)
  {

    var JobQA = await _JobQARepository.GetByIdAsync(request.Id);

    
        if(JobQA == null)
        {
            throw new ApiException("JobQA Not Found!");
        }
   

    return new Response<JobQAViewModel>(JobQA.Adapt<JobQAViewModel>());
  }
}
