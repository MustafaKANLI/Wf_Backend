namespace UsersService.Application.Features.JobComments.Queries.GetAllJobComments;

using UsersService.Application.Interfaces.Repositories;
using UsersService.Application.Features.SharedViewModels;
using Common.Wrappers;
using Common.Parameters;
using MediatR;
using Mapster;
using Common.Exceptions;
using UsersService.Domain.Entities;

public class GetAllJobCommentsQuery : IRequest<PagedResponse<IEnumerable<JobCommentViewModel>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}

public class GetAllJobCommentsQueryHandler : IRequestHandler<GetAllJobCommentsQuery, PagedResponse<IEnumerable<JobCommentViewModel>>>
{
    private readonly IJobCommentRepositoryAsync _JobCommentsRepository;
    private readonly IJobRepositoryAsync _JobRepository;
    private readonly IUserRepositoryAsync _UserRepository;
    public GetAllJobCommentsQueryHandler(IJobCommentRepositoryAsync JobCommentsRepository, IJobRepositoryAsync JobRepository, IUserRepositoryAsync userRepository)
    {
        _JobCommentsRepository = JobCommentsRepository;
        _JobRepository = JobRepository;
        _UserRepository = userRepository;
    }

    public async Task<PagedResponse<IEnumerable<JobCommentViewModel>>> Handle(GetAllJobCommentsQuery request, CancellationToken cancellationToken)
    {
        var dataCount = await _JobCommentsRepository.GetDataCount();
        var JobComments = await _JobCommentsRepository.GetPagedReponseAsync(request.PageNumber, request.PageSize);

        var JobCommentsViewModels = new List<JobCommentViewModel>();

        foreach (var p in JobComments)
        {
            var JobComment = p.Adapt<JobCommentViewModel>();
            JobCommentsViewModels.Add(JobComment);

            var Job = await _JobRepository.GetByIdAsync(p.JobId);
            if (Job == null)
            {
                throw new ApiException("Job cannot found!");
            }

            JobComment.JobName = Job.Name;

            var User = await _UserRepository.GetByIdAsync(p.UserId);
            if(User == null)
            {
                throw new ApiException("User cannot found!");
            }
            JobComment.UserName = User.FullName;

        }

        return new PagedResponse<IEnumerable<JobCommentViewModel>>(JobCommentsViewModels, request.PageNumber, request.PageSize, dataCount);
    }
}
