using Movies.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Movies.Infrastructure.Services.Movies
{
    public interface IMovieQueryService : IService
    {
        MovieDTO GetMovie(Guid id);
        IEnumerable<MovieDTO> GetAll();
    }
}
