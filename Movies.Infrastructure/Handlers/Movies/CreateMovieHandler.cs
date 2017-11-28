using Movies.Infrastructure.Commands;
using Movies.Infrastructure.Commands.Movies;
using Movies.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Movies.Infrastructure.Handlers.Movies
{
    public class CreateMovieHandler : ICommandHandler<CreateMovie>
    {
        private readonly IMovieService _movieService;

        public CreateMovieHandler(IMovieService movieService)
        {
            _movieService = movieService;
        }
        public void Handle(CreateMovie command)
        {
            _movieService.CreateMovie(command);
        }
    }
}
