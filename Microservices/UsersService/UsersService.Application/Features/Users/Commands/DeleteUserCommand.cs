using Common.Exceptions;
using Common.Wrappers;
using Mapster;
using MediatR;
using UsersService.Application.Interfaces.Repositories;
using UsersService.Domain.Entities;

namespace UsersService.Application.Features.Users.Commands;

public class DeleteUserCommand : IRequest<Response<string>>
{
    public int Id { get; set; }

}

public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, Response<string>>
{
    private readonly IUserRepositoryAsync _UserRepository;
    public DeleteUserCommandHandler(IUserRepositoryAsync UserRepository)
    {
        _UserRepository = UserRepository;
    }

    public async Task<Response<string>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        await _UserRepository.DeleteAsync(request.Id);
        return new Response<string>(request.Id + " User deleted");
    }
}