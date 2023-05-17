namespace UsersService.Infrastructure.Persistence.Repositories;

using UsersService.Application.Interfaces.Repositories;
using UsersService.Domain.Entities;
using UsersService.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

public class JobTypeRepositoryAsync: GenericRepositoryAsync<JobType>, IJobTypeRepositoryAsync
{
  private readonly DbSet<JobType> _JobTypes;

  public JobTypeRepositoryAsync(UsersServiceDbContext dbContext) : base(dbContext)
  {
     _JobTypes = dbContext.JobTypes;
  }
}
