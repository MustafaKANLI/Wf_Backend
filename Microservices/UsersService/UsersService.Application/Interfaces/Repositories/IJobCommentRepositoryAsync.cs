namespace UsersService.Application.Interfaces.Repositories;

using UsersService.Domain.Entities;

public interface IJobCommentRepositoryAsync : IGenericRepositoryAsync<JobComment>
{
    Task<IReadOnlyList<JobComment>> GetJobCommentsByJobIdAsync(int JobId);
}
