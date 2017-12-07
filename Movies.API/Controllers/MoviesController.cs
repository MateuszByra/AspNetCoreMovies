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
using Movies.Infrastructure.Queries;
using Movies.Infrastructure.Queries.Movies;
using Movies.Infrastructure.Services;

namespace Movies.API.Controllers
{
    [Produces("application/json")]
    [Route("api/Movies")]
    public class MoviesController : ApiControllerBase
    {
        public MoviesController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher) : base(commandDispatcher, queryDispatcher)
        {
        }

        [HttpGet("{id}")]
        public IActionResult Get(GetMovie query)
        {
            var result = DispatchQuery<GetMovie, MovieDTO>(query);
            return Json(result);
        }

        [HttpGet]
        public IActionResult List(ListMovies query)
        {
            var result = DispatchQuery<ListMovies, IEnumerable<MovieDTO>>(query);
            return Json(result);
        }


        [HttpPost]
        public IActionResult Save([FromBody]CreateMovie command)
        {
            Dispatch(command);
            return Created("api/Movies", null);
        }

        [HttpPut]
        public IActionResult Update([FromBody]UpdateMovie command)
        {
            Dispatch(command);
            return Ok();
        }
        [HttpDelete]
        public IActionResult Delete(DeleteMovie command)
        {
            Dispatch(command);
            return Ok();
        }
    }
}