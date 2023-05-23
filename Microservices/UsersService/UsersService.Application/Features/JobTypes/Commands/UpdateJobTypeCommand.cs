using Common.Exceptions;
using Common.Wrappers;
using Mapster;
using MediatR;
using UsersService.Application.Interfaces.Repositories;
using UsersService.Domain.Entities;

namespace UsersService.Application.Features.JobTypes.Commands;

public class UpdateJobTypeCommand : IRequest<Response<string>>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Details { get; set; }

}

public class UpdateJobTypeCommandHandler : IRequestHandler<UpdateJobTypeCommand, Response<string>>
{
    private readonly IJobTypeRepositoryAsync _JobTypeRepository;

    public UpdateJobTypeCommandHandler(IJobTypeRepositoryAsync JobTypeRepository)
    {
        _JobTypeRepository = JobTypeRepository;
    }

    public async Task<Response<string>> Handle(UpdateJobTypeCommand request, CancellationToken cancellationToken)
    {
        var JobType = await _JobTypeRepository.GetByIdAsync(request.Id);
        if (JobType == null)
        {
            throw new ApiException("JobType not found");
        }

        JobType = request.Adapt<JobType>();

        await _JobTypeRepository.UpdateAsync(JobType);

        return new Response<string>(JobType.Id.ToString(), "JobType Updated");
    }
}