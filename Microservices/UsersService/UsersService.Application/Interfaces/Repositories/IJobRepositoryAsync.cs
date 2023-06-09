﻿namespace UsersService.Application.Interfaces.Repositories;

using UsersService.Domain.Entities;

public interface IJobRepositoryAsync : IGenericRepositoryAsync<Job>
{
    Task<IReadOnlyList<Job>> GetJobsByAssignedUserIdAsync(int AssignedUserId);
    Task<IReadOnlyList<Job>> GetJobsByProjectIdAsync(int ProjectId);
    Task<IReadOnlyList<Job>> GetJobsBySprintAsync(int Sprint);
}
