using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Movies.Infrastructure.Commands;

[Route("[controller]")]
public abstract class ApiControllerBase : Controller
{
    private readonly ICommandDispatcher _commandDispatcher;

    protected Guid UserId => User?.Identity?.IsAuthenticated == true ?
        Guid.Parse(User.Identity.Name) :
        Guid.Empty;

    protected ApiControllerBase(ICommandDispatcher commandDispatcher)
    {
        _commandDispatcher = commandDispatcher;
    }

    protected void Dispatch<Tcommand>(Tcommand command) where Tcommand : ICommand
    {/*try,catch*/

        _commandDispatcher.Dispatch(command);

    }
}