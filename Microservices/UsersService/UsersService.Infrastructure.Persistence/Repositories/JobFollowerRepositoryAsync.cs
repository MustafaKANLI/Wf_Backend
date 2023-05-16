namespace UsersService.Infrastructure.Persistence.Repositories;

using UsersService.Application.Interfaces.Repositories;
using UsersService.Domain.Entities;
using UsersService.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

public class JobFollowerRepositoryAsync: GenericRepositoryAsync<JobFollower>, IJobFollowerRepositoryAsync
{
  private readonly DbSet<JobFollower> _JobFollowers;

  public JobFollowerRepositoryAsync(UsersServiceDbContext dbContext) : base(dbContext)
  {
     _JobFollowers = dbContext.JobFollowers;
  }
}
