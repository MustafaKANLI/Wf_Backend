namespace UsersService.Infrastructure.Persistence.Repositories;

using UsersService.Application.Interfaces.Repositories;
using UsersService.Domain.Entities;
using UsersService.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

public class JobTaskRepositoryAsync : GenericRepositoryAsync<JobTask>, IJobTaskRepositoryAsync
{
    private readonly DbSet<JobTask> _JobTasks;

    public JobTaskRepositoryAsync(UsersServiceDbContext dbContext) : base(dbContext)
    {
        _JobTasks = dbContext.JobTasks;
    }
    public async Task<IReadOnlyList<JobTask>> GetJobTasksByJobIdAsync(int JobId)
    {
        return await _JobTasks
            .Where(j => j.JobId == JobId)
            .AsNoTracking()
            .ToListAsync();
    }
}
