namespace SolarLab.Academy.Contracts.Users;

public class ResultWithPagination<T>
{
    public IEnumerable<T> Result { get; set; }
    public int AvailablePages { get; set; }
}