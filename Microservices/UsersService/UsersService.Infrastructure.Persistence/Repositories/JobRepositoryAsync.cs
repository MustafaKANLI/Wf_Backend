namespace UsersService.Infrastructure.Persistence.Repositories;

using UsersService.Application.Interfaces.Repositories;
using UsersService.Domain.Entities;
using UsersService.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

public class JobRepositoryAsync: GenericRepositoryAsync<Job>, IJobRepositoryAsync
{
  private readonly DbSet<Job> _Jobs;

  public JobRepositoryAsync(UsersServiceDbContext dbContext) : base(dbContext)
  {
     _Jobs = dbContext.Jobs;
  }
}
