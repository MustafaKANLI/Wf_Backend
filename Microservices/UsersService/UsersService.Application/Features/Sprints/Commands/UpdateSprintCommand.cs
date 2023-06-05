using Common.Exceptions;
using Common.Wrappers;
using Mapster;
using MediatR;
using UsersService.Application.Interfaces.Repositories;
using UsersService.Domain.Entities;

namespace UsersService.Application.Features.Sprints.Commands;

public class UpdateSprintCommand : IRequest<Response<string>>
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public string Name { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}

public class UpdateSprintCommandHandler : IRequestHandler<UpdateSprintCommand, Response<string>>
{
    private readonly ISprintRepositoryAsync _SprintRepository;

    public UpdateSprintCommandHandler(ISprintRepositoryAsync SprintRepository)
    {
        _SprintRepository = SprintRepository;
    }

    public async Task<Response<string>> Handle(UpdateSprintCommand request, CancellationToken cancellationToken)
    {
        var Sprint = await _SprintRepository.GetByIdAsync(request.Id);
        if (Sprint == null)
        {
            throw new ApiException("Sprint not found");
        }

        Sprint = request.Adapt<Sprint>();

        await _SprintRepository.UpdateAsync(Sprint);

        return new Response<string>(Sprint.Id.ToString(), "Sprint Updated");
    }
}