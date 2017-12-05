using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movies.Infrastructure.Commands;
using Movies.Infrastructure.Commands.Movies;
using Movies.Infrastructure.DTO;
using Movies.Infrastructure.Services;

namespace Movies.API.Controllers
{
    [Produces("application/json")]
    [Route("api/Movies")]
    public class MoviesController : ApiControllerBase
    {
        private readonly IMovieService _movieService;
        public MoviesController(ICommandDispatcher commandDispatcher, IMovieService movieService) : base(commandDispatcher)
        {
            _movieService = movieService;
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var result=_movieService.GetMovie(id);
            return Json(result);
        }

        [HttpGet]
        public IActionResult List()
        {
            var result = _movieService.GetAll();
            return Json(result);
        }


        [HttpPost]
        public IActionResult Save([FromBody]CreateMovie command)
        {
            Dispatch(command);
            return Created("api/Movies", null);
        }

        [HttpPut]
        public IActionResult Update([FromBody]MovieDTO command)
        {
            _movieService.UpdateMovie(command.Id, command.Title, command.DurationMinutes);
            return Created("api/Movies", null);
        }
        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            _movieService.DeleteMovie(id);
            return Created("api/Movies", null);
        }
    }
}