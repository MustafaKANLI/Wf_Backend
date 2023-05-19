using Common.Exceptions;
using Common.Wrappers;
using Mapster;
using MediatR;
using UsersService.Application.Interfaces.Repositories;
using UsersService.Domain.Entities;

namespace UsersService.Application.Features.Jobs.Commands;

public class UpdateJobCommand : IRequest<Response<string>>
{
    public int Id { get; set; }
    public int ProjectId { get; set; }
    public int JobStatusId { get; set; }
    public int? JobTypeId { get; set; }
    public int? JobPriorityId { get; set; }
    public DateTime CreateDate { get; set; }
    public int CreateUserId { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }
    public string? Topic { get; set; }
    public string Details { get; set; }
    public string? Analysis { get; set; }
    public int? AssignedUserId { get; set; }
    public int? Sprint { get; set; }
    public double? EstimatedDay { get; set; }
    public double? ActualDay { get; set; }
    public double? BilledDay { get; set; }
    public bool IsBilled { get; set; }
    public int? ManagerUserId { get; set; }
    public DateTime? ManagerApproveDate { get; set; }
    public int? DayApproverUserId { get; set; }
    public int? ParentJobId { get; set; }
    public DateTime? DayApproveDate { get; set; }
    public int? AnalysisApproverUserId { get; set; }
    public DateTime? AnalysisApproveDate { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public DateTime? TestDate { get; set; }
    public DateTime? ProdDate { get; set; }
    public bool IsActive { get; set; }
    public int? SprintOrder { get; set; }

}

public class UpdateJobCommandHandler : IRequestHandler<UpdateJobCommand, Response<string>>
{
    private readonly IJobRepositoryAsync _JobRepository;
    private readonly IUserRepositoryAsync _UserRepository;

    public UpdateJobCommandHandler(IJobRepositoryAsync jobRepository, IUserRepositoryAsync userRepository)
    {
        _JobRepository = jobRepository;
        _UserRepository = userRepository;
    }

    public async Task<Response<string>> Handle(UpdateJobCommand request, CancellationToken cancellationToken)
    {

        var Job = await _JobRepository.GetByIdAsync(request.Id);
        if (Job == null)
        {
            throw new ApiException("Job cannot found!");
        }

        Job = request.Adapt<Job>();

        // TODO: İlgili id'lere sahip kullanıcı, proje, durum, tür vb şeylerin olup olmadığının kontrolü sağlanacak

        await _JobRepository.UpdateAsync(Job);

        return new Response<string>(Job.Id.ToString(), "Job Updated");
    }
}