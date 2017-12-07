using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Movies.Infrastructure.Services
{
    public abstract class ServiceBase
    {
        private readonly IMapper _mapper;

        public ServiceBase(IMapper mapper)
        {
            _mapper = mapper;
        }

        protected TResult Map<TSource, TResult>(TSource source) where TSource : class
        {
            return _mapper.Map<TSource,TResult>(source);
        }
    }
}
