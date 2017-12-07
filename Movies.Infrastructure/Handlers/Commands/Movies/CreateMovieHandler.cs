using Movies.Infrastructure.Commands;
using Movies.Infrastructure.Commands.Movies;
using Movies.Infrastructure.Services.Movies;

namespace Movies.Infrastructure.Handlers.Commands.Movies
{
    public class CreateMovieHandler : CommandHandlerBase<IMovieCommandService,CreateMovie>
    {
        public CreateMovieHandler(IMovieCommandService service) : base(service)
        {
        }

        public override void Handle(CreateMovie command)
        {
            service.CreateMovie(command);
        }
    }
}
