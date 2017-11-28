using System;
using System.Collections.Generic;
using System.Text;

namespace Movies.Infrastructure.Commands.Movies
{
    public class CreateMovie : ICommand
    {
        public string Title { get; set; }
        public double DurationMinutes { get; set; }
    }
}
