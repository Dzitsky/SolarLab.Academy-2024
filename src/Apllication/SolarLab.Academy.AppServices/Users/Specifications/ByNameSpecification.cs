using System.Linq.Expressions;
using SolarLab.Academy.AppServices.Specifications;
using SolarLab.Academy.Domain.Users.Entity;

namespace SolarLab.Academy.AppServices.Users.Specifications;

public class ByNameSpecification : Specification<User>
{
    private readonly string _name;

    public ByNameSpecification(string name)
    {
        _name = name;
    }

    public override Expression<Func<User, bool>> ToExpression()
    {
        return user => user.FirstName == _name;
    }
}