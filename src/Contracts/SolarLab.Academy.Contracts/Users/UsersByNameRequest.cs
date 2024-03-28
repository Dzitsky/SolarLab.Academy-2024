namespace SolarLab.Academy.Contracts.Users;

/// <summary>
/// Запрос на получение пользователей по имени.
/// </summary>
public class UsersByNameRequest
{
    /// <summary>
    /// Имя пользователя.
    /// </summary>
    public string Name { get; set; }
    
    /// <summary>
    /// Искать ли старше 18.
    /// </summary>
    public bool IsOlder18 { get; set; }
}