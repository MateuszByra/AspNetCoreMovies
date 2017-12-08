using System;

namespace Movies.Infrastructure.Queries.Directors
{
    public class GetDirector : IQuery
    {
        public Guid Id { get; set; }
    }
}