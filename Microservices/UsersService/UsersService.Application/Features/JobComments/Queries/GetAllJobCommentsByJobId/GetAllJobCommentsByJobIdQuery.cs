namespace UsersService.Application.Features.JobCommentsByJobId.Queries.GetAllJobCommentsByJobId;

using UsersService.Application.Interfaces.Repositories;
using UsersService.Application.Features.SharedViewModels;
using Common.Wrappers;
using Common.Parameters;
using MediatR;
using Mapster;
using Common.Exceptions;

public class GetAllJobCommentsByJobIdQuery : IRequest<ListedResponse<IEnumerable<JobCommentViewModel>>>
{
    public int JobId { get; set; }
}

public class GetAllJobCommentsByJobIdQueryHandler : IRequestHandler<GetAllJobCommentsByJobIdQuery, ListedResponse<IEnumerable<JobCommentViewModel>>>
{
    private readonly IJobCommentRepositoryAsync _JobCommentRepository;
    private readonly IJobRepositoryAsync _JobRepository;
    private readonly IUserRepositoryAsync _UserRepository;
    public GetAllJobCommentsByJobIdQueryHandler(IJobCommentRepositoryAsync JobCommentRepository, IJobRepositoryAsync JobRepositoryAsync, IUserRepositoryAsync UserRepositoryAsync)
    {
        _JobCommentRepository = JobCommentRepository;
        _JobRepository = JobRepositoryAsync;
        _UserRepository = UserRepositoryAsync;
    }

    public async Task<ListedResponse<IEnumerable<JobCommentViewModel>>> Handle(GetAllJobCommentsByJobIdQuery request, CancellationToken cancellationToken)
    {
        var JobComments = await _JobCommentRepository.GetJobCommentsByJobIdAsync(request.JobId);
        var dataCount = JobComments.Count;

        var JobCommentViewModels = new List<JobCommentViewModel>();

        foreach (var p in JobComments)
        {
            var JobComment = p.Adapt<JobCommentViewModel>();
            JobCommentViewModels.Add(JobComment);

            var Job = await _JobRepository.GetByIdAsync(p.JobId);
            if (Job == null)
            {
                throw new ApiException("Job cannot found!");
            }

            JobComment.JobName = Job.Name;

            var User = await _UserRepository.GetByIdAsync(p.UserId);
            if (User == null)
            {
                throw new ApiException("User cannot found!");
            }
            JobComment.UserName = User.FullName;
        }

        return new ListedResponse<IEnumerable<JobCommentViewModel>>(JobCommentViewModels, dataCount);
    }

}
