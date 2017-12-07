using System.Threading.Tasks;
using Movies.Infrastructure.Commands;
using Movies.Infrastructure.Commands.Movies;
using Movies.Infrastructure.Services.Movies;

namespace Movies.Infrastructure.Handlers.Commands.Movies
{
    public class UpdateMovieHandler : CommandHandlerBase<IMovieCommandService, UpdateMovie>
    {
        public UpdateMovieHandler(IMovieCommandService service) : base(service)
        {
        }

        public override Task Handle(UpdateMovie command)
        {
            return service.UpdateMovie(command);
        }
    }
}