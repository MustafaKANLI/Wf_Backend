using Common.Exceptions;
using Common.Wrappers;
using Mapster;
using MediatR;
using UsersService.Application.Interfaces.Repositories;
using UsersService.Domain.Entities;

namespace UsersService.Application.Features.JobStatuses.Commands;

public class DeleteJobStatusCommand : IRequest<Response<string>>
{
    public int Id { get; set; }

}

public class DeleteJobStatusCommandHandler : IRequestHandler<DeleteJobStatusCommand, Response<string>>
{
  private readonly IJobStatusRepositoryAsync _JobStatusRepository;
  public DeleteJobStatusCommandHandler(IJobStatusRepositoryAsync JobStatusRepository)
  {
        _JobStatusRepository = JobStatusRepository;
  }

  public async Task<Response<string>> Handle(DeleteJobStatusCommand request, CancellationToken cancellationToken)
  {
        await _JobStatusRepository.DeleteAsync(request.Id);
        return new Response<string>(request.Id + " JobStatus deleted");
  }
}