using Common.Wrappers;
using Mapster;
using MediatR;
using UsersService.Application.Interfaces.Repositories;
using UsersService.Domain.Entities;

namespace UsersService.Application.Features.Claims.Commands;

public class CreateClaimCommand : IRequest<Response<string>>
{

    public string Name { get; set; }

}

public class CreateClaimsCommandHandler : IRequestHandler<CreateClaimCommand, Response<string>>
{
    private readonly IClaimRepositoryAsync _ClaimsRepository;
    public CreateClaimsCommandHandler(IClaimRepositoryAsync ClaimsRepository)
    {
        _ClaimsRepository = ClaimsRepository;
    }

    public async Task<Response<string>> Handle(CreateClaimCommand request, CancellationToken cancellationToken)
    {
        var Claims = request.Adapt<Claim>();

        await _ClaimsRepository.AddAsync(Claims);

        return new Response<string>(Claims.Id.ToString(), "Claims created");
    }
}