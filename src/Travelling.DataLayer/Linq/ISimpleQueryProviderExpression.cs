using Travelling.DataLayer.Expressions;

namespace Travelling.DataLayer.Linq
{
    public interface ISimpleQueryProviderExpression<TModel>
    {
        SqlExpression<TModel> AtlasSqlExpression { get; }
    }
}