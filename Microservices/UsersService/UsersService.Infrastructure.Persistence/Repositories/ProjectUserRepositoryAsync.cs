namespace UsersService.Infrastructure.Persistence.Repositories;

using UsersService.Application.Interfaces.Repositories;
using UsersService.Domain.Entities;
using UsersService.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

public class ProjectUserRepositoryAsync: GenericRepositoryAsync<ProjectUser>, IProjectUserRepositoryAsync
{
  private readonly DbSet<ProjectUser> _ProjectUsers;

  public ProjectUserRepositoryAsync(UsersServiceDbContext dbContext) : base(dbContext)
  {
     _ProjectUsers = dbContext.ProjectUsers;
  }
}
