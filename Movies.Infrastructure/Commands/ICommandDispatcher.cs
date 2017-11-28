using System;
using System.Collections.Generic;
using System.Text;

namespace Movies.Infrastructure.Commands
{
    public interface ICommandDispatcher
    {
        void Dispatch<T>(T command) where T : ICommand;
    }
}
