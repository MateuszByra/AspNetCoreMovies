using Movies.Infrastructure.Commands;
using Movies.Infrastructure.Commands.Movies;
using Movies.Infrastructure.Services;

namespace Movies.Infrastructure.Handlers.Movies
{
    public class DeleteMovieHandler : ICommandHandler<DeleteMovie>
    {
        private readonly IMovieService _movieService;
        public DeleteMovieHandler(IMovieService movieService)
        {
            _movieService = movieService;
        }
        public void Handle(DeleteMovie command)
        {
           _movieService.DeleteMovie(command.Id);
        }
    }
}