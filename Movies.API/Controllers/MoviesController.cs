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
        public async Task<IActionResult> GetAsync(GetMovie query)
        {
            var result = await DispatchQueryAsync<GetMovie, MovieDTO>(query);
            if (result == null)
            {
                return NotFound();
            }
            return Json(result);
        }

        [HttpGet]
        public async Task<IActionResult> List(ListMovies query)
        {
            var result = await DispatchQueryAsync<ListMovies, IEnumerable<MovieDTO>>(query);
            return Json(result);
        }


        [HttpPost]
        public async Task<IActionResult> Save([FromBody]CreateMovie command)
        {
            await DispatchAsync(command);
            return Created("api/Movies", null);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody]UpdateMovie command)
        {
            await DispatchAsync(command);
            return NoContent();
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteMovie command)
        {
            await DispatchAsync(command);
            return NoContent();
        }
    }
}