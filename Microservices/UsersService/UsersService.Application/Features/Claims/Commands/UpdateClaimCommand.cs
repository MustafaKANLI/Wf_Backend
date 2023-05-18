using Common.Exceptions;
using Common.Wrappers;
using Mapster;
using MediatR;
using UsersService.Application.Interfaces.Repositories;
using UsersService.Domain.Entities;

namespace UsersService.Application.Features.Claims.Commands;

public class UpdateClaimCommand : IRequest<Response<string>>
{
    public int Id { get; set; }
    public string Name { get; set; }

}

public class UpdateClaimCommandHandler : IRequestHandler<UpdateClaimCommand, Response<string>>
{
    private readonly IClaimRepositoryAsync _ClaimRepository;
    public UpdateClaimCommandHandler(IClaimRepositoryAsync ClaimRepository)
    {
        _ClaimRepository = ClaimRepository;
    }

    public async Task<Response<string>> Handle(UpdateClaimCommand request, CancellationToken cancellationToken)
    {
        var Claim = await _ClaimRepository.GetByIdAsync(request.Id);
        if (Claim == null)
        {
            throw new ApiException("Claim not found");
        }

        Claim = request.Adapt<Claim>();

        await _ClaimRepository.UpdateAsync(Claim);

        return new Response<string>(Claim.Id.ToString(), "Claim Updated");
    }
}