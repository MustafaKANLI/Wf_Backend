namespace UsersService.Application.Interfaces.Repositories;

using UsersService.Domain.Entities;

public interface IJobQARepositoryAsync : IGenericRepositoryAsync<JobQA>
{
    Task<IReadOnlyList<JobQA>> GetJobQAsByJobIdAsync(int JobId);
}
