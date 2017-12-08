using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Movies.Core.Domain;
using Movies.Core.Repositories;
using Movies.Infrastructure.Commands.Directors;
using Movies.Infrastructure.DTO;
using Movies.Infrastructure.Queries.Directors;
using Movies.Infrastructure.Repositories;

namespace Movies.Infrastructure.Services.Directors
{
    public class DirectorService : ServiceBase, IDirectorCommandService, IDirectorQueryService
    {
        private readonly IDirectorRepository _directorRepository;
        public DirectorService(IDirectorRepository directorRepository,IMapper mapper) : base(mapper)
        {
            _directorRepository = directorRepository;
        }

        public async Task CreateDirectorAsync(CreateDirector command)
        {
            await _directorRepository.CreateAsync(command.FirstName, command.LastName);
        }

        public async Task<DirectorDTO> GetAsync(GetDirector query)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<DirectorDTO>> ListAsync(ListDirectors query)
        {
            throw new System.NotImplementedException();
        }
    }
}