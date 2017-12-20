using Movies.Infrastructure.Exceptions;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Linq;

namespace Movies.Infrastructure.Handlers
{
    public class ExceptionHandler
    {
        private Dictionary<Predicate<Exception>, Func<HttpStatusCode>> ExceptionsMatch;

        public ExceptionHandler()
        {
            InitializeExceptionsMatch();
        }
        //TODO: pass new Class with response stauts code and error code.
        protected void InitializeExceptionsMatch(/*klasa ze status code i error code oraz Exceptionem*/)
        {
            //var errorCode = "error";
            //var statusCode = HttpStatusCode.BadRequest;
            //Exception ex=null;

            ExceptionsMatch = new Dictionary<Predicate<Exception>, Func<HttpStatusCode>>();

            addExceptionMatching((ex)=>ex is ServiceException, () => HttpStatusCode.BadRequest);
            //{
            //statusCode = HttpStatusCode.BadRequest;
            //errorCode = (ex as ServiceException).Code;
            //});


            addExceptionMatching((ex) => ex is ArgumentException, () => HttpStatusCode.BadRequest);

            addExceptionMatching((ex)=> ex is Exception, () => HttpStatusCode.InternalServerError);

        }

        private void addExceptionMatching(Predicate<Exception> predicate, Func<HttpStatusCode> func)
        {
            ExceptionsMatch.Add(predicate, func);
        }

        //TODO: return new Class with response and other exceptions data.
        public HttpStatusCode Handle(Exception ex) => ExceptionsMatch.FirstOrDefault(x => x.Key(ex)).Value();
    }
}
