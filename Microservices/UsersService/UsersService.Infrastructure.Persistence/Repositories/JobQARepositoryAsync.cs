﻿namespace UsersService.Infrastructure.Persistence.Repositories;

using UsersService.Application.Interfaces.Repositories;
using UsersService.Domain.Entities;
using UsersService.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

public class JobQARepositoryAsync: GenericRepositoryAsync<JobQA>, IJobQARepositoryAsync
{
  private readonly DbSet<JobQA> _JobQAs;

  public JobQARepositoryAsync(UsersServiceDbContext dbContext) : base(dbContext)
  {
     _JobQAs = dbContext.JobQAs;
  }
}
