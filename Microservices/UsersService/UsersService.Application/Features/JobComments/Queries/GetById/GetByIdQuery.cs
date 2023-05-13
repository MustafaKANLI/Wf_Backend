namespace UsersService.Application.Features.JobComments.Queries.GetById;

using UsersService.Application.Interfaces.Repositories;
using UsersService.Application.Features.SharedViewModels;
using Common.Wrappers;
using Common.Parameters;
using MediatR;
using Mapster;
using Common.Exceptions;

public class GetByIdQuery : IRequest<Response<JobCommentViewModel>>
{
  public int Id { get; set; }
  
}

public class GetByIdQueryHandler : IRequestHandler<GetByIdQuery, Response<JobCommentViewModel>>
{
  private readonly IJobCommentRepositoryAsync _JobCommentRepository;
  public GetByIdQueryHandler(IJobCommentRepositoryAsync JobCommentRepository)
  {
    _JobCommentRepository = JobCommentRepository;
  }

  public async Task<Response<JobCommentViewModel>> Handle(GetByIdQuery request, CancellationToken cancellationToken)
  {

    var JobComment = await _JobCommentRepository.GetByIdAsync(request.Id);

    
        if(JobComment == null)
        {
            throw new ApiException("JobComment Not Found!");
        }
   

    return new Response<JobCommentViewModel>(JobComment.Adapt<JobCommentViewModel>());
  }
}
