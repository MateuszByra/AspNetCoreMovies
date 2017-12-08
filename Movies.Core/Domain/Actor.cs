using System;

namespace Movies.Core.Domain
{
    public class Actor
    {
        public Guid Id { get; protected set; }
        public PersonalData PersonalData { get; protected set; }

        protected Actor()
        {
            
        }

        protected Actor(PersonalData personalData)
        {
            if (personalData == null)
            {
                throw new ArgumentException("Personal data cannot be null.");
            }
            PersonalData = personalData;
            Id = Guid.NewGuid();
        }

        public static Actor Create(PersonalData personalData) =>new Actor(personalData);
    }
}