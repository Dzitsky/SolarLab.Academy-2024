using SolarLab.Academy.Contracts.Users;

namespace SolarLab.Academy.AppServices.Users.Services;

/// <summary>
/// Сервис работы с пользователями.
/// </summary>
public interface IUserService
{
    /// <summary>
    /// Возвращает всех пользователей.
    /// </summary>
    /// <returns>Список пользователей <see cref="UserDto"/>.</returns>
    Task<ResultWithPagination<UserDto>> GetUsersAsync(GetAllUsersRequest request, CancellationToken cancellationToken);
    
    /// <summary>
    /// Получает пользователей по имени.
    /// </summary>
    /// <param name="request">Запрос.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Коллекцию моделей пользователей.</returns>
    Task<IEnumerable<UserDto>> GetUsersByNameAsync(UsersByNameRequest request, CancellationToken cancellationToken);

    ValueTask<UserDto> GetByIdAsync(Guid id, CancellationToken cancellationToken);

    Task<Guid> AddAsync(CreateUserRequest model, CancellationToken cancellationToken);

    Task UpdateAsync(UserDto model, CancellationToken cancellationToken);

    Task DeleteAsync(Guid id, CancellationToken cancellationToken);
}