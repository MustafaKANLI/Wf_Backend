namespace UsersService.Infrastructure.Persistence.Repositories;

using UsersService.Application.Interfaces.Repositories;
using UsersService.Domain.Entities;
using UsersService.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

public class JobFollowerRepositoryAsync: GenericRepositoryAsync<JobFollower>, IJobFollowerRepositoryAsync
{
  private readonly DbSet<JobFollower> _JobFollowers;

  public JobFollowerRepositoryAsync(UsersServiceDbContext dbContext) : base(dbContext)
  {
     _JobFollowers = dbContext.JobFollowers;
  }

    public async Task<IReadOnlyList<JobFollower>> GetJobFollowersByJobIdAsync(int JobId)
    {
        return await _JobFollowers
            .Where(j => j.JobId == JobId)
            .AsNoTracking()
            .ToListAsync();
    }
}
