using System.Threading.Tasks;

namespace Movies.Infrastructure.Queries
{
    public interface IQueryHandler<in TQuery, TResult> 
        where TQuery : IQuery
    {
        Task<TResult> Execute(TQuery query);
    }
}