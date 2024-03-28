namespace SolarLab.Academy.Contracts.Users;

public class GetAllUsersRequest
{
    public int PageNumber { get; set; }
    public int Batchsize { get; set; } = 10;
}