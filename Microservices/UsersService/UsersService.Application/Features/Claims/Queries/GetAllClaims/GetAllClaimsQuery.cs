namespace UsersService.Application.Features.Claims.Queries.GetAllClaims;

using UsersService.Application.Interfaces.Repositories;
using UsersService.Application.Features.SharedViewModels;
using Common.Wrappers;
using Common.Parameters;
using MediatR;
using Mapster;
using Common.Exceptions;

public class GetAllClaimsQuery : IRequest<PagedResponse<IEnumerable<ClaimViewModel>>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}

public class GetAllClaimsQueryHandler : IRequestHandler<GetAllClaimsQuery, PagedResponse<IEnumerable<ClaimViewModel>>>
{
    private readonly IClaimRepositoryAsync _ClaimsRepository;
    public GetAllClaimsQueryHandler(IClaimRepositoryAsync ClaimsRepository)
    {
        _ClaimsRepository = ClaimsRepository;
    }

    public async Task<PagedResponse<IEnumerable<ClaimViewModel>>> Handle(GetAllClaimsQuery request, CancellationToken cancellationToken)
    {
        var dataCount = await _ClaimsRepository.GetDataCount();
        var Claims = await _ClaimsRepository.GetPagedReponseAsync(request.PageNumber, request.PageSize);

        var ClaimsViewModels = new List<ClaimViewModel>();

        foreach (var p in Claims)
        {
            var Claim = p.Adapt<ClaimViewModel>();
            ClaimsViewModels.Add(Claim);
        }

        return new PagedResponse<IEnumerable<ClaimViewModel>>(ClaimsViewModels, request.PageNumber, request.PageSize, dataCount);
    }
}
