using System;
using System.Collections.Generic;
using System.Text;
using Movies.Infrastructure.DTO;
using Movies.Core.Repositories;
using AutoMapper;
using Movies.Core.Domain;
using Movies.Infrastructure.Commands.Movies;
using Movies.Infrastructure.Services.Movies;
using System.Threading.Tasks;

namespace Movies.Infrastructure.Services
{
    public class MovieService : ServiceBase, IMovieQueryService, IMovieCommandService
    {
        private readonly IMovieRepository _movieRepository;

        public MovieService(IMovieRepository movieRepository, IMapper mapper) : base(mapper)
        {
            _movieRepository = movieRepository;
        }

        public async Task CreateMovie(CreateMovie command)
        {
            var movie = await Movie.CreateMovie(command.Title, command.DurationMinutes);
            await _movieRepository.AddMovie(movie);
        }

        public async Task DeleteMovie(Guid id)
        {
            await _movieRepository.DeleteMovie(id);
        }

        public async Task<IEnumerable<MovieDTO>> GetAll()
        {
            return Map<IEnumerable<Movie>, IEnumerable<MovieDTO>>(await _movieRepository.GetAll());
        }

        public async Task<MovieDTO> GetMovie(Guid id)
        {

            return Map<Movie, MovieDTO>(await _movieRepository.GetMovie(id));
        }

        public async Task UpdateMovie(UpdateMovie command)
        {
            var movie = await _movieRepository.GetMovie(command.Id);
            movie.Title = command.Title;
            movie.DurationMinutes = command.DurationMinutes;
            await _movieRepository.UpdateMovie(movie);
        }
    }
}
