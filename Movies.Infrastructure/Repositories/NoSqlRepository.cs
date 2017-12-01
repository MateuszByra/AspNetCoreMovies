using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using LiteDB;
using Movies.Core.Domain;
using Movies.Core.Repositories;

namespace Movies.Infrastructure.Repositories
{
    /// <summary>
    /// No sql database
    /// </summary>
    public class NoSqlRepository : IMovieRepository
    {
        private LiteDatabase _conection;
        /// <summary>
        /// Table name
        /// </summary>
        private const string _contractor = "Movies";
        //private const string _address = "Address";
        //private string pathDb = @"C:\db";
        private const string databaseName = "DbNoSqlLiteDatabase.db";

        public NoSqlRepository()
        {
            //if (!Directory.Exists(databaseName))
            //{
            //    Directory.CreateDirectory(pathDb);
            //}
            _conection = new LiteDatabase(databaseName);
        }
        public Movie GetMovie(Guid id)
        {
            var colection = _conection.GetCollection<Movie>(_contractor);
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
            throw new NotImplementedException();
        }

        public IEnumerable<Movie> GetAll()
        {
            var colection = _conection.GetCollection<Movie>(_contractor);
            return colection.FindAll();
        }

        private void InsertOrUpdate(Movie model)
        {
            var colection = _conection.GetCollection<Movie>(_contractor);
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
