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
        private readonly IMovieService _movieService;

        public MoviesController(ICommandDispatcher commandDispatcher,
            IMapper mapper,
            IMovieService movieService) : base(commandDispatcher, mapper)
        {
            _movieService = movieService;
        }

        public IActionResult Index()
        {
            return View(_movieService.GetAll());
        }

        public IActionResult CreateMovie()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddMovie(MovieViewModel model)
        {
            if (Dispatch<MovieViewModel, CreateMovie>(model))
            {
                return RedirectToAction("Index");
            }
            return View("CreateMovie", model);
        }
    }
}