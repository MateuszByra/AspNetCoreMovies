﻿using System;
using System.Collections.Generic;
using Movies.Infrastructure.DTO;
using Movies.Core.Repositories;
using AutoMapper;
using Movies.Core.Domain;
using Movies.Infrastructure.Commands.Movies;
using System.Threading.Tasks;
using Movies.Infrastructure.Repositories;
using Movies.Infrastructure.Exceptions;

namespace Movies.Infrastructure.Services.Movies
{
    public class MovieService : ServiceBase, IMovieQueryService, IMovieCommandService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IDirectorRepository _directorRepository;

        public MovieService(IMovieRepository movieRepository, IDirectorRepository directorRepository, IMapper mapper) : base(mapper)
        {
            _movieRepository = movieRepository;
            _directorRepository = directorRepository;
        }

        public async Task CreateMovie(CreateMovie command)
        {
            var director = _directorRepository.GetAsync(command.DirectorId);
            var movie = await _movieRepository.CreateAsync(command.Title, command.DurationMinutes);

            movie.SetDirector(await director);

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
            var movie = Map<Movie, MovieDTO>(await _movieRepository.GetMovie(id));
            if (movie == null)
            {
                throw new ServiceException(ErrorCodes.MovieNodFound,
                    $"Movie with id: {id} not found.");
            }
            return movie;
        }

        public async Task UpdateMovie(UpdateMovie command)
        {
            var director = _directorRepository.GetAsync(command.DirectorId);
            var movie = await _movieRepository.GetMovie(command.Id);
            movie.Title = command.Title;
            movie.DurationMinutes = command.DurationMinutes;


            movie.SetDirector(await director);
            await _movieRepository.UpdateMovie(movie);
        }
    }
}
