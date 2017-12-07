using Movies.Infrastructure.Commands.Movies;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Infrastructure.Services.Movies
{
    public interface IMovieCommandService : IService
    {
        Task CreateMovie(CreateMovie command);
        Task DeleteMovie(Guid id);
        Task UpdateMovie(UpdateMovie command);
    }
}
