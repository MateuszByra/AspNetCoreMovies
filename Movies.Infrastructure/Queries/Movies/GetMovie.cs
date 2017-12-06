using System;

namespace Movies.Infrastructure.Queries.Movies
{
    public class GetMovie : IQuery
    {
        public Guid Id { get; set; }
    }
}