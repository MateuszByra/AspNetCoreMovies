using System;
using System.Collections.Generic;
using System.Text;

namespace Movies.Core.Exceptions
{
    public class MoviesException : Exception
    {
        public string Code { get; }

        protected MoviesException()
        {

        }

        protected MoviesException(string code)
        {
            Code = code;
        }

        protected MoviesException(string message, params object[]args):this(string.Empty, message, args)
        {

        }
        protected MoviesException(string code, string message, params object[] args) : this(null, code, message, args)
        {

        }

        protected MoviesException(Exception inerException, string message, params object[] args) : this(inerException, string.Empty, message, args)
        {

        }

        protected MoviesException(Exception inerException, string code, string message, params object[] args) : base(string.Format(message, args), inerException)
        {
            Code = code;
        }
    }
}
