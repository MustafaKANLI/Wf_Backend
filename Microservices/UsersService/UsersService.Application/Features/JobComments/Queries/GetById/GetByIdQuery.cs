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
    private readonly IJobRepositoryAsync _JobRepository;
    private readonly IUserRepositoryAsync _UserRepository;
    public GetByIdQueryHandler(IJobCommentRepositoryAsync JobCommentRepository, IJobRepositoryAsync JobRepository, IUserRepositoryAsync userRepository)
    {
        _JobCommentRepository = JobCommentRepository;
        _JobRepository = JobRepository;
        _UserRepository = userRepository;
    }

    public async Task<Response<JobCommentViewModel>> Handle(GetByIdQuery request, CancellationToken cancellationToken)
    {

        var result = await _JobCommentRepository.GetByIdAsync(request.Id);

        if (result == null)
        {
            throw new ApiException("JobComment Not Found!");
        }

        var JobComment = result.Adapt<JobCommentViewModel>();

        var Job = await _JobRepository.GetByIdAsync(result.JobId);
        if (Job == null)
        {
            throw new ApiException("Job cannot found!");
        }

        JobComment.JobName = Job.Name;

        var User = await _UserRepository.GetByIdAsync(result.UserId);
        if (User == null)
        {
            throw new ApiException("User cannot found!");
        }
        JobComment.UserName = User.FullName;


        return new Response<JobCommentViewModel>(JobComment.Adapt<JobCommentViewModel>());
    }
}
