using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Movies.Core.Domain;

namespace Movies.Infrastructure.Services
{
    public abstract class ServiceBase
    {
        private readonly IMapper _mapper;

        public ServiceBase(IMapper mapper)
        {
            _mapper = mapper;
        }

        protected TResult Map<TSource, TResult>(IEnumerable<Movie> source) where TSource : class
        {
            return _mapper.Map<TSource,TResult>(source);
        }

        protected T2 Map<T1, T2>(Task<T1> task)
        {
            throw new NotImplementedException();
        }
    }
}
