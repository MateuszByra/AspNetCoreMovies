using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Movies.Infrastructure.Commands;
using Movies.Infrastructure.Queries;
using System.Net;

[Route("[controller]")]
public abstract class ApiControllerBase : Controller
{
    private readonly ICommandDispatcher _commandDispatcher;
    private readonly IQueryDispatcher _queryDispatcher;

    protected Guid UserId => User?.Identity?.IsAuthenticated == true ?
        Guid.Parse(User.Identity.Name) :
        Guid.Empty;

    protected ApiControllerBase(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher)
    {
        _commandDispatcher = commandDispatcher;
        _queryDispatcher = queryDispatcher;
    }

    protected async Task DispatchAsync<Tcommand>(Tcommand command) where Tcommand : ICommand
    {/*try,catch*/
        await _commandDispatcher.Dispatch(command);
    }

    protected async Task<TResult> DispatchQueryAsync<TQuery, TResult>(TQuery query) where TQuery : IQuery
    {
        return await _queryDispatcher.Dispatch<TQuery, TResult>(query);
    }
}