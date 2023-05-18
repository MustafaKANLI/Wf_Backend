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
    public UpdateJobCommentCommandHandler(IJobCommentRepositoryAsync JobCommentRepository)
    {
        _JobCommentRepository = JobCommentRepository;
    }

    public async Task<Response<string>> Handle(UpdateJobCommentCommand request, CancellationToken cancellationToken)
    {
        var JobComment = await _JobCommentRepository.GetByIdAsync(request.Id);
        if (JobComment == null)
        {
            throw new ApiException("JobComment not found");
        }

        JobComment = request.Adapt<JobComment>();

        await _JobCommentRepository.UpdateAsync(JobComment);

        return new Response<string>(JobComment.Id.ToString(), "JobComment Updated");
    }
}