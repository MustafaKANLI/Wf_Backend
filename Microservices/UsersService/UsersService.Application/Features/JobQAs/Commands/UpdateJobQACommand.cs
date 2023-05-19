using Common.Exceptions;
using Common.Wrappers;
using Mapster;
using MediatR;
using UsersService.Application.Interfaces.Repositories;
using UsersService.Domain.Entities;

namespace UsersService.Application.Features.JobQAs.Commands;

public class UpdateJobQACommand : IRequest<Response<string>>
{
    public int Id { get; set; }
    public int JobId { get; set; }
    public int QuestionUserId { get; set; }
    public DateTime QuestionDate { get; set; }
    public string Question { get; set; }
    public int? AnswerUserId { get; set; }
    public DateTime? AnswerDate { get; set; }
    public string? Answer { get; set; }

}

public class UpdateJobQACommandHandler : IRequestHandler<UpdateJobQACommand, Response<string>>
{
    private readonly IJobQARepositoryAsync _JobQARepository;
    private readonly IJobRepositoryAsync _JobRepository;
    private readonly IUserRepositoryAsync _UserRepository;

    public UpdateJobQACommandHandler(IJobQARepositoryAsync JobQARepository, IJobRepositoryAsync jobRepository, IUserRepositoryAsync userRepository)
    {
        _JobQARepository = JobQARepository;
        _JobRepository = jobRepository;
        _UserRepository = userRepository;
    }

    public async Task<Response<string>> Handle(UpdateJobQACommand request, CancellationToken cancellationToken)
    {
        var JobQA = await _JobQARepository.GetByIdAsync(request.Id);
        if (JobQA == null)
        {
            throw new ApiException("JobQA not found");
        }

        JobQA = request.Adapt<JobQA>();

        var Job = await _JobRepository.GetByIdAsync(request.JobId);
        if (Job == null)
        {
            throw new ApiException("Job cannot found!");
        }

        var User = await _UserRepository.GetByIdAsync(request.QuestionUserId);
        if (User == null)
        {
            throw new ApiException("User cannot found!");
        }

        await _JobQARepository.UpdateAsync(JobQA);

        return new Response<string>(JobQA.Id.ToString(), "JobQA Updated");
    }
}