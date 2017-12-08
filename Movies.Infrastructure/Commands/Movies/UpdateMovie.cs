using System;

namespace Movies.Infrastructure.Commands.Movies
{
    public class UpdateMovie : ICommand
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public double DurationMinutes { get; set; }
        public Guid DirectorId { get; set; }
    }
}