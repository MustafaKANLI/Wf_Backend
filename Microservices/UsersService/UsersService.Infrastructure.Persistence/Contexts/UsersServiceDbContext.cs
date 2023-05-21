namespace UsersService.Infrastructure.Persistence.Contexts;

using Microsoft.EntityFrameworkCore;
using UsersService.Domain.Entities;
using Common.Entities;

public class UsersServiceDbContext: DbContext
{
  public UsersServiceDbContext(DbContextOptions<UsersServiceDbContext> options) : base(options)
  {
    ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
  }

  public DbSet<User> Users { get; set; }
  public DbSet<Customer> Customers { get; set; }
  public DbSet<Claim> Claims { get; set; }
  public DbSet<JobComment> JobComments { get; set; }
  public DbSet<JobFile> JobFiles { get; set; }
  public DbSet<JobFollower> JobFollowers { get; set; }
  public DbSet<JobPriority> JobPriorities { get; set; }
  public DbSet<JobQA> JobQAs { get; set; }
  public DbSet<Job> Jobs { get; set; }
  public DbSet<JobStatus> JobStatuses { get; set; }
  public DbSet<JobTask> JobTasks { get; set; }
  public DbSet<JobType> JobTypes { get; set; }
  public DbSet<Project> Projects { get; set; }
  public DbSet<ProjectUser> ProjectUsers { get; set; }
  public DbSet<Sprint> Sprints { get; set; }


    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
  {
    //foreach (var entry in ChangeTracker.Entries<AuditableBaseEntity>())
    //{
    //  switch (entry.State)
    //  {
    //    case EntityState.Added:
    //      entry.Entity.Created = DateTime.UtcNow;
    //      break;
    //    case EntityState.Modified:
    //      entry.Entity.LastModified = DateTime.UtcNow;
    //      break;
    //  }
    //}
    return base.SaveChangesAsync(cancellationToken);
  }

  protected override void OnModelCreating(ModelBuilder builder)
  {
    //All Decimals will have 18,6 Range
    foreach (var property in builder.Model.GetEntityTypes()
      .SelectMany(t => t.GetProperties())
      .Where(p => p.ClrType == typeof(decimal) || p.ClrType == typeof(decimal?)))
      {
        property.SetColumnType("decimal(18,6)");
      }

    base.OnModelCreating(builder);
  }
}
