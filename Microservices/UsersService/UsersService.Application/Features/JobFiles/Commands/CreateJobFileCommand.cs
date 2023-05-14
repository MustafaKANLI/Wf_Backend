using Common.Wrappers;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Http;
using UsersService.Application.Interfaces.Repositories;
using UsersService.Domain.Entities;

namespace UsersService.Application.Features.JobFiles.Commands;

public class CreateJobFileCommand : IRequest<Response<string>>
{
    public int JobId { get; set; }
    public int UserId { get; set; }
    public List<IFormFile> file { get; set; }
   

}

public class CreateJobFileCommandHandler : IRequestHandler<CreateJobFileCommand, Response<string>>
{
  private readonly IJobFileRepositoryAsync _JobFileRepository;
  public CreateJobFileCommandHandler(IJobFileRepositoryAsync JobFileRepository)
  {
        _JobFileRepository = JobFileRepository;
  }

  public async Task<Response<string>> Handle(CreateJobFileCommand request, CancellationToken cancellationToken)
  {
    var JobFile = request.Adapt<JobFile>();

    await _JobFileRepository.AddAsync(JobFile);

    return new Response<string>(JobFile.Id.ToString(), "JobFile created");
  }
}