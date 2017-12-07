using System.Threading.Tasks;

namespace Movies.Infrastructure.Queries
{
    public interface IQueryHandler<in TQuery, out TResult> 
        where TQuery : IQuery
    {
        TResult Execute(TQuery query);
    }
}