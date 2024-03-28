using System.Linq.Expressions;
using SolarLab.Academy.AppServices.Specifications;
using SolarLab.Academy.Domain.Users.Entity;

namespace SolarLab.Academy.AppServices.Users.Specifications;

public class Older18specification : Specification<User>
{
    public override Expression<Func<User, bool>> ToExpression()
    {
        var date = DateTime.UtcNow.Subtract(TimeSpan.FromDays(365 * 18));
        return user => user.BirthDate < date;
    }
}