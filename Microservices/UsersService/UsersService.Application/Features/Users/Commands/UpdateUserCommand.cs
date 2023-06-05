using Common.Exceptions;
using Common.Wrappers;
using Mapster;
using MediatR;
using UsersService.Application.Interfaces.Repositories;
using UsersService.Domain.Entities;

namespace UsersService.Application.Features.Users.Commands;

public class UpdateUserCommand : IRequest<Response<string>>
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public int ClaimId { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string FullName { get; set; }
    public string? Phone { get; set; }
    public byte[]? PWSalt { get; set; }
    public byte[]? PWHash { get; set; }
    public bool IsActive { get; set; }
    public bool IsLocked { get; set; }
}

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Response<string>>
{
    private readonly IUserRepositoryAsync _UserRepository;

    public UpdateUserCommandHandler(IUserRepositoryAsync UserRepository)
    {
        _UserRepository = UserRepository;
    }

    public async Task<Response<string>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var User = await _UserRepository.GetByIdAsync(request.Id);
        if (User == null)
        {
            throw new ApiException("User not found");
        }

        User = request.Adapt<User>();

        await _UserRepository.UpdateAsync(User);

        return new Response<string>(User.Id.ToString(), "User Updated");
    }
}