using Movies.Infrastructure.Commands;
using Movies.Infrastructure.Commands.Movies;
using Movies.Infrastructure.Services.Movies;
using System.Threading.Tasks;

namespace Movies.Infrastructure.Handlers.Commands.Movies
{
    public class CreateMovieHandler : CommandHandlerBase<IMovieCommandService,CreateMovie>
    {
        public CreateMovieHandler(IMovieCommandService service) : base(service)
        {
        }

        public override async Task HandleAsync(CreateMovie command)
        {
            await service.CreateMovie(command);
        }
    }
}
