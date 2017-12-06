using Movies.Infrastructure.Commands;
using Movies.Infrastructure.Commands.Movies;
using Movies.Infrastructure.Services;

namespace Movies.Infrastructure.Handlers.Movies
{
    public class UpdateMovieHandler : CommandHandlerBase<IMovieService, UpdateMovie>
    {
        public UpdateMovieHandler(IMovieService service) : base(service)
        {
        }

        public override void Handle(UpdateMovie command)
        {
            service.UpdateMovie(command);
        }
    }
}