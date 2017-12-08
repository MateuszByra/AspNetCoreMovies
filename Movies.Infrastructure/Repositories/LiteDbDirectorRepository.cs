using System;
using System.Threading.Tasks;
using Movies.Core.Domain;
using Movies.Core.Repositories;

namespace Movies.Infrastructure.Repositories
{
    public class LiteDbDirectorRepository : IDirectorRepository
    {
        public async Task<Director> CreateAsync(string firstName, string lastName)
        {
            throw new NotImplementedException();
        }

        public async Task<Director> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task SaveAsync(Director director)
        {
            throw new NotImplementedException();
        }
    }
}