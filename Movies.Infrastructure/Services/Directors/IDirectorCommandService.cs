using System.Threading.Tasks;
using Movies.Infrastructure.Commands.Directors;

namespace Movies.Infrastructure.Services.Directors
{
    public interface IDirectorCommandService : IService
    {
        Task CreateDirectorAsync(CreateDirector command);
    }
}