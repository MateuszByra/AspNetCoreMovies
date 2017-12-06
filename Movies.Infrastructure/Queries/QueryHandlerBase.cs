using AutoMapper;
using Movies.Infrastructure.Services;

namespace Movies.Infrastructure.Queries
{
    public abstract class QueryHandlerBase<TQuery, TResult, TService> : IQueryHandler<TQuery, TResult>
        where TQuery : IQuery
        where TService : IService
    {
        protected TService service;
        private IMapper _mapper;

        protected QueryHandlerBase(TService service, IMapper mapper)
        {
            this.service = service;
            this._mapper = mapper;
        }

        public abstract TResult Execute(TQuery query);
        //TODO mapping in this class before return data;

        protected TResult Map<T>(T data) where T:class
        {
            return _mapper.Map<T, TResult>(data);
        }
    }
}