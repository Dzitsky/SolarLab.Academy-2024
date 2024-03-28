using SolarLab.Academy.AppServices.Specifications;
using SolarLab.Academy.Contracts.Users;
using SolarLab.Academy.Domain.Users.Entity;

namespace SolarLab.Academy.AppServices.Users.Repositories;

/// <summary>
/// Репозиторий для работы с пользователями.
/// </summary>
public interface IUserRepository
{
    Task<ResultWithPagination<UserDto>> GetAll(GetAllUsersRequest request, CancellationToken cancellationToken);
    
    Task<IEnumerable<UserDto>> GetAllBySpecification(Specification<User> specification, CancellationToken cancellationToken);

    Task<UserDto> GetByIdAsync(Guid id, CancellationToken cancellationToken);

    Task AddAsync(User entity, CancellationToken cancellationToken);

    Task UpdateAsync(UserDto model, CancellationToken cancellationToken);

    Task DeleteAsync(Guid id, CancellationToken cancellationToken);
}