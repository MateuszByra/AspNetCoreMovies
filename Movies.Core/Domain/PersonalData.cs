using System;

namespace Movies.Core.Domain
{
    /// <summary>
    /// Value object
    /// </summary>
    public class PersonalData
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        protected PersonalData()
        {
            
        }

        private PersonalData(string firstName, string lastName)
        {
            if (string.IsNullOrEmpty(firstName))
            {
                throw new ArgumentNullException("First name cannot be null or empty.");
            }

            if (string.IsNullOrEmpty(lastName))
            {
                throw new ArgumentNullException("Last name cannot be null or empty.");
            }

            FirstName = firstName;
            LastName = lastName;
        }

        public static PersonalData Create(string firstName, string lastName)=>new PersonalData(firstName,lastName);
    }
}