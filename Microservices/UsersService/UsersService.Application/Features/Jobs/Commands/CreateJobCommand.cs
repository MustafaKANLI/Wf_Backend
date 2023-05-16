using Common.Wrappers;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Http;
using UsersService.Application.Interfaces.Repositories;
using UsersService.Domain.Entities;

namespace UsersService.Application.Features.Jobs.Commands;

public class CreateJobCommand : IRequest<Response<string>>
{
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

public class CreateJobCommandHandler : IRequestHandler<CreateJobCommand, Response<string>>
{
  private readonly IJobRepositoryAsync _JobRepository;
  public CreateJobCommandHandler(IJobRepositoryAsync JobRepository)
  {
        _JobRepository = JobRepository;
  }

  public async Task<Response<string>> Handle(CreateJobCommand request, CancellationToken cancellationToken)
  {
    var Job = request.Adapt<Job>();

    await _JobRepository.AddAsync(Job);

    return new Response<string>(Job.Id.ToString(), "Job created");
  }
}