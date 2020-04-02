namespace language_ext.benchmark
{
    public class User
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Employer { get; set; }

        public User SetFirstName(string firstName)
        {
            FirstName = firstName;
            return this;
        }

        public User SetLastName(string lastName)
        {
            LastName = lastName;
            return this;
        }

        public User SetEmployer(string employer)
        {
            Employer = employer;
            return this;
        }
    }
}