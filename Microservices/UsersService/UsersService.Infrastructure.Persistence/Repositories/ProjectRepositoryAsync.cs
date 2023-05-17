namespace UsersService.Infrastructure.Persistence.Repositories;

using UsersService.Application.Interfaces.Repositories;
using UsersService.Domain.Entities;
using UsersService.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

public class ProjectRepositoryAsync: GenericRepositoryAsync<Project>, IProjectRepositoryAsync
{
  private readonly DbSet<Project> _Projects;

  public ProjectRepositoryAsync(UsersServiceDbContext dbContext) : base(dbContext)
  {
     _Projects = dbContext.Projects;
  }
}
