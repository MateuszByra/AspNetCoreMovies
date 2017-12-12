using Movies.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Movies.Infrastructure.Exceptions
{
    public class ServiceException : MoviesException
    {
        public ServiceException()
        {

        }

        public ServiceException(string code) : base(code)
        {

        }

        public ServiceException(string message, params object[] args) : base(string.Empty, message, args)
        {

        }
        public ServiceException(string code, string message, params object[] args) : base(null, code, message, args)
        {

        }

        public ServiceException(Exception inerException, string message, params object[] args) : base(inerException, string.Empty, message, args)
        {

        }

        public ServiceException(Exception inerException, string code, string message, params object[] args) : base(string.Format(message, args), inerException)
        {

        }
    }
}
