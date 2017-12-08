namespace Movies.Infrastructure.Commands.Directors
{
    public class CreateDirector : ICommand
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}