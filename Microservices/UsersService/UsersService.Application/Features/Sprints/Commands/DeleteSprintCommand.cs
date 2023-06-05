using Common.Exceptions;
using Common.Wrappers;
using Mapster;
using MediatR;
using UsersService.Application.Interfaces.Repositories;
using UsersService.Domain.Entities;

namespace UsersService.Application.Features.Sprints.Commands;

public class DeleteSprintCommand : IRequest<Response<string>>
{
    public int Id { get; set; }

}

public class DeleteSprintCommandHandler : IRequestHandler<DeleteSprintCommand, Response<string>>
{
    private readonly ISprintRepositoryAsync _SprintRepository;
    public DeleteSprintCommandHandler(ISprintRepositoryAsync SprintRepository)
    {
        _SprintRepository = SprintRepository;
    }

    public async Task<Response<string>> Handle(DeleteSprintCommand request, CancellationToken cancellationToken)
    {
        await _SprintRepository.DeleteAsync(request.Id);
        return new Response<string>(request.Id + " Sprint deleted");
    }
}