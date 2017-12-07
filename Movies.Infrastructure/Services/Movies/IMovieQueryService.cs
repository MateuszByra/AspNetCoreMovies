using Movies.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Infrastructure.Services.Movies
{
    public interface IMovieQueryService : IService
    {
        Task<MovieDTO> GetMovie(Guid id);
        Task<IEnumerable<MovieDTO>> GetAll();
    }
}
