using Movies.Infrastructure.Commands.Movies;
using System;
using System.Collections.Generic;
using System.Text;

namespace Movies.Infrastructure.Services.Movies
{
    public interface IMovieCommandService : IService
    {
        void CreateMovie(CreateMovie command);
        void DeleteMovie(Guid id);
        void UpdateMovie(UpdateMovie command);
    }
}
