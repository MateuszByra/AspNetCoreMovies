using AutoMapper;
using Movies.Infrastructure.Services;

namespace Movies.Infrastructure.Queries
{
    public abstract class QueryHandlerBase<TQuery, TResult, TService> : IQueryHandler<TQuery, TResult>
        where TQuery : IQuery
        where TService : IService
    {
        protected TService service;

        protected QueryHandlerBase(TService service)
        {
            this.service = service;
        }

        public abstract TResult Execute(TQuery query);
    }
}