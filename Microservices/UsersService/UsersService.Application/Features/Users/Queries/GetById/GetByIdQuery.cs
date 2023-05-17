namespace UsersService.Application.Features.Users.Queries.GetById;

using UsersService.Application.Interfaces.Repositories;
using UsersService.Application.Features.SharedViewModels;
using Common.Wrappers;
using Common.Parameters;
using MediatR;
using Mapster;
using Common.Exceptions;

public class GetByIdQuery : IRequest<Response<UserViewModel>>
{
  public int Id { get; set; }
  
}

public class GetByIdQueryHandler : IRequestHandler<GetByIdQuery, Response<UserViewModel>>
{
  private readonly IUserRepositoryAsync _UserRepository;
  public GetByIdQueryHandler(IUserRepositoryAsync UserRepository)
  {
    _UserRepository = UserRepository;
  }

  public async Task<Response<UserViewModel>> Handle(GetByIdQuery request, CancellationToken cancellationToken)
  {

    var User = await _UserRepository.GetByIdAsync(request.Id);

    
        if(User == null)
        {
            throw new ApiException("User Not Found!");
        }
   

    return new Response<UserViewModel>(User.Adapt<UserViewModel>());
  }
}
