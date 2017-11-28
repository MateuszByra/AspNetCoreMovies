using System;
using System.Collections.Generic;
using System.Text;

namespace Movies.Core.Domain
{
    public class Movie
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public double DurationMinutes { get; set; }

        public Movie(string title, double durationMinutes)
        {
            Id = Guid.NewGuid();
            Title = title;
            DurationMinutes = durationMinutes;
        }

        public static Movie CreateMovie(string title, double durationMinutes)
        {
            return new Movie(title, durationMinutes);
        }
    }
}
