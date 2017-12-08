using System;
using System.Threading.Tasks;
using Autofac;
using Movies.Infrastructure.Commands;

namespace Movies.Infrastructure.Queries
{
    public class QueryDispatcher : IQueryDispatcher
    {
        private readonly IComponentContext _context;

        public QueryDispatcher(IComponentContext context)
        {
            _context = context;
        }

        public async Task<TResult> Dispatch<TQuery, TResult>(TQuery query) where TQuery : IQuery
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query),
                    $"Query: '{typeof(TQuery).Name}' can not be null.");
            }
            var handler = _context.Resolve<IQueryHandler<TQuery, TResult>>();
            return await handler.Execute(query);
        }
    }
}