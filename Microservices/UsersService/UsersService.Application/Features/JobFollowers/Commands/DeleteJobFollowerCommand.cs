using Common.Exceptions;
using Common.Wrappers;
using Mapster;
using MediatR;
using UsersService.Application.Interfaces.Repositories;
using UsersService.Domain.Entities;

namespace UsersService.Application.Features.JobFollowers.Commands;

public class DeleteJobFollowerCommand : IRequest<Response<string>>
{
    public int Id { get; set; }

}

public class DeleteJobFollowerCommandHandler : IRequestHandler<DeleteJobFollowerCommand, Response<string>>
{
    private readonly IJobFollowerRepositoryAsync _JobFollowerRepository;
    public DeleteJobFollowerCommandHandler(IJobFollowerRepositoryAsync JobFollowerRepository)
    {
        _JobFollowerRepository = JobFollowerRepository;
    }

    public async Task<Response<string>> Handle(DeleteJobFollowerCommand request, CancellationToken cancellationToken)
    {
        await _JobFollowerRepository.DeleteAsync(request.Id);
        return new Response<string>(request.Id + " JobFollower deleted");
    }
}