using Movies.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Core.Repositories
{
    public interface IMovieRepository : IRepository
    {
        Task<Movie> GetMovie(Guid id);
        Task AddMovie(Movie movie);
        Task UpdateMovie(Movie movie);
        Task DeleteMovie(Guid id);
        Task<IEnumerable<Movie>> GetAll();
    }
}
