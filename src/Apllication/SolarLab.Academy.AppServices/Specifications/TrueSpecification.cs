using System.Linq.Expressions;

namespace SolarLab.Academy.AppServices.Specifications;

public class TrueSpecification<T> : Specification<T>
{
    public override Expression<Func<T, bool>> ToExpression()
    {
        return _ => true;
    }
}