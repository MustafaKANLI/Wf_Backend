namespace UsersService.Infrastructure.Persistence.Repositories;

using UsersService.Application.Interfaces.Repositories;
using UsersService.Domain.Entities;
using UsersService.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

public class JobFileRepositoryAsync: GenericRepositoryAsync<JobFile>, IJobFileRepositoryAsync
{
  private readonly DbSet<JobFile> _JobFiles;

  public JobFileRepositoryAsync(UsersServiceDbContext dbContext) : base(dbContext)
  {
     _JobFiles = dbContext.JobFiles;
  }

    public async Task<IReadOnlyList<JobFile>> GetJobFilesByJobIdAsync(int jobId)
    {
        return await _JobFiles
            .Where(j => j.JobId == jobId)
            .AsNoTracking()
            .ToListAsync();
    }
}
