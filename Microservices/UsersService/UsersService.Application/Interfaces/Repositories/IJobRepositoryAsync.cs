namespace UsersService.Application.Interfaces.Repositories;

using UsersService.Domain.Entities;

public interface IJobRepositoryAsync : IGenericRepositoryAsync<Job>
{
    Task<IReadOnlyList<Job>> GetJobsByAssignedUserIdAsync(int AssignedUserId);
}
