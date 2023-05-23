namespace UsersService.Application.Features.JobTasksByJobId.Queries.GetAllJobTasksByJobId;

using UsersService.Application.Interfaces.Repositories;
using UsersService.Application.Features.SharedViewModels;
using Common.Wrappers;
using Common.Parameters;
using MediatR;
using Mapster;
using Common.Exceptions;

public class GetAllJobTasksByJobIdQuery : IRequest<ListedResponse<IEnumerable<JobTaskViewModel>>>
{
    public int JobId { get; set; }
}

public class GetAllJobTasksByJobIdQueryHandler : IRequestHandler<GetAllJobTasksByJobIdQuery, ListedResponse<IEnumerable<JobTaskViewModel>>>
{
    private readonly IJobTaskRepositoryAsync _JobTaskRepository;
    private readonly IJobRepositoryAsync _JobRepository;
    private readonly IUserRepositoryAsync _UserRepository;
    public GetAllJobTasksByJobIdQueryHandler(IJobTaskRepositoryAsync JobTaskRepository, IJobRepositoryAsync JobRepositoryAsync, IUserRepositoryAsync UserRepositoryAsync)
    {
        _JobTaskRepository = JobTaskRepository;
        _JobRepository = JobRepositoryAsync;
        _UserRepository = UserRepositoryAsync;
    }

    public async Task<ListedResponse<IEnumerable<JobTaskViewModel>>> Handle(GetAllJobTasksByJobIdQuery request, CancellationToken cancellationToken)
    {
        var JobTasks = await _JobTaskRepository.GetJobTasksByJobIdAsync(request.JobId);
        var dataCount = JobTasks.Count;

        var JobTaskViewModels = new List<JobTaskViewModel>();

        foreach (var p in JobTasks)
        {
            var JobTask = p.Adapt<JobTaskViewModel>();
            JobTaskViewModels.Add(JobTask);

            var Job = await _JobRepository.GetByIdAsync(p.JobId);
            if (Job == null)
            {
                throw new ApiException("Job cannot found!");
            }

            JobTask.JobName = Job.Name;

            var User = await _UserRepository.GetByIdAsync(p.AssignedUserId);
            if (User == null)
            {
                throw new ApiException("User cannot found!");
            }
            JobTask.AssignedUserName = User.FullName;
        }

        return new ListedResponse<IEnumerable<JobTaskViewModel>>(JobTaskViewModels, dataCount);
    }

}
