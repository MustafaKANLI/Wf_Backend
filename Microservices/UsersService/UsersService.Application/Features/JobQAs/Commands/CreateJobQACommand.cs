using Common.Wrappers;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Http;
using UsersService.Application.Interfaces.Repositories;
using UsersService.Domain.Entities;

namespace UsersService.Application.Features.JobQAs.Commands;

public class CreateJobQACommand : IRequest<Response<string>>
{
    public int JobId { get; set; }
    public int QuestionUserId { get; set; }
    public DateTime QuestionDate { get; set; }
    public string Question { get; set; }
    public int? AnswerUserId { get; set; }
    public DateTime? AnswerDate { get; set; }
    public string? Answer { get; set; }


}

public class CreateJobQACommandHandler : IRequestHandler<CreateJobQACommand, Response<string>>
{
  private readonly IJobQARepositoryAsync _JobQARepository;
  public CreateJobQACommandHandler(IJobQARepositoryAsync JobQARepository)
  {
        _JobQARepository = JobQARepository;
  }

  public async Task<Response<string>> Handle(CreateJobQACommand request, CancellationToken cancellationToken)
  {
    var JobQA = request.Adapt<JobQA>();

    await _JobQARepository.AddAsync(JobQA);

    return new Response<string>(JobQA.Id.ToString(), "JobQA created");
  }
}