namespace UsersService.Application.Interfaces.Repositories;

using UsersService.Domain.Entities;

public interface IJobFollowerRepositoryAsync : IGenericRepositoryAsync<JobFollower>
{
    Task<IReadOnlyList<JobFollower>> GetJobFollowersByJobIdAsync(int JobId);
}
