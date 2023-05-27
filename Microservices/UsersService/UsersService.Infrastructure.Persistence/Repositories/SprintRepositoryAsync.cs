namespace UsersService.Infrastructure.Persistence.Repositories;

using UsersService.Application.Interfaces.Repositories;
using UsersService.Domain.Entities;
using UsersService.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

public class SprintRepositoryAsync : GenericRepositoryAsync<Sprint>, ISprintRepositoryAsync
{
    private readonly DbSet<Sprint> _Sprints;

    public SprintRepositoryAsync(UsersServiceDbContext dbContext) : base(dbContext)
    {
        _Sprints = dbContext.Sprints;
    }

    public async Task<IReadOnlyList<Sprint>> GetSprintsByCustomerIdAsync(int CustomerId)
    {
        return await _Sprints
            .Where(j => j.CustomerId == CustomerId)
            .AsNoTracking()
            .ToListAsync();
    }

}
