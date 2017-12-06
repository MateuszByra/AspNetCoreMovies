using System;

namespace Movies.Infrastructure.Commands.Movies
{
    public class DeleteMovie : ICommand
    {
        public Guid Id { get; set; }
    }
}