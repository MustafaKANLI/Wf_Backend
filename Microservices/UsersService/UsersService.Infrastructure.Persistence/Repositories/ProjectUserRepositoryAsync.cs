namespace UsersService.Infrastructure.Persistence.Repositories;

using UsersService.Application.Interfaces.Repositories;
using UsersService.Domain.Entities;
using UsersService.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using static System.Reflection.Metadata.BlobBuilder;

public class ProjectUserRepositoryAsync : GenericRepositoryAsync<ProjectUser>, IProjectUserRepositoryAsync
{
    private readonly DbSet<ProjectUser> _ProjectUsers;

    public ProjectUserRepositoryAsync(UsersServiceDbContext dbContext) : base(dbContext)
    {
        _ProjectUsers = dbContext.ProjectUsers;
    }

    public async Task<IReadOnlyList<ProjectUser>> GetProjectsByUserIdAsync(int UserId)
    {
        return await _ProjectUsers
            .Where(x => x.UserId == UserId)
            .AsNoTracking()
            .ToListAsync();
    }
}
