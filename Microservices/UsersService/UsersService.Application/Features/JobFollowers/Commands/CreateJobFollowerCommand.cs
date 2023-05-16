using Common.Wrappers;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Http;
using UsersService.Application.Interfaces.Repositories;
using UsersService.Domain.Entities;

namespace UsersService.Application.Features.JobFollowers.Commands;

public class CreateJobFollowerCommand : IRequest<Response<string>>
{
    public int JobId { get; set; }
    public int UserId { get; set; }
  
}

public class CreateJobFollowerCommandHandler : IRequestHandler<CreateJobFollowerCommand, Response<string>>
{
  private readonly IJobFollowerRepositoryAsync _JobFollowerRepository;
  public CreateJobFollowerCommandHandler(IJobFollowerRepositoryAsync JobFollowerRepository)
  {
        _JobFollowerRepository = JobFollowerRepository;
  }

  public async Task<Response<string>> Handle(CreateJobFollowerCommand request, CancellationToken cancellationToken)
  {
    var JobFollower = request.Adapt<JobFollower>();

    await _JobFollowerRepository.AddAsync(JobFollower);

    return new Response<string>(JobFollower.Id.ToString(), "JobFollower created");
  }
}