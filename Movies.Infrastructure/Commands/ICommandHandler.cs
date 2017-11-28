using System;
using System.Collections.Generic;
using System.Text;

namespace Movies.Infrastructure.Commands
{
    public interface ICommandHandler<T> where T : ICommand
    {
        void Handle(T command);
    }
}
