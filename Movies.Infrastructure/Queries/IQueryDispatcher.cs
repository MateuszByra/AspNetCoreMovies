namespace Movies.Infrastructure.Queries
{
    public interface IQueryDispatcher
    {
        TResult Dispatch<TQuery, TResult>(TQuery query) where TQuery : IQuery;
    }
}