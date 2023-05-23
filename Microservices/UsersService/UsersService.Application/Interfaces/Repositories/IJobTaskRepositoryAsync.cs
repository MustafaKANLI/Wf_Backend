namespace UsersService.Application.Interfaces.Repositories;

using UsersService.Domain.Entities;

public interface IJobTaskRepositoryAsync : IGenericRepositoryAsync<JobTask>
{
    Task<IReadOnlyList<JobTask>> GetJobTasksByJobIdAsync(int JobId);
}
