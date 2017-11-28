using System;
using System.Collections.Generic;
using System.Text;

namespace Movies.Infrastructure.DTO
{
    public class MovieDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public double DurationMinutes { get; set; }
    }
}
