namespace UsersService.Application.Interfaces.Repositories;

using UsersService.Domain.Entities;

public interface IProjectUserRepositoryAsync : IGenericRepositoryAsync<ProjectUser>
{
    Task<IReadOnlyList<ProjectUser>> GetProjectsByUserIdAsync(int UserId);
}
