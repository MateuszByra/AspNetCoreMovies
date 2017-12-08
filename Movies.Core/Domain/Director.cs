using System;

namespace Movies.Core.Domain
{
    public class Director
    {
        public Guid Id { get; protected set; }

        public PersonalData PersonalData { get; protected set; }

        protected Director()
        {

        }

        protected Director(PersonalData personalData)
        {
            if (personalData == null)
            {
                throw new ArgumentException("Personal data cannot be null.");
            }
            PersonalData = personalData;
            Id = Guid.NewGuid();
        }

        public static Director Create(PersonalData personalData) => new Director(personalData);
    }
}