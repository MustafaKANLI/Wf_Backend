using Common.Exceptions;
using Common.Wrappers;
using Mapster;
using MediatR;
using System.ComponentModel.DataAnnotations.Schema;
using UsersService.Application.Interfaces.Repositories;
using UsersService.Domain.Entities;

namespace UsersService.Application.Features.Projects.Commands;

public class UpdateProjectCommand : IRequest<Response<string>>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int CustomerId { get; set; }
    public string Code { get; set; }
    public int ManagerUserId { get; set; }
    public int AnalysisApproverUserId { get; set; }
    public int DayApproverUserId { get; set; }
    public bool? IsActive { get; set; }
}

public class UpdateProjectCommandHandler : IRequestHandler<UpdateProjectCommand, Response<string>>
{
    private readonly IProjectRepositoryAsync _ProjectRepository;

    public UpdateProjectCommandHandler(IProjectRepositoryAsync ProjectRepository)
    {
        _ProjectRepository = ProjectRepository;
    }

    public async Task<Response<string>> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
    {
        var Project = await _ProjectRepository.GetByIdAsync(request.Id);
        if (Project == null)
        {
            throw new ApiException("Project not found");
        }

        Project = request.Adapt<Project>();

        await _ProjectRepository.UpdateAsync(Project);

        return new Response<string>(Project.Id.ToString(), "Project Updated");
    }
}