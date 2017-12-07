using Movies.Infrastructure.Commands;
using Movies.Infrastructure.Commands.Movies;
using Movies.Infrastructure.Services.Movies;

namespace Movies.Infrastructure.Handlers.Commands.Movies
{
    public class DeleteMovieHandler : CommandHandlerBase<IMovieCommandService,DeleteMovie>
    {
        public DeleteMovieHandler(IMovieCommandService service) : base(service)
        {    
        }

        public override void Handle(DeleteMovie command)
        {
           service.DeleteMovie(command.Id);
        }
    }
}