using Common.Exceptions;
using Common.Wrappers;
using Mapster;
using MediatR;
using UsersService.Application.Interfaces.Repositories;
using UsersService.Domain.Entities;

namespace UsersService.Application.Features.Claims.Commands;

public class DeleteClaimCommand : IRequest<Response<string>>
{
    public int Id { get; set; }

}

public class DeleteClaimCommandHandler : IRequestHandler<DeleteClaimCommand, Response<string>>
{
    private readonly IClaimRepositoryAsync _ClaimRepository;
    public DeleteClaimCommandHandler(IClaimRepositoryAsync ClaimRepository)
    {
        _ClaimRepository = ClaimRepository;
    }

    public async Task<Response<string>> Handle(DeleteClaimCommand request, CancellationToken cancellationToken)
    {
        await _ClaimRepository.DeleteAsync(request.Id);
        return new Response<string>(request.Id + " Claim deleted");
    }
}