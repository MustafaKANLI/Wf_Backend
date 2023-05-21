namespace UsersService.Infrastructure.Persistence.Repositories;

using UsersService.Application.Interfaces.Repositories;
using UsersService.Domain.Entities;
using UsersService.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;

public class JobRepositoryAsync: GenericRepositoryAsync<Job>, IJobRepositoryAsync
{
  private readonly DbSet<Job> _Jobs;

  public JobRepositoryAsync(UsersServiceDbContext dbContext) : base(dbContext)
  {
     _Jobs = dbContext.Jobs;
  }

    public async Task<IReadOnlyList<Job>> GetJobsByAssignedUserIdAsync(int AssignedUserId)
    {
        return await _Jobs
            .Where(x => x.AssignedUserId == AssignedUserId)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<IReadOnlyList<Job>> GetJobsByProjectIdAsync(int ProjectId)
    {
        return await _Jobs
            .Where(x => x.ProjectId == ProjectId)
            .AsNoTracking()
            .ToListAsync();
    }
}
