using Movies.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using Movies.Core.Domain;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.Infrastructure.Repositories
{
    public class InMemoryMovieRepository : IMovieRepository, ILiteDbRepository
    {
        private static ISet<Movie> _movies = new HashSet<Movie>();

        public async Task AddMovie(Movie movie)
        {
            _movies.Add(movie);
            await Task.CompletedTask;
        }

        public async Task DeleteMovie(Guid id)
        {
            var movie = await GetMovie(id);
            _movies.Remove(movie);
            await Task.CompletedTask;
        }

        public async Task<IEnumerable<Movie>> GetAllAsync() => await Task.FromResult(_movies);

        public async Task<Movie> GetMovie(Guid id) => await Task.FromResult(_movies.FirstOrDefault(x => x.Id == id));

        public async Task UpdateMovie(Movie movie)
        {
            await DeleteMovie(movie.Id);
            await AddMovie(movie);
        }
    }
}
