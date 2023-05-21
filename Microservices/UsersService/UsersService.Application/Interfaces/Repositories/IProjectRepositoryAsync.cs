namespace UsersService.Application.Interfaces.Repositories;

using UsersService.Domain.Entities;

public interface IProjectRepositoryAsync : IGenericRepositoryAsync<Project>
{
    Task<IReadOnlyList<Project>> GetProjectsByUserIdAsync(int UserId);
}
