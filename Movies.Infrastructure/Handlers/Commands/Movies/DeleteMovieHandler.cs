using Movies.Infrastructure.Commands;
using Movies.Infrastructure.Commands.Movies;
using Movies.Infrastructure.Services.Movies;
using System.Threading.Tasks;

namespace Movies.Infrastructure.Handlers.Commands.Movies
{
    public class DeleteMovieHandler : CommandHandlerBase<IMovieCommandService,DeleteMovie>
    {
        public DeleteMovieHandler(IMovieCommandService service) : base(service)
        {    
        }

        public override async Task HandleAsync(DeleteMovie command)
        {
           await service.DeleteMovie(command.Id);
        }
    }
}