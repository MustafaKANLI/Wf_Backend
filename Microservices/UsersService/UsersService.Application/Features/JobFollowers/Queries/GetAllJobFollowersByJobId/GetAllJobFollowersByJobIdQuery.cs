namespace UsersService.Application.Features.JobFollowersByJobId.Queries.GetAllJobFollowersByJobId;

using UsersService.Application.Interfaces.Repositories;
using UsersService.Application.Features.SharedViewModels;
using Common.Wrappers;
using Common.Parameters;
using MediatR;
using Mapster;
using Common.Exceptions;

public class GetAllJobFollowersByJobIdQuery : IRequest<ListedResponse<IEnumerable<JobFollowerViewModel>>>
{
    public int JobId { get; set; }
}

public class GetAllJobFollowersByJobIdQueryHandler : IRequestHandler<GetAllJobFollowersByJobIdQuery, ListedResponse<IEnumerable<JobFollowerViewModel>>>
{
    private readonly IJobFollowerRepositoryAsync _JobFollowerRepository;
    private readonly IJobRepositoryAsync _JobRepository;
    private readonly IUserRepositoryAsync _UserRepository;
    public GetAllJobFollowersByJobIdQueryHandler(IJobFollowerRepositoryAsync JobFollowerRepository, IJobRepositoryAsync JobRepositoryAsync, IUserRepositoryAsync UserRepositoryAsync)
    {
        _JobFollowerRepository = JobFollowerRepository;
        _JobRepository = JobRepositoryAsync;
        _UserRepository = UserRepositoryAsync;
    }

    public async Task<ListedResponse<IEnumerable<JobFollowerViewModel>>> Handle(GetAllJobFollowersByJobIdQuery request, CancellationToken cancellationToken)
    {
        var JobFollowers = await _JobFollowerRepository.GetJobFollowersByJobIdAsync(request.JobId);
        var dataCount = JobFollowers.Count;

        var JobFollowerViewModels = new List<JobFollowerViewModel>();

        foreach (var p in JobFollowers)
        {
            var JobFollower = p.Adapt<JobFollowerViewModel>();
            JobFollowerViewModels.Add(JobFollower);

            var Job = await _JobRepository.GetByIdAsync(p.JobId);
            if (Job == null)
            {
                throw new ApiException("Job cannot found!");
            }

            JobFollower.JobName = Job.Name;

            var User = await _UserRepository.GetByIdAsync(p.UserId);
            if (User == null)
            {
                throw new ApiException("User cannot found!");
            }
            JobFollower.UserName = User.FullName;
        }

        return new ListedResponse<IEnumerable<JobFollowerViewModel>>(JobFollowerViewModels, dataCount);
    }

}
