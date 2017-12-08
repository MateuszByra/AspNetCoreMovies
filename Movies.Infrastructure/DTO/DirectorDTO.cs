using System;

namespace Movies.Infrastructure.DTO
{
    public class DirectorDTO
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}