namespace UsersService.Infrastructure.Persistence.Repositories;

using UsersService.Application.Interfaces.Repositories;
using UsersService.Domain.Entities;
using UsersService.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

public class ClaimRepositoryAsync: GenericRepositoryAsync<Claim>, IClaimRepositoryAsync
{
  private readonly DbSet<Claim> _Claims;

  public ClaimRepositoryAsync(UsersServiceDbContext dbContext) : base(dbContext)
  {
     _Claims = dbContext.Claims;
  }
}
