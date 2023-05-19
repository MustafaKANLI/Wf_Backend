using Common.Exceptions;
using Common.Wrappers;
using Mapster;
using MediatR;
using UsersService.Application.Interfaces.Repositories;
using UsersService.Domain.Entities;

namespace UsersService.Application.Features.JobFollowers.Commands;

public class UpdateJobFollowerCommand : IRequest<Response<string>>
{
    public int Id { get; set; }
    public int JobId { get; set; }
    public int UserId { get; set; }

}

public class UpdateJobFollowerCommandHandler : IRequestHandler<UpdateJobFollowerCommand, Response<string>>
{
    private readonly IJobFollowerRepositoryAsync _JobFollowerRepository;
    public UpdateJobFollowerCommandHandler(IJobFollowerRepositoryAsync JobFollowerRepository)
    {
        _JobFollowerRepository = JobFollowerRepository;
    }

    public async Task<Response<string>> Handle(UpdateJobFollowerCommand request, CancellationToken cancellationToken)
    {
        var JobFollower = await _JobFollowerRepository.GetByIdAsync(request.Id);
        if (JobFollower == null)
        {
            throw new ApiException("JobFollower not found");
        }

        JobFollower = request.Adapt<JobFollower>();

        await _JobFollowerRepository.UpdateAsync(JobFollower);

        return new Response<string>(JobFollower.Id.ToString(), "JobFollower Updated");
    }
}