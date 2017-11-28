using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Movies.Infrastructure.Services;
using Movies.Infrastructure.Commands;
using Movies.Infrastructure.Commands.Movies;
using Movies.Web.Models;

namespace Movies.Web.Controllers
{
    public class MoviesController : Controller
    {
        //private readonly IMovieService _moviesService;
        private readonly ICommandDispatcher _commandDispatcher;

        public MoviesController(IMovieService moviesService, ICommandDispatcher commandDispatcher)
        {
            //_moviesService = moviesService;
            _commandDispatcher = commandDispatcher;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddMovie(MovieViewModel model)
        {
            //_commandDispatcher.Dispatch(command);
            return View("Index");
        }
    }
}