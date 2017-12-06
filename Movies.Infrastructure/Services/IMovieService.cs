using Movies.Infrastructure.Commands.Movies;
using Movies.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Movies.Infrastructure.Services
{
    public interface IMovieService : IService
    {
        IEnumerable<MovieDTO> GetAll();
        void CreateMovie(CreateMovie command);
        void DeleteMovie(Guid id);
        MovieDTO GetMovie(Guid id);
        void UpdateMovie(UpdateMovie command);
    }
}
