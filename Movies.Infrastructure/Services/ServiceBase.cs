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

        protected ServiceBase(IMapper mapper)
        {
            _mapper = mapper;
        }

        protected TResult Map<TSource, TResult>(TSource source) where TSource : class
        {
            return _mapper.Map<TSource, TResult>(source);
        }
    }
}
