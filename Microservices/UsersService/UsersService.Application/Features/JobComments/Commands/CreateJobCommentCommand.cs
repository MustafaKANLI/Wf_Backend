using Common.Wrappers;
using Mapster;
using MediatR;
using UsersService.Application.Interfaces.Repositories;
using UsersService.Domain.Entities;

namespace UsersService.Application.Features.JobComments.Commands;

public class CreateJobCommentCommand : IRequest<Response<string>>
{

    public int JobId { get; set; }
    public int UserId { get; set; }
    public DateTime Date { get; set; }
    public string? Comment { get; set; }

}

public class CreateJobCommentsCommandHandler : IRequestHandler<CreateJobCommentCommand, Response<string>>
{
  private readonly IJobCommentRepositoryAsync _JobCommentsRepository;
  public CreateJobCommentsCommandHandler(IJobCommentRepositoryAsync JobCommentsRepository)
  {
        _JobCommentsRepository = JobCommentsRepository;
  }

  public async Task<Response<string>> Handle(CreateJobCommentCommand request, CancellationToken cancellationToken)
  {
    var JobComments = request.Adapt<JobComment>();

    await _JobCommentsRepository.AddAsync(JobComments);

    return new Response<string>(JobComments.Id.ToString(), "JobComments created");
  }
}