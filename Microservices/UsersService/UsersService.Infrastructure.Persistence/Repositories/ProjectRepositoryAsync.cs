namespace UsersService.Infrastructure.Persistence.Repositories;

using UsersService.Application.Interfaces.Repositories;
using UsersService.Domain.Entities;
using UsersService.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

public class ProjectRepositoryAsync : GenericRepositoryAsync<Project>, IProjectRepositoryAsync
{
    private readonly DbSet<Project> _Projects;
    private readonly DbSet<ProjectUser> _ProjectUsers;

    public ProjectRepositoryAsync(UsersServiceDbContext dbContext) : base(dbContext)
    {
        _Projects = dbContext.Projects;
        _ProjectUsers = dbContext.ProjectUsers;
    }

    public async Task<IReadOnlyList<Project>> GetProjectsByUserIdAsync(int UserId)
    {
        var projectIds = await _ProjectUsers
            .Where(x => x.UserId == UserId)
            .Select(x => x.ProjectId)
            .ToListAsync();

        var projects = await _Projects
            .Where(p => projectIds.Contains(p.Id))
            .ToListAsync();

        return projects;
    }
}
