using System.Collections.Generic;
using System.Linq;
using Bogus;
using Bogus.Extensions;
using LanguageExt;
using static LanguageExt.Prelude;

namespace language_ext.benchmark.api
{
    public class UserRepository
    {
        private readonly List<User> users;

        public UserRepository()
        {
            var autoIncrement = 1;
            var faker = new Faker<User>()
                .RuleFor(u => u.Id, f => autoIncrement++)
                .RuleFor(u => u.FirstName, f => f.Person.FirstName)
                .RuleFor(u => u.LastName, f => f.Person.LastName)
                .RuleFor(u => u.Employer, f => f.Person.Company.Name.OrNull(f));

            users = faker.Generate(10_000);
        }

        public IEnumerable<User> FindWithLinq() =>
            users
                .Select(u => u.SetFirstName(u.FirstName.ToUpperInvariant()))
                .Select(u => u.SetLastName(u.LastName.ToUpperInvariant()))
                .Select(u =>
                {
                    try { return u.SetEmployer(u.Employer.ToUpperInvariant()); }
                    catch { return u.SetEmployer("FOO"); }
                });

        public Seq<User> FindWithLangExt() =>
            users
                .ToSeq()
                .Map(u => u.SetFirstName(u.FirstName.ToUpperInvariant()))
                .Map(u => u.SetLastName(u.LastName.ToUpperInvariant()))
                .Map(u => Try(() => u.SetEmployer(u.Employer.ToUpperInvariant()))
                                .Match(u => u, fail => u.SetEmployer("FOO")));
    }
}



