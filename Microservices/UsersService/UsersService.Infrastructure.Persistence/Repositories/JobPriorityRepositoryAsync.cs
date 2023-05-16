namespace UsersService.Infrastructure.Persistence.Repositories;

using UsersService.Application.Interfaces.Repositories;
using UsersService.Domain.Entities;
using UsersService.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

public class JobPriorityRepositoryAsync: GenericRepositoryAsync<JobPriority>, IJobPriorityRepositoryAsync
{
  private readonly DbSet<JobPriority> _JobPriorities;

  public JobPriorityRepositoryAsync(UsersServiceDbContext dbContext) : base(dbContext)
  {
     _JobPriorities = dbContext.JobPriorities;
  }
}
