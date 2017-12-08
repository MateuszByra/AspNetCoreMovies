using System.Collections.Generic;
using System.Threading.Tasks;
using Movies.Infrastructure.DTO;
using Movies.Infrastructure.Queries.Directors;

namespace Movies.Infrastructure.Services.Directors
{
    public interface IDirectorQueryService : IService
    {
        Task<DirectorDTO> GetAsync(GetDirector query);
        Task<IEnumerable<DirectorDTO>> ListAsync(ListDirectors query);
    }
}