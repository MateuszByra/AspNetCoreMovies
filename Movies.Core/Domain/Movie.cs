using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Core.Domain
{
    public class Movie
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public double DurationMinutes { get; set; }
        public Director Director { get; protected set; }
        private ISet<Actor> actors = new HashSet<Actor>();

        protected Movie()
        {
            Id = Guid.NewGuid();
        }

        public Movie(string title, double durationMinutes)
        {
            Id = Guid.NewGuid();
            setTitle(title);
            setDuration(durationMinutes);
        }

        private void setTitle(string title)
        {
            if (string.IsNullOrEmpty(title))
            {
                throw new ArgumentException("Title cannot be null or empty.");
            }
            Title = title;
        }

        private void setDuration(double duration)
        {
            if (duration <= 0)
            {
                throw new ArgumentException("Duration must be greater than 0.");
            }
            DurationMinutes = duration;
        }

        public void AddActor(Actor actor)
        {
            if (actors.FirstOrDefault(x => x.Id == actor.Id) != null)
            {
                throw new InvalidOperationException($"Actor with id {actor.Id} already exists");
            }
            actors.Add(actor);
        }

        public void SetDirector(Director director)
        {
            if (director == null)
            {
                throw new ArgumentException("Director cannot be null.");
            }
            Director = director;
        }

        public static Movie CreateMovie(string title, double durationMinutes)
        {
            return new Movie(title, durationMinutes);
        }
    }
}
