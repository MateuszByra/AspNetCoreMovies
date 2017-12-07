using System.Threading.Tasks;

namespace Movies.Infrastructure.Queries
{
    public interface IQueryDispatcher
    {
        Task<TResult> Dispatch<TQuery, TResult>(TQuery query) where TQuery : IQuery;
    }
}