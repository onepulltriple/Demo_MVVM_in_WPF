using Demo.Models;

namespace Demo.Services
{
    public class PersonService : IPersonService
    {
        public IEnumerable<PersonModel> GetPeople()
        {
            // In a real app, this implementation would be ONE of: a database call, REST API call, file read, etc.
            // the source of truth / where data comes from may influence the way in which that data is summoned
            // if so, different Services which implement IPersonService can be chosen based on e.g. the OS in use

            return new List<PersonModel>
            {
                new PersonModel("Alice", 20, 1),
                new PersonModel("Bob", 25, 2),
                new PersonModel("Charlie", 30, 3)
            };
        }

        public PersonModel GetOnePerson()
        {
            return new PersonModel("Chase", 25, 4);
        }
    }
}
