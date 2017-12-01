using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using LiteDB;
using Movies.Core.Domain;
using Movies.Core.Repositories;
using Movies.Infrastructure.LiteDB;

namespace Movies.Infrastructure.Repositories
{
    /// <summary>
    /// No sql database
    /// </summary>
    public class LiteDbMovieRepository : IMovieRepository
    {
        private LiteDatabase _conection;
        private const string tableName = "Movies";
        //private const string databaseName = "DbNoSqlLiteDatabase.db";

        public LiteDbMovieRepository(LiteDbSettings settings)
        {
            _conection = new LiteDatabase(settings.DatabaseName);
        }
        public Movie GetMovie(Guid id)
        {
            var colection = _conection.GetCollection<Movie>(tableName);
            return colection.FindById(id);
        }

        public void AddMovie(Movie movie)
        {
            InsertOrUpdate(movie);
        }

        public void UpdateMovie(Movie movie)
        {
            InsertOrUpdate(movie);
        }

        public void DeleteMovie(Guid id)
        {
            var collection = _conection.GetCollection<Movie>(tableName);
            var row = collection.FindOne(x => x.Id == id);
            collection.Delete(row.Id);
        }

        public IEnumerable<Movie> GetAll()
        {
            var colection = _conection.GetCollection<Movie>(tableName);
            return colection.FindAll();
        }

        private void InsertOrUpdate(Movie model)
        {
            var colection = _conection.GetCollection<Movie>(tableName);
            if (colection.Find(x => x.Id == model.Id).Any())
            {
                colection.Update(model);
            }
            else
            {
                colection.Insert(model);
                colection.EnsureIndex(x => x.Title);
            }
        }
    }
}
