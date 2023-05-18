using Common.Exceptions;
using Common.Wrappers;
using Mapster;
using MediatR;
using UsersService.Application.Interfaces.Repositories;
using UsersService.Domain.Entities;

namespace UsersService.Application.Features.JobComments.Commands;

public class DeleteJobCommentCommand : IRequest<Response<string>>
{
    public int Id { get; set; }

}

public class DeleteJobCommentCommandHandler : IRequestHandler<DeleteJobCommentCommand, Response<string>>
{
    private readonly IJobCommentRepositoryAsync _JobCommentRepository;
    public DeleteJobCommentCommandHandler(IJobCommentRepositoryAsync JobCommentRepository)
    {
        _JobCommentRepository = JobCommentRepository;
    }

    public async Task<Response<string>> Handle(DeleteJobCommentCommand request, CancellationToken cancellationToken)
    {
        await _JobCommentRepository.DeleteAsync(request.Id);
        return new Response<string>(request.Id + " JobComment deleted");
    }
}