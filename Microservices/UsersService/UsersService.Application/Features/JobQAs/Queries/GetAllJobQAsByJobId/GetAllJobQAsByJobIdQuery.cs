namespace UsersService.Application.Features.JobQAsByJobId.Queries.GetAllJobQAsByJobId;

using UsersService.Application.Interfaces.Repositories;
using UsersService.Application.Features.SharedViewModels;
using Common.Wrappers;
using Common.Parameters;
using MediatR;
using Mapster;
using Common.Exceptions;

public class GetAllJobQAsByJobIdQuery : IRequest<ListedResponse<IEnumerable<JobQAViewModel>>>
{
    public int JobId { get; set; }
}

public class GetAllJobQAsByJobIdQueryHandler : IRequestHandler<GetAllJobQAsByJobIdQuery, ListedResponse<IEnumerable<JobQAViewModel>>>
{
    private readonly IJobQARepositoryAsync _JobQARepository;
    private readonly IJobRepositoryAsync _JobRepository;
    private readonly IUserRepositoryAsync _UserRepository;
    public GetAllJobQAsByJobIdQueryHandler(IJobQARepositoryAsync JobQARepository, IJobRepositoryAsync JobRepositoryAsync, IUserRepositoryAsync UserRepositoryAsync)
    {
        _JobQARepository = JobQARepository;
        _JobRepository = JobRepositoryAsync;
        _UserRepository = UserRepositoryAsync;
    }

    public async Task<ListedResponse<IEnumerable<JobQAViewModel>>> Handle(GetAllJobQAsByJobIdQuery request, CancellationToken cancellationToken)
    {
        var JobQAs = await _JobQARepository.GetJobQAsByJobIdAsync(request.JobId);
        var dataCount = JobQAs.Count;

        var JobQAViewModels = new List<JobQAViewModel>();

        foreach (var p in JobQAs)
        {
            var JobQA = p.Adapt<JobQAViewModel>();
            JobQAViewModels.Add(JobQA);

            var Job = await _JobRepository.GetByIdAsync(p.JobId);
            if (Job == null)
            {
                throw new ApiException("Job cannot found!");
            }

            JobQA.JobName = Job.Name;

            var QuestionUser = await _UserRepository.GetByIdAsync(p.QuestionUserId);
            JobQA.QuestionUserName = QuestionUser.FullName;

            var AnsweredUser = await _UserRepository.GetByIdAsync(p.AnswerUserId);
            if(AnsweredUser != null)
            {

                JobQA.AnswerUserName = AnsweredUser.FullName;
            }
        }

        return new ListedResponse<IEnumerable<JobQAViewModel>>(JobQAViewModels, dataCount);
    }

}
