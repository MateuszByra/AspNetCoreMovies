using Movies.Infrastructure.Queries.Movies;
using Movies.Infrastructure.DTO;
using Movies.Infrastructure.Queries;
using Movies.Infrastructure.Services.Movies;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Infrastructure.Handlers.Queries.Movies
{
    public class ListMoviesHandler : QueryHandlerBase<ListMovies, IEnumerable<MovieDTO>, IMovieQueryService>
    {
        public ListMoviesHandler(IMovieQueryService service) : base(service)
        {

        }
        public override Task<IEnumerable<MovieDTO>> Execute(ListMovies query)
        {
            return service.GetAll();
        }
    }
}
