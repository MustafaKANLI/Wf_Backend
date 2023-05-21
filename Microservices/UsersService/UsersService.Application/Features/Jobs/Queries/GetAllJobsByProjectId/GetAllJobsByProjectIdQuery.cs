namespace UsersService.Application.Features.JobsByProjectId.Queries.GetAllJobsByProjectId;

using UsersService.Application.Interfaces.Repositories;
using UsersService.Application.Features.SharedViewModels;
using Common.Wrappers;
using Common.Parameters;
using MediatR;
using Mapster;
using Common.Exceptions;


public class GetAllJobsByProjectIdQuery : IRequest<ListedResponse<IEnumerable<JobViewModel>>>
{
    public int ProjectId { get; set; }
}

public class GetAllJobsByProjectIdQueryHandler : IRequestHandler<GetAllJobsByProjectIdQuery, ListedResponse<IEnumerable<JobViewModel>>>
{
    private readonly IJobRepositoryAsync _JobRepository;
    private readonly IUserRepositoryAsync _UserRepository;
    private readonly IProjectRepositoryAsync _ProjectRepository;
    private readonly IJobPriorityRepositoryAsync _JobPriorityRepository;
    private readonly IJobStatusRepositoryAsync _JobStatusRepository;
    private readonly IJobTypeRepositoryAsync _JobTypeRepository;

    public GetAllJobsByProjectIdQueryHandler
    (
        IJobRepositoryAsync JobRepositoryAsync,
        IUserRepositoryAsync UserRepositoryAsync,
        IProjectRepositoryAsync projectRepository,
        IJobPriorityRepositoryAsync jobPriorityRepository,
        IJobStatusRepositoryAsync jobStatusRepository,
        IJobTypeRepositoryAsync jobTypeRepository

    )
    {
        _JobRepository = JobRepositoryAsync;
        _UserRepository = UserRepositoryAsync;
        _ProjectRepository = projectRepository;
        _JobPriorityRepository = jobPriorityRepository;
        _JobStatusRepository = jobStatusRepository;
        _JobTypeRepository = jobTypeRepository;
    }

    public async Task<ListedResponse<IEnumerable<JobViewModel>>> Handle(GetAllJobsByProjectIdQuery request, CancellationToken cancellationToken)
    {
        var Jobs = await _JobRepository.GetJobsByProjectIdAsync(request.ProjectId);
        var dataCount = Jobs.Count;

        var JobViewModels = new List<JobViewModel>();

        foreach (var p in Jobs)
        {
            var Job = p.Adapt<JobViewModel>();

            var Project = await _ProjectRepository.GetByIdAsync(p.ProjectId);
            if (Project == null)
            {
                throw new ApiException("Project cannot found!");
            }
            Job.ProjectName = Project.Name;

            var JobStatus = await _JobStatusRepository.GetByIdAsync(p.JobStatusId);
            if (JobStatus == null)
            {
                throw new ApiException("JobStatus cannot found!");
            }
            Job.JobStatusName = JobStatus.Name;

            var JobType = await _JobTypeRepository.GetByIdAsync(p.JobTypeId);
            if (JobType == null)
            {
                throw new ApiException("JobType cannot found!");
            }
            Job.JobTypeName = JobType.Name;

            var JobPriority = await _JobPriorityRepository.GetByIdAsync(p.JobPriorityId);
            if (JobPriority == null)
            {
                throw new ApiException("JobPriority cannot found!");
            }
            Job.JobPriorityName = JobPriority.Name;

            var CreateUser = await _UserRepository.GetByIdAsync(p.CreateUserId);
            if (CreateUser == null)
            {
                throw new ApiException("CreateUser cannot found!");
            }
            Job.CreateUserName = CreateUser.FullName;

            var ManagerUser = await _UserRepository.GetByIdAsync(p.ManagerUserId);
            if (ManagerUser == null)
            {
                throw new ApiException("ManagerUser cannot found!");
            }
            Job.ManagerUserName = ManagerUser.FullName;

            var DayApproverUser = await _UserRepository.GetByIdAsync(p.DayApproverUserId);
            if (DayApproverUser == null)
            {
                throw new ApiException("DayApproverUser cannot found!");
            }
            Job.DayApproverUserName = DayApproverUser.FullName;

            var AnalysisApproverUser = await _UserRepository.GetByIdAsync(p.ProjectId);
            if (AnalysisApproverUser == null)
            {
                throw new ApiException("AnalysisApproverUser cannot found!");
            }
            Job.AnalysisApproverUserName = AnalysisApproverUser.FullName;

            var Project = await _UserRepository.GetByIdAsync(p.ProjectId);
            if (Project == null)
            {
                throw new ApiException("Project cannot found!");
            }
            Job.ProjectName = Project.FullName;

            JobViewModels.Add(Job);
        }

        return new ListedResponse<IEnumerable<JobViewModel>>(JobViewModels, dataCount);
    }

}
