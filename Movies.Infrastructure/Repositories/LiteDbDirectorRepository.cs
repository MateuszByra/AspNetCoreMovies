using System;
using System.Linq;
using System.Threading.Tasks;
using LiteDB;
using Movies.Core.Domain;
using Movies.Core.Repositories;
using Movies.Infrastructure.LiteDB;

namespace Movies.Infrastructure.Repositories
{
    public class LiteDbDirectorRepository : IDirectorRepository
    {
        private LiteDatabase _conection;
        private const string tableName = "Directors";

        public LiteDbDirectorRepository(LiteDbSettings settings)
        {
            _conection = new LiteDatabase(settings.DatabaseName);
        }
        public async Task<Director> CreateAsync(string firstName, string lastName)
        {
            var director = await Task.FromResult(Director.Create(PersonalData.Create(firstName, lastName)));
            return director;
        }

        public async Task<Director> GetAsync(Guid id)
        {
            var colection = _conection.GetCollection<Director>(tableName);
            var director = await Task.FromResult(colection.FindById(id));
            return director;
        }

        public async Task SaveAsync(Director director)
        {
            await InsertOrUpdate(director);
        }

        private async Task InsertOrUpdate(Director director)
        {
            var colection = _conection.GetCollection<Director>(tableName);
            if (colection.Find(x => x.Id == director.Id).Any())
            {
                colection.Update(director);
            }
            else
            {
                colection.Insert(director);
            }
            await Task.CompletedTask;
        }
    }
}