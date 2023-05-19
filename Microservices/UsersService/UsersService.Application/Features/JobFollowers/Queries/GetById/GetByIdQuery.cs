namespace UsersService.Application.Features.JobFollowers.Queries.GetById;

using UsersService.Application.Interfaces.Repositories;
using UsersService.Application.Features.SharedViewModels;
using Common.Wrappers;
using Common.Parameters;
using MediatR;
using Mapster;
using Common.Exceptions;

public class GetByIdQuery : IRequest<Response<JobFollowerViewModel>>
{
    public int Id { get; set; }

}

public class GetByIdQueryHandler : IRequestHandler<GetByIdQuery, Response<JobFollowerViewModel>>
{
    private readonly IJobFollowerRepositoryAsync _JobFollowerRepository;
    private readonly IJobRepositoryAsync _JobRepository;
    private readonly IUserRepositoryAsync _UserRepository;
    public GetByIdQueryHandler(IJobFollowerRepositoryAsync JobFollowerRepository, IJobRepositoryAsync jobRepository, IUserRepositoryAsync userRepository)
    {
        _JobFollowerRepository = JobFollowerRepository;
        _JobRepository = jobRepository;
        _UserRepository = userRepository;
    }

    public async Task<Response<JobFollowerViewModel>> Handle(GetByIdQuery request, CancellationToken cancellationToken)
    {

        var result = await _JobFollowerRepository.GetByIdAsync(request.Id);


        if (result == null)
        {
            throw new ApiException("JobFollower Not Found!");
        }

        var JobFollower = result.Adapt<JobFollowerViewModel>();

        var Job = await _JobRepository.GetByIdAsync(JobFollower.JobId);
        if (Job == null)
        {
            throw new ApiException("Job cannot found!");
        }

        JobFollower.JobName = Job.Name;

        var User = await _UserRepository.GetByIdAsync(JobFollower.UserId);
        if (User == null)
        {
            throw new ApiException("User cannot found!");
        }
        JobFollower.UserName = User.FullName;


        return new Response<JobFollowerViewModel>(JobFollower);
    }
}
