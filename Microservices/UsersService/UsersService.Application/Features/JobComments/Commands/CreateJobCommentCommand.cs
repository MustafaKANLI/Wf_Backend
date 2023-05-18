using Common.Wrappers;
using Mapster;
using MediatR;
using UsersService.Application.Interfaces.Repositories;
using UsersService.Domain.Entities;
using Common.Exceptions;

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
    private readonly IJobRepositoryAsync _JobRepository;
    private readonly IUserRepositoryAsync _UserRepository;
    public CreateJobCommentsCommandHandler(IJobCommentRepositoryAsync JobCommentsRepository, IJobRepositoryAsync jobRepository, IUserRepositoryAsync userRepository)
    {
        _JobCommentsRepository = JobCommentsRepository;
        _JobRepository = jobRepository;
        _UserRepository = userRepository;
    }

    public async Task<Response<string>> Handle(CreateJobCommentCommand request, CancellationToken cancellationToken)
    {
        var JobComments = request.Adapt<JobComment>();

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

        await _JobCommentsRepository.AddAsync(JobComments);

        return new Response<string>(JobComments.Id.ToString(), "JobComments created");
    }
}