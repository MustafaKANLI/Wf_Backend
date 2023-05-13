namespace UsersService.Infrastructure.Persistence.Repositories;

using UsersService.Application.Interfaces.Repositories;
using UsersService.Domain.Entities;
using UsersService.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

public class JobCommentRepositoryAsync: GenericRepositoryAsync<JobComment>, IJobCommentRepositoryAsync
{
  private readonly DbSet<JobComment> _JobComments;

  public JobCommentRepositoryAsync(UsersServiceDbContext dbContext) : base(dbContext)
  {
     _JobComments = dbContext.JobComments;
  }
}
