using Microsoft.AspNetCore.Http;
using Movies.Infrastructure.Exceptions;
using Movies.Infrastructure.Handlers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Movies.API.Middlewares
{
    public class ExceptionsHanlingMiddleware
    {
        private readonly RequestDelegate next;

        public ExceptionsHanlingMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var errorCode = "error";
            var statusCode = HttpStatusCode.BadRequest;
            var exceptionType = exception.GetType();

            var testStatusCode=new ExceptionHandler().Handle(exception); //TODO: inject in constructor, use autofac
            // add class with ErrorCode, StatusCode and Exception.

            //TODO: hanling exception response in MVC project.

            //switch (exception)
            //{//TODO: other exceptions types handling
            //    case ServiceException e when exceptionType == typeof(ServiceException):
            //        statusCode = HttpStatusCode.BadRequest;
            //        errorCode = e.Code;
            //        break;
            //    case Exception e when exceptionType == typeof(Exception):
            //        statusCode = HttpStatusCode.InternalServerError;
            //        break;
            //}

            var response = new { code = errorCode, message = exception.Message };
            var payload = JsonConvert.SerializeObject(response);
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;
            return context.Response.WriteAsync(payload);
        }
    }
}
