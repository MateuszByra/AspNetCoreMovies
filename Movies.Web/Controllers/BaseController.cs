using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Movies.Infrastructure.Commands;

namespace Movies.Web.Controllers
{
    public class BaseController : Controller
    {
        private readonly ICommandDispatcher _commandDispatcher;
        protected readonly IMapper _mapper;

        protected BaseController(ICommandDispatcher commandDispatcher, IMapper mapper)
        {
            _commandDispatcher = commandDispatcher;
            _mapper = mapper;
        }

        protected void Dispatch<TviewModel, Tcommand>(TviewModel model) where Tcommand : ICommand
        {/*try,catch*/
            var command = _mapper.Map<TviewModel, Tcommand>(model);
            _commandDispatcher.Dispatch(command);
        }
    }
}