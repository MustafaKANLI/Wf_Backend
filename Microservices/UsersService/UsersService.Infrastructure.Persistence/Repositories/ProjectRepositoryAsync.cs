namespace UsersService.Infrastructure.Persistence.Repositories;

using UsersService.Application.Interfaces.Repositories;
using UsersService.Domain.Entities;
using UsersService.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

public class ProjectRepositoryAsync : GenericRepositoryAsync<Project>, IProjectRepositoryAsync
{
    private readonly DbSet<ProjectUser> _ProjectUsers;

    public ProjectRepositoryAsync(UsersServiceDbContext dbContext) : base(dbContext)
    {
        _ProjectUsers = dbContext.ProjectUsers;
    }

    public async Task<IReadOnlyList<Project>> GetProjectsByUserIdAsync(int UserId)
    {
        var projects = await _ProjectUsers
           .Include(pu => pu.Project)
           .Where(pu => pu.UserId == UserId)
           .Select(pu => pu.Project)
           .ToListAsync();

        return projects;
    }
}
