using AutoMapper;
using Movies.Infrastructure.DTO;
using Movies.Infrastructure.Queries;
using Movies.Infrastructure.Queries.Movies;
using Movies.Infrastructure.Services;

namespace Movies.Infrastructure.Handlers.Queries.Movies
{
    public class GetMoviesHandler : QueryHandlerBase<GetMovie,MovieDTO,IMovieService>
    {
        public GetMoviesHandler(IMovieService service, IMapper mapper) : base(service, mapper)
        {
        }

        public override MovieDTO Execute(GetMovie query)
        {
            var result= service.GetMovie(query.Id);
            return Map<MovieDTO>(result);
        }
    }
}