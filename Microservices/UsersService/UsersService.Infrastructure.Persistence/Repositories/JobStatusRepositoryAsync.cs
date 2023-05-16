namespace UsersService.Infrastructure.Persistence.Repositories;

using UsersService.Application.Interfaces.Repositories;
using UsersService.Domain.Entities;
using UsersService.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

public class JobStatusRepositoryAsync: GenericRepositoryAsync<JobStatus>, IJobStatusRepositoryAsync
{
  private readonly DbSet<JobStatus> _JobStatuses;

  public JobStatusRepositoryAsync(UsersServiceDbContext dbContext) : base(dbContext)
  {
     _JobStatuses = dbContext.JobStatuses;
  }
}
