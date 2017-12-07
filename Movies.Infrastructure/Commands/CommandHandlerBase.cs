using Movies.Infrastructure.Services;
using System.Threading.Tasks;

namespace Movies.Infrastructure.Commands
{
    public abstract class CommandHandlerBase<TService, TCommand> : ICommandHandler<TCommand>
        where TCommand : ICommand
        where TService : IService

    {
        protected TService service;

        protected CommandHandlerBase(TService service)
        {
            this.service = service;
        }

        public abstract Task Handle(TCommand command);
    }
}