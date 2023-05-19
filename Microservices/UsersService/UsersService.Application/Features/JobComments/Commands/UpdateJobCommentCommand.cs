using Common.Exceptions;
using Common.Wrappers;
using Mapster;
using MediatR;
using UsersService.Application.Interfaces.Repositories;
using UsersService.Domain.Entities;

namespace UsersService.Application.Features.JobComments.Commands;

public class UpdateJobCommentCommand : IRequest<Response<string>>
{
    public int Id { get; set; }
    public int JobId { get; set; }
    public int UserId { get; set; }
    public DateTime Date { get; set; }
    public string? Comment { get; set; }

}

public class UpdateJobCommentCommandHandler : IRequestHandler<UpdateJobCommentCommand, Response<string>>
{
    private readonly IJobCommentRepositoryAsync _JobCommentRepository;
    private readonly IJobRepositoryAsync _JobRepository;
    private readonly IUserRepositoryAsync _UserRepository;
    public UpdateJobCommentCommandHandler(IJobCommentRepositoryAsync JobCommentRepository, IJobRepositoryAsync jobRepository, IUserRepositoryAsync userRepository)
    {
        _JobCommentRepository = JobCommentRepository;
        _JobRepository = jobRepository;
        _UserRepository = userRepository;
    }

    public async Task<Response<string>> Handle(UpdateJobCommentCommand request, CancellationToken cancellationToken)
    {
        var JobComment = await _JobCommentRepository.GetByIdAsync(request.Id);
        if (JobComment == null)
        {
            throw new ApiException("JobComment not found");
        }

        var Job = await _JobRepository.GetByIdAsync(request.JobId);
        if (Job == null)
        {
            throw new ApiException("Job cannot found!");
        }

        var User = await _UserRepository.GetByIdAsync(request.UserId);
        if (User == null)
        {
            throw new ApiException("User cannot found!");
        }

        JobComment = request.Adapt<JobComment>();

        await _JobCommentRepository.UpdateAsync(JobComment);

        return new Response<string>(JobComment.Id.ToString(), "JobComment Updated");
    }
}