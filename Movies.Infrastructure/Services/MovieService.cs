using System;
using System.Collections.Generic;
using System.Text;
using Movies.Infrastructure.DTO;
using Movies.Core.Repositories;
using AutoMapper;
using Movies.Core.Domain;

namespace Movies.Infrastructure.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;

        public MovieService(IMovieRepository movieRepository, IMapper mapper)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
        }

        public void CreateMovie(string title, double durationInMinutes)
        {
            var movie = new Movie(title, durationInMinutes);
            _movieRepository.AddMovie(movie);
        }

        public void DeleteMovie(Guid id)
        {
            _movieRepository.DeleteMovie(id);
        }

        public IEnumerable<MovieDTO> GetAll()
        {
            return _mapper.Map<IEnumerable<Movie>, IEnumerable<MovieDTO>>(_movieRepository.GetAll());
        }

        public MovieDTO GetMovie(Guid id)
        {
            var movie = _movieRepository.GetMovie(id);
            return _mapper.Map<Movie, MovieDTO>(movie);
        }

        public void UpdateMovie(Guid id, string title, double durationInMinutes)
        {
            var movie = _movieRepository.GetMovie(id);
            movie.Title = title;
            movie.DurationMinutes = durationInMinutes;
            _movieRepository.UpdateMovie(movie);
        }
    }
}
