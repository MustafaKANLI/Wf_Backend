namespace UsersService.Application.Interfaces.Repositories;

using UsersService.Domain.Entities;

public interface ISprintRepositoryAsync : IGenericRepositoryAsync<Sprint>
{
    Task<IReadOnlyList<Sprint>> GetSprintsByCustomerIdAsync(int CustomerId);
}
