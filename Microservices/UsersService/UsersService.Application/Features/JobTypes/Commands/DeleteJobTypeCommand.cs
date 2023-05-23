using Common.Exceptions;
using Common.Wrappers;
using Mapster;
using MediatR;
using UsersService.Application.Interfaces.Repositories;
using UsersService.Domain.Entities;

namespace UsersService.Application.Features.JobTypes.Commands;

public class DeleteJobTypeCommand : IRequest<Response<string>>
{
    public int Id { get; set; }

}

public class DeleteJobTypeCommandHandler : IRequestHandler<DeleteJobTypeCommand, Response<string>>
{
    private readonly IJobTypeRepositoryAsync _JobTypeRepository;
    public DeleteJobTypeCommandHandler(IJobTypeRepositoryAsync JobTypeRepository)
    {
        _JobTypeRepository = JobTypeRepository;
    }

    public async Task<Response<string>> Handle(DeleteJobTypeCommand request, CancellationToken cancellationToken)
    {
        await _JobTypeRepository.DeleteAsync(request.Id);
        return new Response<string>(request.Id + " JobType deleted");
    }
}