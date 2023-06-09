﻿namespace UsersService.Infrastructure.Persistence;

using UsersService.Application.Interfaces.Repositories;
using UsersService.Infrastructure.Persistence.Contexts;
using UsersService.Infrastructure.Persistence.Repositories;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

public static class ServiceRegistration
{
    public static void AddPersistenceInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        if (bool.Parse(configuration.GetSection("UseInMemoryDatabase").Value))
        {
            services.AddDbContext<UsersServiceDbContext>(options =>
                options.UseInMemoryDatabase("UsersServiceDb"));
        }
        else
        {

            services.AddDbContext<UsersServiceDbContext>(options =>
            options.UseNpgsql(
               configuration.GetConnectionString("DefaultConnection"),
               b => b.MigrationsAssembly(typeof(UsersServiceDbContext).Assembly.FullName)));
        }

        services.AddScoped(typeof(IGenericRepositoryAsync<>), typeof(GenericRepositoryAsync<>));
        services.AddScoped<IUserRepositoryAsync, UserRepositoryAsync>();
        services.AddScoped<ICustomerRepositoryAsync, CustomerRepositoryAsync>();
        services.AddScoped<IClaimRepositoryAsync, ClaimRepositoryAsync>();
        services.AddScoped<IJobCommentRepositoryAsync, JobCommentRepositoryAsync>();
        services.AddScoped<IJobFileRepositoryAsync, JobFileRepositoryAsync>();
        services.AddScoped<IJobFollowerRepositoryAsync, JobFollowerRepositoryAsync>();
        services.AddScoped<IJobPriorityRepositoryAsync, JobPriorityRepositoryAsync>();
        services.AddScoped<IJobQARepositoryAsync, JobQARepositoryAsync>();
        services.AddScoped<IJobRepositoryAsync, JobRepositoryAsync>();
        services.AddScoped<IJobStatusRepositoryAsync, JobStatusRepositoryAsync>();
        services.AddScoped<IJobTaskRepositoryAsync, JobTaskRepositoryAsync>();
        services.AddScoped<IJobTypeRepositoryAsync, JobTypeRepositoryAsync>();
        services.AddScoped<IProjectRepositoryAsync, ProjectRepositoryAsync>();
        services.AddScoped<IProjectUserRepositoryAsync, ProjectUserRepositoryAsync>();
        services.AddScoped<ISprintRepositoryAsync, SprintRepositoryAsync>();

    }
}
