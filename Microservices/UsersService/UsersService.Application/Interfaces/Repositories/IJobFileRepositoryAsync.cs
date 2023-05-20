namespace UsersService.Application.Interfaces.Repositories;

using UsersService.Domain.Entities;

public interface IJobFileRepositoryAsync : IGenericRepositoryAsync<JobFile>
{
    Task<IReadOnlyList<JobFile>> GetJobFilesByJobIdAsync(int jobId);
}
