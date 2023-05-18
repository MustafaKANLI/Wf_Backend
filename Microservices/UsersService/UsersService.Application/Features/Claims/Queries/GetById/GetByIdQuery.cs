namespace UsersService.Application.Features.Claims.Queries.GetById;

using UsersService.Application.Interfaces.Repositories;
using UsersService.Application.Features.SharedViewModels;
using Common.Wrappers;
using Common.Parameters;
using MediatR;
using Mapster;
using Common.Exceptions;

public class GetByIdQuery : IRequest<Response<ClaimViewModel>>
{
    public int Id { get; set; }

}

public class GetByIdQueryHandler : IRequestHandler<GetByIdQuery, Response<ClaimViewModel>>
{
    private readonly IClaimRepositoryAsync _ClaimRepository;
    public GetByIdQueryHandler(IClaimRepositoryAsync ClaimRepository)
    {
        _ClaimRepository = ClaimRepository;
    }

    public async Task<Response<ClaimViewModel>> Handle(GetByIdQuery request, CancellationToken cancellationToken)
    {

        var Claim = await _ClaimRepository.GetByIdAsync(request.Id);


        if (Claim == null)
        {
            throw new ApiException("Claim Not Found!");
        }


        return new Response<ClaimViewModel>(Claim.Adapt<ClaimViewModel>());
    }
}
