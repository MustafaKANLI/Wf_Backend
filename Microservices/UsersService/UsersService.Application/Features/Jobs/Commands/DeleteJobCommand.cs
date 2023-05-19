using Common.Exceptions;
using Common.Wrappers;
using Mapster;
using MediatR;
using UsersService.Application.Interfaces.Repositories;
using UsersService.Domain.Entities;

namespace UsersService.Application.Features.Jobs.Commands;

public class DeleteJobCommand : IRequest<Response<string>>
{
    public int Id { get; set; }

}

public class DeleteJobCommandHandler : IRequestHandler<DeleteJobCommand, Response<string>>
{
    private readonly IJobRepositoryAsync _JobRepository;
    public DeleteJobCommandHandler(IJobRepositoryAsync JobRepository)
    {
        _JobRepository = JobRepository;
    }

    public async Task<Response<string>> Handle(DeleteJobCommand request, CancellationToken cancellationToken)
    {
        await _JobRepository.DeleteAsync(request.Id);
        return new Response<string>(request.Id + " Job deleted");
    }
}