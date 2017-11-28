using Movies.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Movies.Core.Repositories
{
    public interface IMovieRepository : IRepository
    {
        Movie GetMovie(Guid id);
        void AddMovie(Movie movie);
        void UpdateMovie(Movie movie);
        void DeleteMovie(Guid id);
        IEnumerable<Movie> GetAll();
    }
}
