using Movies.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Movies.Infrastructure.Services
{
    public interface IMovieService : IService
    {
        IEnumerable<MovieDTO> GetAll();
        void CreateMovie(string title, double durationInMinutes);
        void DeleteMovie(Guid id);
        MovieDTO GetMovie(Guid id);
        void UpdateMovie(Guid id,string title, double durationInMinutes);
    }
}
