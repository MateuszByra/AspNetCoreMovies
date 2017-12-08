using System;
using System.Threading.Tasks;
using Movies.Core.Domain;

namespace Movies.Core.Repositories
{
    public interface IDirectorRepository
    {
        Task<Director> GetAsync(Guid id);
        Task SaveAsync(Director director);
        Task<Director> CreateAsync(string firstName, string lastName);
    }
}