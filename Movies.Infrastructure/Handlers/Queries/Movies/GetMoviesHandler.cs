using System.Threading.Tasks;
using AutoMapper;
using Movies.Infrastructure.DTO;
using Movies.Infrastructure.Queries;
using Movies.Infrastructure.Queries.Movies;
using Movies.Infrastructure.Services;
using Movies.Infrastructure.Services.Movies;

namespace Movies.Infrastructure.Handlers.Queries.Movies
{
    public class GetMoviesHandler : QueryHandlerBase<GetMovie,MovieDTO, IMovieQueryService>
    {
        public GetMoviesHandler(IMovieQueryService service) : base(service)
        {
        }

        public override Task<MovieDTO> Execute(GetMovie query)
        {
            return service.GetMovie(query.Id);
        }
    }
}