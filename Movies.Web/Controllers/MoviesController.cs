using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Movies.Infrastructure.Services;
using Movies.Infrastructure.Commands;
using Movies.Infrastructure.Commands.Movies;
using Movies.Web.Models;
using AutoMapper;

namespace Movies.Web.Controllers
{
    public class MoviesController : BaseController
    {

        public MoviesController(ICommandDispatcher commandDispatcher, IMapper mapper) : base(commandDispatcher,mapper)
        {
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddMovie(MovieViewModel model)
        {
            Dispatch<MovieViewModel, CreateMovie>(model);
            return View("Index");
        }
    }
}