namespace UsersService.Infrastructure.Persistence.Repositories;

using UsersService.Application.Interfaces.Repositories;
using UsersService.Domain.Entities;
using UsersService.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

public class ClaimsRepositoryAsync: GenericRepositoryAsync<Claim>, IClaimRepositoryAsync
{
  private readonly DbSet<Claim> _Claims;

  public ClaimsRepositoryAsync(UsersServiceDbContext dbContext) : base(dbContext)
  {
     _Claims = dbContext.Claims;
  }
}
