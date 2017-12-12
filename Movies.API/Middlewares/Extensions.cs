using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.API.Middlewares
{
    public static class Extensions
    {
        public static IApplicationBuilder UseMoviesExceptionHandler(this IApplicationBuilder builder) 
            => builder.UseMiddleware(typeof(ExceptionsHanlingMiddleware));
    }
}
