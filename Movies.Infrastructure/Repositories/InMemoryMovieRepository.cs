using Movies.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using Movies.Core.Domain;
using System.Linq;

namespace Movies.Infrastructure.Repositories
{
    public class InMemoryMovieRepository : IMovieRepository
    {
        private ISet<Movie> _movies = new HashSet<Movie>();

        public void AddMovie(Movie movie)
        {
            _movies.Add(movie);
        }

        public void DeleteMovie(Guid id)
        {
            var movie = GetMovie(id);
            _movies.Remove(movie);
        }

        public IEnumerable<Movie> GetAll() => _movies;

        public Movie GetMovie(Guid id) => _movies.FirstOrDefault(x => x.Id == id);

        public void UpdateMovie(Movie movie)
        {
            DeleteMovie(movie.Id);
            AddMovie(movie);
        }
    }
}
